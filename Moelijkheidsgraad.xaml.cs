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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

           



        private void OpenPuzzelSpel(object sender, RoutedEventArgs e)
        {
            PuzzelSpel objsecondwindow = new();
            this.Visibility = Visibility.Hidden;
            objsecondwindow.Show();

        }

        private void OpenThemascherm(object sender, RoutedEventArgs e)
        {
            Thema  objsecondwindow = new();
            this.Visibility = Visibility.Hidden;
            objsecondwindow.Show();
        }
       
    }
   
}
