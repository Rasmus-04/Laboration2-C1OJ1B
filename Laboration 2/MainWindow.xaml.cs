using Laboration_2.ViewModel;
using System.Windows;

namespace Laboration_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel viewModel = new MainWindowViewModel(Window.GetWindow(this));
            DataContext = viewModel;
            Loaded += async (_, _) =>
            {
                if (DataContext is MainWindowViewModel vm)
                {
                    await vm.InitializeLoadData();
                }
            };

        }
    }
}