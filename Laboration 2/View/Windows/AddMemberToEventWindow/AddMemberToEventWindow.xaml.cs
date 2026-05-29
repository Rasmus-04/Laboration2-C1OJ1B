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

        List<Member> GiltligaMedlemmar = new List<Member>();

        Event aktivitet { get; set; }
        public AddMemberToEventWindow(Window parentWindow, Event aktivitet, ObservableCollection<Member> medlemar)
        {
            Owner = parentWindow;
            InitializeComponent();

            this.aktivitet = aktivitet;
            // Filtrera ut medlemmar som inte redan är deltagare i aktiviteten
            GiltligaMedlemmar = medlemar.Where(m => !aktivitet.Participants.Contains(m)).ToList();
            GiltligaMedlemmar = GiltligaMedlemmar.OrderBy(m => m.Name).ToList();

            cbMedlem.ItemsSource = GiltligaMedlemmar;

            cbMedlem.ItemsSource = GiltligaMedlemmar;
            tbTitel.Text = $"Namn: {aktivitet.Name}";
            tbDatum.Text = $"Datum: {aktivitet.EventDate}";
            tbSpel.Text = $"Spel: {aktivitet.EventGame.Titel}";
            tbDeltagare.Text = $"Deltagare: {aktivitet.CurrentParticipants}/{aktivitet.MaxParticipants}";
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAddMember_Click(object sender, RoutedEventArgs e)
        {
            if(!(cbMedlem.SelectedItem == null))
            {
                aktivitet.AddParticipant((Member)cbMedlem.SelectedItem);
                Close();
            }
        }
    }
}
