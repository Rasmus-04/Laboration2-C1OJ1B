using Laboration_2.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Xml.Linq;

namespace Laboration_2.Vy.AddEventWindow
{
    /// <summary>
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Window
    {
        public AddEvent(Window parentWindow, ObservableCollection<Spel> allaSpel)
        {
            Owner = parentWindow;
            InitializeComponent();
            cbSpel.ItemsSource = allaSpel;
        }

        public Aktivitet CreatedEvent { get; private set; }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAddEvent_Click(object sender, RoutedEventArgs e)
        {
            string? titel = txtTitel.Text;
            int maxDeltagare;
            DateTime? datum = datePicker.SelectedDate;
            Spel? spel = (Spel)cbSpel.SelectedItem;

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
                CreatedEvent = new Aktivitet(titel, datum.Value, spel, maxDeltagare);
                DialogResult = true;
                Close();
            }
        }
    }
}
