using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GEngineWPF
{
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow;
        public static Canvas GameField;
        public static TextBlock DebugTextBlock;

        public MainWindow()
        {
            InitializeComponent();

            GameField = gameField;
            DebugTextBlock = debugTextBlock;
            mainWindow = this;

            StartGame();

            this.MouseMove += MainWindow_MouseMove;
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            debugTextBlock.Text = "X: " + e.GetPosition(this).X + " Y: " + e.GetPosition(this).Y;
        }

        private void StartGame() {
            Game game = new Game();

            GameObject emptyObject = new GameObject("Empty", 50, 10);
            game.SetGameObjectOnScreen(emptyObject);

            GameObject lamp = new GameObject("Lamp", 30, 30, game.corePath + "assets\\sprites\\lamp.png");
            game.SetGameObjectOnScreen(lamp);

            GameObject shop = new GameObject("Shop", 500, 500, game.corePath + "assets\\sprites\\shop.png");
            game.SetGameObjectOnScreen(shop);

            
        }
    }
}
