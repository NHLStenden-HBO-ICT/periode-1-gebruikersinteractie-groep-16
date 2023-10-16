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

namespace ProjectGroep16
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
          /*  var Mainwindow = new MainWindow(); //create your new form.
            MainWindow.Show(); //show the new form.
            this.Close(); //only if you want to close the current form.
          */
        }

        private void SpelSluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

 
    }
}
