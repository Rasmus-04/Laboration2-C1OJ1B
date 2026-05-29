using Laboration_2.Model;
using Laboration_2.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace Laboration_2.View.Windows.EventInfoWindow
{
    /// <summary>
    /// Interaction logic for DeltagareWindow.xaml
    /// </summary>
    public partial class EventInfoWindow : Window
    {
        public EventInfoWindow(Window parentWindow, Event aktivitet)
        {
            Owner = parentWindow;
            InitializeComponent();
            DataContext = new EventInfoWindowViewModel(aktivitet);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
