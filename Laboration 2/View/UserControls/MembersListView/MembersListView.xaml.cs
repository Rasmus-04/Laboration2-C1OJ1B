using Laboration_2.Model;
using System.Windows;
using System.Windows.Controls;

namespace Laboration_2.View.UserControls.MembersListView
{
    /// <summary>
    /// Interaction logic for MembersListView.xaml
    /// </summary>
    public partial class MembersListView : UserControl
    {
        public MembersListView()
        {
            InitializeComponent();
        }


        private void btnRemoveMember_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);

            if (lvMembers.SelectedItem == null)
                return;
            MessageBoxResult result = MessageBox.Show("Är du säker att du vill ta bort denna medlem?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                mainWindow.Members.Remove((Medlem)lvMembers.SelectedItem);
            }
        }
    }
}
