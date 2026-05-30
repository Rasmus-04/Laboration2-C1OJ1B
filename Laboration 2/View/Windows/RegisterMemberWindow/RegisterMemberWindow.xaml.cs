using Laboration_2.Model;
using Laboration_2.ViewModel;
using System.Windows;

namespace Laboration_2.View.Windows.RegisterMemberWindow
{
    /// <summary>
    /// Interaction logic for RegisterMemberWindow.xaml
    /// </summary>
    public partial class RegisterMemberWindow : Window
    {

        public Member CreatedMember { get; private set; }

        public RegisterMemberWindow(Window parentWindow)
        {
            InitializeComponent();
            Owner = parentWindow;

            RegisterMemberWindowViewModel viewModel = new RegisterMemberWindowViewModel();

            viewModel.RequestSaveAndClose += () =>
            {
                CreatedMember = viewModel.CreatedMember;
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
