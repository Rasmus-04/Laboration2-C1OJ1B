using Laboration_2.Model;
using Laboration_2.MVVM;
using System.Collections.ObjectModel;
using System.Windows;
using Laboration_2.View.Windows.RegisterMemberWindow;
using Laboration_2.View.Windows.CreateGameWindow;
using Laboration_2.View.Windows.CreateEventWindow;

namespace Laboration_2.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private Window parentWindow;
        public MainWindowViewModel(Window parentWindow)
        {
            this.parentWindow = parentWindow;
        }

        private ObservableCollection<Medlem> members = new ObservableCollection<Medlem>();
        private ObservableCollection<Spel> allaSpel = new ObservableCollection<Spel>();
        private ObservableCollection<Aktivitet> allaAktiviteter = new ObservableCollection<Aktivitet>();

        public RelayCommand btnCreateMember => new RelayCommand(execute => CreateMember());
        public RelayCommand btnCreateGame => new RelayCommand(execute => CreateGame());
        public RelayCommand btnCreateEvent => new RelayCommand(execute => CreateEvent());
        public RelayCommand btnGenerateTestData => new RelayCommand(execute => GenerateTestData());


        public ObservableCollection<Medlem> Members
        {
            get { return members; }
            set { members = value; }
        }

        public ObservableCollection<Spel> AllaSpel
        {
            get { return allaSpel; }
            set { allaSpel = value; }
        }

        public ObservableCollection<Aktivitet> AllaAktiviteter
        {
            get { return allaAktiviteter; }
            set { allaAktiviteter = value; }
        }

        private void CreateMember()
        {
            RegisterMemberWindow addMemberWindow = new RegisterMemberWindow(parentWindow);
            parentWindow.Opacity = .4;
            bool? result = addMemberWindow.ShowDialog();

            if (result == true)
            {
                Members.Add(addMemberWindow.CreatedMember);
            }
            parentWindow.Opacity = 1;
        }

        private void CreateGame()
        {
            CreateGameWindow nyttSpelWindow = new CreateGameWindow(parentWindow);
            parentWindow.Opacity = .4;
            bool? result = nyttSpelWindow.ShowDialog();

            if (result == true)
            {
                AllaSpel.Add(nyttSpelWindow.CreatedSpel);
            }
            parentWindow.Opacity = 1;
        }

        private void CreateEvent()
        {
            CreateEventWindow NyttEventWindow = new CreateEventWindow(parentWindow, AllaSpel);
            parentWindow.Opacity = .4;
            bool? result = NyttEventWindow.ShowDialog();

            if (result == true)
            {
                AllaAktiviteter.Add(NyttEventWindow.CreatedEvent);
            }
            parentWindow.Opacity = 1;
        }

        private void GenerateTestData()
        {
            TestData.GenerateAllData(Members, AllaSpel, AllaAktiviteter);
        }
    }
}
