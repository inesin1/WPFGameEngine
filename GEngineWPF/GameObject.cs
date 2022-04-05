using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Windows;
using System.Windows.Data;

namespace GEngineWPF
{
    public class GameObject
    {
        //Object
        public Border Object = new Border();

        public string name;
        public Image image; //image asset
        private double x; //x coordinate
        public double X
        {
            get { return x; }
            set { 
                x = value;
                UpdateCoordinates();
            }
        }
        private double y; //y coordinate
        public double Y
        {
            get { return y; }
            set
            {
                y = value;
                UpdateCoordinates();
            }
        }
        public double width; //width
        public double height; //height

        private const string EMPTY_IMAGE = @"C:\Users\artem\source\repos\GEngineWPF\GEngineWPF\assets\empty_image.png";

        //Mouse moving
        bool isMoved = false;
        Point startPosition;

        //Creates
        public GameObject(string name, double x, double y, double width, double height, Image image) { 
            this.name = name;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height; 
            this.image = image;

            InizializeObject();
            InizializeEvents();
        }

        public GameObject(string name, double x, double y, Image image)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.image = image;

            InizializeObject();
            InizializeEvents();
        }

        public GameObject(string name, double x, double y, double width, double height, string image)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;

            //Create image using "image" as path
            Image _image = new Image();

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(image);
            bitmap.EndInit();

            _image.Source = bitmap;

            this.image = _image;

            InizializeObject();
            InizializeEvents();
        }

        public GameObject(string name, double x, double y, string image)
        {
            this.name = name;
            this.x = x;
            this.y = y;

            //Create image using "image" as path
            Image _image = new Image();

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(image);
            bitmap.EndInit();

            _image.Source = bitmap;

            this.image = _image;

            InizializeObject();
            InizializeEvents();
        }

        public GameObject(string name, double x, double y)
        {
            this.name = name;
            this.x = x;
            this.y = y;

            //Create image using "image" as path
            Image _image = new Image();

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(EMPTY_IMAGE);
            bitmap.EndInit();

            _image.Source = bitmap;

            _image.Height = 50;
            _image.Width = 50;

            this.image = _image;

            InizializeObject();
            InizializeEvents();
        }

        public GameObject() { }

        //Inizialize
        private void InizializeObject() {
            Object.BorderThickness = new Thickness(1);                                                                                                                                                                                               
        }

        private void InizializeEvents()
        {
            Object.MouseLeftButtonDown += Object_MouseLeftButtonDown;
            Object.MouseLeftButtonUp += Object_MouseLeftButtonUp;
            Object.MouseMove += Object_MouseMove;
        }

        //Events
        private void UpdateCoordinates()
        {
            Canvas.SetLeft(Object, X); 
            Canvas.SetTop(Object, Y);
        }

        private void Object_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isMoved = true;
            startPosition = e.GetPosition(MainWindow.mainWindow);

            Object.BorderBrush = Brushes.Gray;
        }

        private void Object_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isMoved = false;

            Object.BorderBrush = Brushes.Transparent;
        }

        private void Object_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoved)
            {
                X = X + (e.GetPosition(MainWindow.mainWindow).X - startPosition.X);
                Y = Y + (e.GetPosition(MainWindow.mainWindow).Y - startPosition.Y);

                startPosition = e.GetPosition(MainWindow.mainWindow);
            }
        }
    }
}
