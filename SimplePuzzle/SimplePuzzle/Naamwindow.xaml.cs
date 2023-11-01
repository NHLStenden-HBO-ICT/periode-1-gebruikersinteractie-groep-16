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

namespace SimplePuzzle
{
    /// <summary>
    /// Interaction logic for Naamwindow.xaml
    /// </summary>
    public partial class Naamwindow : Window
    {
        public Naamwindow()
        {
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void door_Click(object sender, RoutedEventArgs e)
        {
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void Sperler2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Speler1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}