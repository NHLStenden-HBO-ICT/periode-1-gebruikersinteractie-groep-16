using System;
using System.Windows;
using System.Windows.Controls;

namespace PuzzelGame
{
    public partial class DeGame : Window
    {
        public DeGame()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = (Button)sender;

            // Controleer of het geklikte knopje leeg is
            if (clickedButton.Content.ToString() == "")
                return;

            // Vind de rij en kolom van het geklikte knopje in het Grid
            int row = -1;
            int col = -1;
            foreach (UIElement element in GameGrid.Children)
            {
                if (element is Button button)
                {
                    if (button == clickedButton)
                    {
                        row = Grid.GetRow(button);
                        col = Grid.GetColumn(button);
                        break;
                    }
                }
            }

            if (row == -1 || col == -1)
                return;

            // Controleer of het geklikte knopje naast het lege vakje ligt
            int emptyRow = Grid.GetRow(EmptyButton);
            int emptyCol = Grid.GetColumn(EmptyButton);
            if ((Math.Abs(row - emptyRow) == 1 && col == emptyCol) || (Math.Abs(col - emptyCol) == 1 && row == emptyRow))
            {
                // Ruil de inhoud van de geklikte knop en het lege vakje
                string temp = clickedButton.Content.ToString();
                clickedButton.Content = "";
                EmptyButton.Content = temp;
                EmptyButton.IsEnabled = true;
                clickedButton.IsEnabled = true;
            }

            // Voer hier de logica voor het controleren op winstcondities uit (bijvoorbeeld controleren of de stukjes in de juiste volgorde staan).
        }

        private Button? EmptyButton
        {
            get
            {
                foreach (UIElement element in GameGrid.Children)
                {
                    if (element is Button button && button.Content.ToString() == "")
                    {
                        return button;
                    }
                }
                return null;
            }
        }
    }
}
