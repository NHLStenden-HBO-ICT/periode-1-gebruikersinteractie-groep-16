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
    /// Interaction logic for Starten.xaml
    /// </summary>
    public partial class Starten : Window
    {
        public Starten()
        {
            InitializeComponent();
        }
        private void start_Click(object sender, RoutedEventArgs e)
        {
            Naamwindow naamwindow = new Naamwindow();
            naamwindow.Show();
            this.Close();
        }
    }
}
