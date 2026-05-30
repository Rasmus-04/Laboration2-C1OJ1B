using Laboration_2.Model;
using Laboration_2.MVVM;
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

        public string Titel => $"Namn: {selectedEvent.Name}";
        public string EventDate => $"Datum: {selectedEvent.EventDate}";
        public string EventGame => $"Spel: {selectedEvent.EventGame.Titel}";
        public string EventParticepents => $"Deltagare: {selectedEvent.CurrentParticipants}/{selectedEvent.MaxParticipants}";

        public ICommand RemoveMemberCommand { get; }

        public EventInfoWindowViewModel(Event selectedEvent)
        {
            this.selectedEvent = selectedEvent;
            Members = selectedEvent.Participants;
        }

        private void RemoveMember()
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
                selectedEvent.RemoveParticipant(SelectedMember);

                OnPropertyChanged(nameof(EventParticepents));
            }
        }
    }
}