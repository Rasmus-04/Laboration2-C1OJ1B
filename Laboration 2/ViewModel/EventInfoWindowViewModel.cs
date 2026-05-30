using Laboration_2.Model;
using Laboration_2.MVVM;
using Laboration_2.Service;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Laboration_2.ViewModel
{
    internal class EventInfoWindowViewModel : ViewModelBase
    {
        private Event selectedEvent;

        public ObservableCollection<Member> Members { get; }
        public RelayCommand btnRemoveMemberFromEvent => new RelayCommand(execute => RemoveMember());


        private Member selectedMember;
        public Member SelectedMember
        {
            get => selectedMember;
            set
            {
                selectedMember = value;
            }
        }
        private readonly EventService _eventService;
        public string Titel => $"Namn: {selectedEvent.Name}";
        public string EventDate => $"Datum: {selectedEvent.EventDate}";
        public string EventGame => $"Spel: {selectedEvent.EventGame.Titel}";
        public string EventParticepents => $"Deltagare: {selectedEvent.CurrentParticipants}/{selectedEvent.MaxParticipants}";

        public ICommand RemoveMemberCommand { get; }

        public EventInfoWindowViewModel(Event selectedEvent, EventService eventService)
        {
            this.selectedEvent = selectedEvent;
            Members = new ObservableCollection<Member>(selectedEvent.Participants);
            _eventService = eventService;
        }

        private async void RemoveMember()
        {
            if (SelectedMember == null)
                return;

            MessageBoxResult result = MessageBox.Show(
                "Är du säker att du vill ta bort deltagaren?",
                "Bekräfta borttagning",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                await _eventService.RemoveParticipantAsync(selectedEvent.Id, SelectedMember.Id);

                selectedEvent.RemoveParticipant(SelectedMember);
                RefreshMembers();

                OnPropertyChanged(nameof(EventParticepents));
            }
        }

        private void RefreshMembers()
        {
            Members.Clear();

            foreach (var member in selectedEvent.Participants)
            {
                Members.Add(member);
            }
        }
    }
}