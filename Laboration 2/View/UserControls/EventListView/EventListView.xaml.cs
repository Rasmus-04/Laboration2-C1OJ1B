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
    }
}
