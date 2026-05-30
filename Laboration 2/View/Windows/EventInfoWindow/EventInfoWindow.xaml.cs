using Laboration_2.Model;
using Laboration_2.ViewModel;
using System.Windows;
using Laboration_2.Service;

namespace Laboration_2.View.Windows.EventInfoWindow
{
    /// <summary>
    /// Interaction logic for DeltagareWindow.xaml
    /// </summary>
    public partial class EventInfoWindow : Window
    {
        public EventInfoWindow(Window parentWindow, Event aktivitet, EventService eventService)
        {
            Owner = parentWindow;
            InitializeComponent();
            DataContext = new EventInfoWindowViewModel(aktivitet, eventService);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
