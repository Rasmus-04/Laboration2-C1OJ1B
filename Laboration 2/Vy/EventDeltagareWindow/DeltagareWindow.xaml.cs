using System.Collections.ObjectModel;
using System.Windows;

namespace Laboration_2.Vy.EventDeltagareWindow
{
    /// <summary>
    /// Interaction logic for DeltagareWindow.xaml
    /// </summary>
    public partial class DeltagareWindow : Window
    {
        private Aktivitet aktivitet;
        private ObservableCollection<Medlem> members = new ObservableCollection<Medlem>();

        public ObservableCollection<Medlem> Members
        {
            get { return members; }
            set { members = value; }
        }


        public DeltagareWindow(Window parentWindow, Aktivitet aktivitet)
        {
            Owner = parentWindow;
            this.aktivitet = aktivitet;
            Members = aktivitet.Deltagare;
            InitializeComponent();
            DataContext = this;

            tbTitel.Text = $"Namn: {aktivitet.Namn}";
            tbDatum.Text = $"Datum: {aktivitet.Datum}";
            tbSpel.Text = $"Spel: {aktivitet.Spel.Titel}";
            tbDeltagare.Text = $"Deltagare: {aktivitet.AntalDeltagare}/{aktivitet.MaxDeltagare}";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void btnRemoveMember_Click(object sender, RoutedEventArgs e)
        {
            if (lvMembers.SelectedItem == null)
                return;

            Medlem selectedMember = (Medlem)lvMembers.SelectedItem;

            MessageBoxResult result = MessageBox.Show(
                "Är du säker att du vill ta bort deltagaren?",
                "Bekräfta borttagning",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                aktivitet.RemoveDeltagare(selectedMember);
            }
        }
    }
}
