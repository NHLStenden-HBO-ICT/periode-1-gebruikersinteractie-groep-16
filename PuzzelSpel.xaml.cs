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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for PuzzelSpel.xaml
    /// </summary>
    public partial class PuzzelSpel : Window
    {
        public PuzzelSpel()
        {
            InitializeComponent();
        }

        private void Openmoeilijkheidsgraad(object sender, RoutedEventArgs e)
        {
            MainWindow objsecondwindow = new();
            this.Visibility = Visibility.Hidden;
            objsecondwindow.Show();
        }
    }
}
