using Laboration_2.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace Laboration_2.View.Windows.EventInfoWindow
{
    /// <summary>
    /// Interaction logic for DeltagareWindow.xaml
    /// </summary>
    public partial class EventInfoWindow : Window
    {
        private Event aktivitet;
        private ObservableCollection<Member> members = new ObservableCollection<Member>();

        public ObservableCollection<Member> Members
        {
            get { return members; }
            set { members = value; }
        }


        public EventInfoWindow(Window parentWindow, Event aktivitet)
        {
            Owner = parentWindow;
            this.aktivitet = aktivitet;
            Members = aktivitet.Participants;
            InitializeComponent();
            DataContext = this;

            tbTitel.Text = $"Namn: {aktivitet.Name}";
            tbDatum.Text = $"Datum: {aktivitet.EventDate}";
            tbSpel.Text = $"Spel: {aktivitet.EventGame.Titel}";
            tbDeltagare.Text = $"Deltagare: {aktivitet.CurrentParticipants}/{aktivitet.MaxParticipants}";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void btnRemoveMember_Click(object sender, RoutedEventArgs e)
        {
            if (lvMembers.SelectedItem == null)
                return;

            Member selectedMember = (Member)lvMembers.SelectedItem;

            MessageBoxResult result = MessageBox.Show(
                "Är du säker att du vill ta bort deltagaren?",
                "Bekräfta borttagning",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                aktivitet.RemoveParticipant(selectedMember);
            }
        }
    }
}
