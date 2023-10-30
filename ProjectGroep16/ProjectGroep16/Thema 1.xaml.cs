using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rick_Thema
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

       
        private void VorigeButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 objWindow1 = new Window1();
            this.Visibility = Visibility.Hidden;
            objWindow1.Show();
        }

        private void VolgendeButton_Click(object sender, RoutedEventArgs e)
        {
           Window1 objWindow1 = new Window1();
            this.Visibility = Visibility.Hidden;
            objWindow1.Show();
        }

        private void FotoButton_Click(object sender, RoutedEventArgs e)
        {
            spel objWindow1 = new spel();
            this.Visibility = Visibility.Hidden;
            objWindow1.Show();
        }

        private void Foto2Button_Click(object sender, RoutedEventArgs e)
        {
            spel objWindow1 = new spel();
            this.Visibility = Visibility.Hidden;
            objWindow1.Show();
        }

        private void Foto3Button_Click(object sender, RoutedEventArgs e)
        {
            spel objWindow1 = new spel();
            this.Visibility = Visibility.Hidden;
            objWindow1.Show();
        }

        private void Foto2Button_DpiChanged(object sender, DpiChangedEventArgs e)
        {

        }
    }

   
    
    
}
