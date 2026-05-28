using Laboration_2.Model;
using System.Collections.ObjectModel;
using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Laboration_2.View.Windows.AddMemberToEventWindow
{
    /// <summary>
    /// Interaction logic for AddMemberToEventWindow.xaml
    /// </summary>
    public partial class AddMemberToEventWindow : Window
    {

        List<Medlem> GiltligaMedlemmar = new List<Medlem>();

        Aktivitet aktivitet { get; set; }
        public AddMemberToEventWindow(Window parentWindow, Aktivitet aktivitet, ObservableCollection<Medlem> medlemar)
        {
            Owner = parentWindow;
            InitializeComponent();

            this.aktivitet = aktivitet;
            // Filtrera ut medlemmar som inte redan är deltagare i aktiviteten
            GiltligaMedlemmar = medlemar.Where(m => !aktivitet.Deltagare.Contains(m)).ToList();
            GiltligaMedlemmar = GiltligaMedlemmar.OrderBy(m => m.Name).ToList();

            cbMedlem.ItemsSource = GiltligaMedlemmar;

            cbMedlem.ItemsSource = GiltligaMedlemmar;
            tbTitel.Text = $"Namn: {aktivitet.Namn}";
            tbDatum.Text = $"Datum: {aktivitet.Datum}";
            tbSpel.Text = $"Spel: {aktivitet.Spel.Titel}";
            tbDeltagare.Text = $"Deltagare: {aktivitet.AntalDeltagare}/{aktivitet.MaxDeltagare}";
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAddMember_Click(object sender, RoutedEventArgs e)
        {
            if(!(cbMedlem.SelectedItem == null))
            {
                aktivitet.AddDeltagare((Medlem)cbMedlem.SelectedItem);
                Close();
            }
        }
    }
}
