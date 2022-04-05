using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;

namespace GEngineWPF
{
    internal class Game
    {
        public Canvas GameField = MainWindow.GameField;
        public string corePath = Directory.GetCurrentDirectory().Replace("bin\\Debug", "");

        public Game() {
            
        }

        public void SetGameObjectOnScreen(GameObject gameObject) {
            Border gameObjectToDisplay = gameObject.Object;
            ((IAddChild)gameObjectToDisplay).AddChild(gameObject.image);

            //Add object on GameField
            GameField.Children.Add(gameObjectToDisplay);

            //Set coordinates
            Canvas.SetLeft(gameObjectToDisplay, gameObject.X);
            Canvas.SetTop(gameObjectToDisplay, gameObject.Y);

            //Set name to object
            gameObjectToDisplay.Name = gameObject.name;
        }
    }
}
