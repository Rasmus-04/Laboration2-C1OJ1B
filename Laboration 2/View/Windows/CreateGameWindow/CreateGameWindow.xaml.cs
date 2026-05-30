using Laboration_2.Model;
using Laboration_2.ViewModel;
using System.Windows;

namespace Laboration_2.View.Windows.CreateGameWindow
{
    /// <summary>
    /// Interaction logic for CreateGameWindow.xaml
    /// </summary>
    public partial class CreateGameWindow : Window
    {

        public Game CreatedGame { get; private set; }

        public CreateGameWindow(Window parentWindow)
        {
            InitializeComponent();
            Owner = parentWindow;
            CreateGameWindowViewModel viewModel = new CreateGameWindowViewModel();

            viewModel.RequestSaveAndClose += () =>
            {
                CreatedGame = viewModel.CreatedGame;
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
