using Laboration_2.Model;
using Laboration_2.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace Laboration_2.View.Windows.AddMemberToEventWindow
{
    /// <summary>
    /// Interaction logic for AddMemberToEventWindow.xaml
    /// </summary>
    public partial class AddMemberToEventWindow : Window
    {
        public AddMemberToEventWindow(Window parentWindow, Event selectedEvent, ObservableCollection<Member> medlemar)
        {
            Owner = parentWindow;
            InitializeComponent();

            AddMemberToEventWindowViewModel viewModel = new AddMemberToEventWindowViewModel(selectedEvent, medlemar);

            viewModel.RequestClose += () =>
            {
                DialogResult = false;
                Close();
            };

            DataContext = viewModel;
        }
    }
}
