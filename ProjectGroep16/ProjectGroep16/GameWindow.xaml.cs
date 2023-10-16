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
using System.Windows.Shapes;

namespace PuzzelGame
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
            gameWindow.Show();
            this.Close(); // Sluit het huidige venster (optioneel).
        }
        private void Image1_Click(object sender, RoutedEventArgs e)
        {
            DeGame deGame = new DeGame();
            deGame.Show();
            this.Close();
        }

        private void Image2_Click(object sender, RoutedEventArgs e)
        {
            // Voeg hier de code toe om naar het gewenste venster te gaan wanneer op de tweede afbeelding wordt geklikt.
        }

        private void Image3_Click(object sender, RoutedEventArgs e)
        {
            // Voeg hier de code toe om naar het gewenste venster te gaan wanneer op de derde afbeelding wordt geklikt.
        }
    }
}
