using Laboration_2.Model;
using Laboration_2.View.Windows.AddMemberToEventWindow;
using Laboration_2.View.Windows.EventInfoWindow;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Laboration_2.View.UserControls.EventListView
{
    /// <summary>
    /// Interaction logic for EventListView.xaml
    /// </summary>
    public partial class EventListView : UserControl
    {
        public EventListView()
        {
            InitializeComponent();
            Loaded += EventListView_Loaded;
        }

        // Sortera aktiviteterna i ListViewn efter datum när sidan laddas
        private void EventListView_Loaded(object sender, RoutedEventArgs e)
        {
            // ItemsSource may not be set yet when Loaded fires. Use lvAktiviteter.Items as a fallback
            // and guard against a null view to avoid NullReferenceException.
            var source = lvAktiviteter.ItemsSource ?? lvAktiviteter.Items;
            CollectionView view = CollectionViewSource.GetDefaultView(source) as CollectionView;

            if (view == null)
                return;

            view.SortDescriptions.Add(new SortDescription("Datum", ListSortDirection.Ascending));
        }

        private void btnRemoveActivity_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);

            if (lvAktiviteter.SelectedItem == null)
                return;
            MessageBoxResult result = MessageBox.Show("Är du säker att du vill ta bort denna Aktivitet?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                mainWindow.AllaAktiviteter.Remove((Aktivitet)lvAktiviteter.SelectedItem);
            }
        }

        private void btnVisaDeltagare_Click(object sender, RoutedEventArgs e)
        {
            if (lvAktiviteter.SelectedItem == null)
                return;

            Window parentWindow = Window.GetWindow(this);

            // För tillgång till listorna i MainWindow.xaml.cs
            MainWindow mainWindow = (MainWindow)parentWindow;

            EventInfoWindow deltagareWindow = new EventInfoWindow(parentWindow, (Aktivitet)lvAktiviteter.SelectedItem);
            parentWindow.Opacity = .4;
            deltagareWindow.ShowDialog();
            parentWindow.Opacity = 1;
        }

        private void btnAddMember_Click(object sender, RoutedEventArgs e)
        {
            if (lvAktiviteter.SelectedItem == null)
                return;

            Window parentWindow = Window.GetWindow(this);

            // För tillgång till listorna i MainWindow.xaml.cs
            MainWindow mainWindow = (MainWindow)parentWindow;

            AddMemberToEventWindow deltagareWindow = new AddMemberToEventWindow(parentWindow, (Aktivitet)lvAktiviteter.SelectedItem, mainWindow.Members);

            parentWindow.Opacity = .4;
            deltagareWindow.ShowDialog();
            parentWindow.Opacity = 1;
        }
    }
}
