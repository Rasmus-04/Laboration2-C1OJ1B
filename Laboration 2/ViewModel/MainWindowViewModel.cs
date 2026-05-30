using Laboration_2.Model;
using Laboration_2.MVVM;
using Laboration_2.Service;
using Laboration_2.View.Windows.AddMemberToEventWindow;
using Laboration_2.View.Windows.CreateEventWindow;
using Laboration_2.View.Windows.CreateGameWindow;
using Laboration_2.View.Windows.EventInfoWindow;
using Laboration_2.View.Windows.RegisterMemberWindow;
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
            _memberService = new MemberService();
            _gameService = new GameService();
            _eventService = new EventService();
            _ = LoadMembersAsync();
            _ = LoadAllGamesAsync();
            _ = LoadAllEventsAsync();
        }
        private readonly MemberService _memberService;
        private readonly GameService _gameService;
        private readonly EventService _eventService;

        private ObservableCollection<Member> members = new ObservableCollection<Member>();
        private ObservableCollection<Game> allGames = new ObservableCollection<Game>();
        private ObservableCollection<Event> allEvents = new ObservableCollection<Event>();

        public RelayCommand btnCreateMember => new RelayCommand(async execute => await CreateMember());
        public RelayCommand btnCreateGame => new RelayCommand(async execute => await CreateGame());
        public RelayCommand btnCreateEvent => new RelayCommand(async execute => await CreateEvent());
        public RelayCommand btnGenerateTestData => new RelayCommand(execute => GenerateTestData());
        public RelayCommand btnRemoveMember => new RelayCommand(async execute => await RemoveMember());
        public RelayCommand btnRemoveGame => new RelayCommand(async execute => await RemoveGame());
        public RelayCommand btnRemoveEvent => new RelayCommand(async execute => await RemoveEvent());
        public RelayCommand btnEventInfo => new RelayCommand(execute => ShowEventInfo());
        public RelayCommand btnAddMemberToEvent => new RelayCommand(execute => AddMemberToEvent());

        private Member selectedMemberItem;
        public Member SelectedMemberItem
        {
            get { return selectedMemberItem; }
            set
            {
                selectedMemberItem = value;
            }
        }
        private Game selectedGameItem;
        public Game SelectedGameItem
        {
            get { return selectedGameItem; }
            set
            {
                selectedGameItem = value;
            }
        }
        private Event selectedEventItem;
        public Event SelectedEventItem
        {
            get { return selectedEventItem; }
            set
            {
                selectedEventItem = value;
            }
        }

        public ObservableCollection<Member> Members
        {
            get { return members; }
            set { members = value; }
        }

        public ObservableCollection<Game> AllGames
        {
            get { return allGames; }
            set { allGames = value; }
        }

        public ObservableCollection<Event> AllEvents
        {
            get { return allEvents; }
            set { allEvents = value; }
        }

        private async Task CreateMember()
        {
            RegisterMemberWindow addMemberWindow = new RegisterMemberWindow(parentWindow);
            parentWindow.Opacity = .4;
            bool? result = addMemberWindow.ShowDialog();

            if (result == true)
            {
                await _memberService.AddAsync(addMemberWindow.CreatedMember);
                await LoadMembersAsync();
            }
            parentWindow.Opacity = 1;
        }

        private async Task CreateGame()
        {
            CreateGameWindow nyttSpelWindow = new CreateGameWindow(parentWindow);
            parentWindow.Opacity = .4;
            bool? result = nyttSpelWindow.ShowDialog();

            if (result == true)
            {
                await _gameService.AddAsync(nyttSpelWindow.CreatedGame);
                await LoadAllGamesAsync();
            }
            parentWindow.Opacity = 1;
        }

        private async Task CreateEvent()
        {
            CreateEventWindow NewEventWindow = new CreateEventWindow(parentWindow, AllGames);
            parentWindow.Opacity = .4;
            bool? result = NewEventWindow.ShowDialog();

            if (result == true)
            {
                await _eventService.AddEventAsync(NewEventWindow.CreatedEvent);
                await LoadAllEventsAsync();
            }
            parentWindow.Opacity = 1;
        }

        private void GenerateTestData()
        {
            TestData.GenerateAllData(Members, AllGames, AllEvents);
        }

        private async Task RemoveMember()
        {
            if (SelectedMemberItem == null)
                return;
            MessageBoxResult result = MessageBox.Show("Är du säker att du vill ta bort denna medlem?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                await _memberService.RemoveAsync(SelectedMemberItem);
                await LoadMembersAsync();
            }
        }

        private async Task RemoveGame()
        {
            if (SelectedGameItem == null)
                return;
            MessageBoxResult result = MessageBox.Show("Är du säker att du vill ta bort detta spel?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                await _gameService.RemoveAsync(SelectedGameItem);
                await LoadAllGamesAsync();
            }
        }

        private async Task RemoveEvent()
        {
            if (SelectedEventItem == null)
                return;
            MessageBoxResult result = MessageBox.Show("Är du säker att du vill ta bort denna Aktivitet?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                await _eventService.RemoveAsync(SelectedEventItem);
                await LoadAllEventsAsync();
            }
        }

        private async void ShowEventInfo()
        {
            if (SelectedEventItem == null)
                return;

            EventInfoWindow deltagareWindow = new EventInfoWindow(parentWindow, SelectedEventItem, _eventService);
            parentWindow.Opacity = .4;
            deltagareWindow.ShowDialog();
            await LoadAllEventsAsync();
            parentWindow.Opacity = 1;
        }

        private async void AddMemberToEvent()
        {
            if (SelectedEventItem == null)
                return;

            AddMemberToEventWindow deltagareWindow = new AddMemberToEventWindow(parentWindow, SelectedEventItem, Members);

            parentWindow.Opacity = .4;
            deltagareWindow.ShowDialog();
            await LoadAllEventsAsync();
            parentWindow.Opacity = 1;
        }

        public async Task LoadMembersAsync()
        {
            Members.Clear();

            var dbMembers = await _memberService.GetAllAsync();

            foreach (Member member in dbMembers)
            {
                Members.Add(member);
            }
        }
        public async Task LoadAllGamesAsync()
        {
            AllGames.Clear();

            var dbGames = await _gameService.GetAllAsync();

            foreach (Game game in dbGames)
            {
                AllGames.Add(game);
            }
        }
        public async Task LoadAllEventsAsync()
        {
            AllEvents.Clear();

            var dbEvents = await _eventService.GetAllEventsAsync(); ;

            foreach (Event dbEvent in dbEvents)
            {
                AllEvents.Add(dbEvent);
            }
        }
    }
}
