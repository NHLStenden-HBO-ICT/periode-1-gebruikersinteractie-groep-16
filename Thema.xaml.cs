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
    /// Interaction logic for Thema.xaml
    /// </summary>
    public partial class Thema : Window
    {
        public Thema()
        {
            InitializeComponent();
        }

        private void OpenMoelijkheidsgraad(object sender, RoutedEventArgs e)
        {
            MainWindow objsecondwindow = new();
            this.Visibility = Visibility.Hidden;
            objsecondwindow.Show();
        }
    }
}
