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
    /// Interaction logic for Eindscherm.xaml
    /// </summary>
    public partial class Eindscherm : Window
    {
        public Eindscherm()
        {
            InitializeComponent();
        }
        private void NieuwSpel_Click(object sender, RoutedEventArgs e)
        {
            Starten startenWindow = new Starten();
            startenWindow.Show(); 
            this.Close(); 
        }

        private void SpelSluiten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



    }
}
