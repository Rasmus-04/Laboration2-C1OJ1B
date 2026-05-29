using Laboration_2.Model;
using Laboration_2.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Xml.Linq;

namespace Laboration_2.ViewModel
{
    internal class RegisterMemberWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Member> members;
        public event Action RequestClose;
        public event Action RequestSaveAndClose;
        public RegisterMemberWindowViewModel(ObservableCollection<Member> members)
        {
            this.members = members;
        }

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
            int validAge;
            if (string.IsNullOrEmpty(Name))
                MessageBox.Show("Namn måste vara ifyllt.", "Felaktigt namn", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (!int.TryParse(Age, out validAge))
                MessageBox.Show("Ålder måste vara ifylld.", "Felaktig ålder", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (string.IsNullOrEmpty(Email))
                MessageBox.Show("Epost måste vara ifylld.", "Felaktigt Epost", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                CreatedMember = new Member(validAge, Name, Email);
                RequestSaveAndClose?.Invoke();
            }
        }

        private void BtnCloseWindow()
        {
            RequestClose?.Invoke();
        }
    }
}
