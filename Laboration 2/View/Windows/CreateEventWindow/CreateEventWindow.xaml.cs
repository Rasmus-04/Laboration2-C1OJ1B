using Laboration_2.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Xml.Linq;
using Laboration_2.ViewModel;

namespace Laboration_2.View.Windows.CreateEventWindow
{
    /// <summary>
    /// Interaction logic for CreateEventWindow.xaml
    /// </summary>
    public partial class CreateEventWindow : Window
    {
        public Event CreatedEvent { get; private set; }
        public CreateEventWindow(Window parentWindow, ObservableCollection<Game> allGames)
        {
            Owner = parentWindow;
            InitializeComponent();

            CreateEventViewModel viewModel = new CreateEventViewModel(allGames);

            viewModel.RequestSaveAndClose += () =>
            {
                CreatedEvent = viewModel.CreatedEvent;
                DialogResult = true;
                Close();
            };

            viewModel.RequestClose += () =>
            {
                DialogResult = false;
                Close();
            };
            DataContext = viewModel;
        }
    }
}
