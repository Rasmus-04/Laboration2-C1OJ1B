using Laboration_2.Model;
using System.Windows;

namespace Laboration_2.View.Windows.CreateGameWindow
{
    /// <summary>
    /// Interaction logic for CreateGameWindow.xaml
    /// </summary>
    public partial class CreateGameWindow : Window
    {

        public Spel CreatedSpel { get; private set; }

        public CreateGameWindow(Window parentWindow)
        {
            InitializeComponent();
            Owner = parentWindow;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            string titel = txtTitel.Text;
            int max;
            int min;

            if (string.IsNullOrEmpty(titel))
                MessageBox.Show("Titel måste vara ifyllt.", "Felaktig Titel", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (!int.TryParse(maxPlayers.Text, out max))
                MessageBox.Show("Alla fält måste vara ifyllda!", "Felaktig inmatning", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (!int.TryParse(minPlayers.Text, out min))
                MessageBox.Show("Alla fält måste vara ifyllda!", "Felaktig inmatning", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                Spel newSpel = new Spel(titel, max, min);
                CreatedSpel = newSpel;
                DialogResult = true;
                Close();
            }
        }
    }
}
