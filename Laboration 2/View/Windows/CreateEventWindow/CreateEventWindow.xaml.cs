using Laboration_2.Model;
using Laboration_2.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;

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

        public CreateEventWindow(Window parentWindow, ObservableCollection<Game> allGames, Event eventToEdit)
        {
            InitializeComponent();
            Owner = parentWindow;

            CreateEventViewModel viewModel = new CreateEventViewModel(allGames, eventToEdit);

            viewModel.RequestSaveAndClose += () =>
            {
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
