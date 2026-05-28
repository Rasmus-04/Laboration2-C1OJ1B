using Laboration_2.Model;
using System.Windows;
using System.Windows.Controls;

namespace Laboration_2.Vy.MedlemarVy
{
    /// <summary>
    /// Interaction logic for MedlemarVy.xaml
    /// </summary>
    public partial class MedlemarVy : UserControl
    {
        public MedlemarVy()
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
