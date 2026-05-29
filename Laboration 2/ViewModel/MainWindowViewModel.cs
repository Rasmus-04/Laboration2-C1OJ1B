using Laboration_2.Model;
using Laboration_2.MVVM;
using Laboration_2.View.Windows.CreateEventWindow;
using Laboration_2.View.Windows.CreateGameWindow;
using Laboration_2.View.Windows.EventInfoWindow;
using Laboration_2.View.Windows.RegisterMemberWindow;
using Laboration_2.View.Windows.AddMemberToEventWindow;
using System.Collections.ObjectModel;
using System.Windows;

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
        public RelayCommand btnRemoveMember => new RelayCommand(execute => RemoveMember());
        public RelayCommand btnRemoveGame => new RelayCommand(execute => RemoveGame());
        public RelayCommand btnRemoveEvent => new RelayCommand(execute => RemoveEvent());
        public RelayCommand btnEventInfo => new RelayCommand(execute => ShowEventInfo());
        public RelayCommand btnAddMemberToEvent => new RelayCommand(execute => AddMemberToEvent());

        private Medlem selectedMemberItem;
        public Medlem SelectedMemberItem
        {
            get { return selectedMemberItem; }
            set
            {
                selectedMemberItem = value;
            }
        }
        private Spel selectedGameItem;
        public Spel SelectedGameItem
        {
            get { return selectedGameItem; }
            set
            {
                selectedGameItem = value;
            }
        }
        private Aktivitet selectedEventItem;
        public Aktivitet SelectedEventItem
        {
            get { return selectedEventItem; }
            set
            {
                selectedEventItem = value;
            }
        }

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


        private void RemoveMember()
        {
            if (SelectedMemberItem == null)
                return;
            MessageBoxResult result = MessageBox.Show("Är du säker att du vill ta bort denna medlem?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Members.Remove(SelectedMemberItem);
            }
        }

        private void RemoveGame()
        {
            if (SelectedGameItem == null)
                return;
            MessageBoxResult result = MessageBox.Show("Är du säker att du vill ta bort detta spel?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                AllaSpel.Remove(SelectedGameItem);
            }
        }

        private void RemoveEvent()
        {
            if (SelectedEventItem == null)
                return;
            MessageBoxResult result = MessageBox.Show("Är du säker att du vill ta bort denna Aktivitet?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                AllaAktiviteter.Remove(SelectedEventItem);
            }
        }

        private void ShowEventInfo()
        {
            if (SelectedEventItem == null)
                return;

            EventInfoWindow deltagareWindow = new EventInfoWindow(parentWindow, SelectedEventItem);
            parentWindow.Opacity = .4;
            deltagareWindow.ShowDialog();
            parentWindow.Opacity = 1;
        }

        private void AddMemberToEvent()
        {
            if (SelectedEventItem == null)
                return;

            AddMemberToEventWindow deltagareWindow = new AddMemberToEventWindow(parentWindow, SelectedEventItem, Members);

            parentWindow.Opacity = .4;
            deltagareWindow.ShowDialog();
            parentWindow.Opacity = 1;
        }
    }
}
