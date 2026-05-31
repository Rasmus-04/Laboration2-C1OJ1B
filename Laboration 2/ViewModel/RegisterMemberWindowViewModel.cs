using Laboration_2.Model;
using Laboration_2.MVVM;
using System.Windows;

namespace Laboration_2.ViewModel
{
    internal class RegisterMemberWindowViewModel : ViewModelBase
    {

        public RegisterMemberWindowViewModel()
        {
        }
        public RegisterMemberWindowViewModel(Member member)
        {
            _memberToEdit = member;

            Name = member.Name;
            Email = member.Email;
            Age = member.Age.ToString();

            ButtonText = "Spara";
        }
        public event Action RequestClose;
        public event Action RequestSaveAndClose;

        private Member? _memberToEdit;
        public string ButtonText { get; set; } = "Lägg till";

        public Member CreatedMember { get; private set; }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private string age;
        public string Age
        {
            get => age;
            set
            {
                age = value;
                OnPropertyChanged();
            }
        }

        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand btnAddUserCommand => new RelayCommand(execute => AddUserBtn_Click());
        public RelayCommand btnCloseWindow => new RelayCommand(execute => BtnCloseWindow());

        private void AddUserBtn_Click()
        {
            try
            {
                if (_memberToEdit != null)
                {
                    _memberToEdit.Name = Name;
                    _memberToEdit.Email = Email;
                    _memberToEdit.Age = int.Parse(Age);

                    RequestSaveAndClose?.Invoke();
                }
                else
                {
                    CreatedMember = new Member(int.Parse(Age),Name,Email);

                    RequestSaveAndClose?.Invoke();
                }
            }
            catch(Exception ex) when(
                ex is FormatException ||
                ex is ArgumentException)
            {
                MessageBox.Show("Ålder måste vara ett giltigt heltal.", "Felaktig ålder", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void BtnCloseWindow()
        {
            RequestClose?.Invoke();
        }
    }
}
