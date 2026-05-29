using Laboration_2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboration_2.View.UserControls.GameListView
{
    /// <summary>
    /// Interaction logic for GameListView.xaml
    /// </summary>
    public partial class GameListView : UserControl
    {
        public GameListView()
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
    }
}
