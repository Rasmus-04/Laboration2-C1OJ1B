using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Data;
using Laboration_2.Model;

namespace Laboration_2.Vy.SpelVy
{
    /// <summary>
    /// Interaction logic for SpelVy.xaml
    /// </summary>
    public partial class SpelVy : UserControl
    {
        public SpelVy()
        {
            InitializeComponent();
            Loaded += SpelVy_Loaded;
        }

        private void SpelVy_Loaded(object sender, RoutedEventArgs e)
        {
            // ItemsSource may not be set yet when Loaded fires. Use lvSpel.Items as a fallback
            // and guard against a null view to avoid NullReferenceException.
            var source = lvSpel.ItemsSource ?? lvSpel.Items;
            CollectionView view = CollectionViewSource.GetDefaultView(source) as CollectionView;

            if (view == null)
                return;

            view.SortDescriptions.Add(new SortDescription("MaxPlayers", ListSortDirection.Ascending));
        }

        private void btnRemoveGame_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);

            if (lvSpel.SelectedItem == null)
                return;
            MessageBoxResult result = MessageBox.Show("Är du säker att du vill ta bort denna medlem?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                mainWindow.AllaSpel.Remove((Spel)lvSpel.SelectedItem);
            }
        }
    }
}
