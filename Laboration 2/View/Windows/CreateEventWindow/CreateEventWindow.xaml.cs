using Laboration_2.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Xml.Linq;

namespace Laboration_2.View.Windows.CreateEventWindow
{
    /// <summary>
    /// Interaction logic for CreateEventWindow.xaml
    /// </summary>
    public partial class CreateEventWindow : Window
    {
        public CreateEventWindow(Window parentWindow, ObservableCollection<Game> allaSpel)
        {
            Owner = parentWindow;
            InitializeComponent();
            cbSpel.ItemsSource = allaSpel;
        }

        public Event CreatedEvent { get; private set; }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAddEvent_Click(object sender, RoutedEventArgs e)
        {
            string? titel = txtTitel.Text;
            int maxDeltagare;
            DateTime? datum = datePicker.SelectedDate;
            Game? spel = (Game)cbSpel.SelectedItem;

            if (string.IsNullOrEmpty(titel))
                MessageBox.Show("Namn måste vara ifyllt.", "Felaktig information", MessageBoxButton.OK, MessageBoxImage.Information);
            else if(!int.TryParse(txtMaxDeltagare.Text, out maxDeltagare))
                MessageBox.Show("Alla fält måste vara ifyllda", "Felaktig information", MessageBoxButton.OK, MessageBoxImage.Information);
            else if(datum == null)
                MessageBox.Show("Alla fält måste vara ifyllda", "Felaktig information", MessageBoxButton.OK, MessageBoxImage.Information);
            else if(cbSpel.SelectedItem == null)
                MessageBox.Show("Alla fält måste vara ifyllda", "Felaktig information", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                CreatedEvent = new Event(titel, datum.Value, spel, maxDeltagare);
                DialogResult = true;
                Close();
            }
        }
    }
}
