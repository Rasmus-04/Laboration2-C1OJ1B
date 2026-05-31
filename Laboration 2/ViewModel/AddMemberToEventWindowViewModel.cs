using Laboration_2.Model;
using Laboration_2.MVVM;
using Laboration_2.Service;
using System.Collections.ObjectModel;

namespace Laboration_2.ViewModel
{
    internal class AddMemberToEventWindowViewModel : ViewModelBase
    {
        // Lista med medlemmar som inte redan är deltagare i den valda aktiviteten
        public List<Member> ValidMembers { get; set; }

        Event SelectedEvent { get; set; }

        public event Action RequestClose;
        public event Action RequestSaveAndClose;

        public string TbTitel => $"Namn: {SelectedEvent.Name}";
        public string TbDate => $"Datum: {SelectedEvent.EventDate}";
        public string TbGame => $"Spel: {SelectedEvent.EventGame.Titel}";
        public string TbParticipants => $"Deltagare: {SelectedEvent.CurrentParticipants}/{SelectedEvent.MaxParticipants}";
        public Member SelectedMember { get; set; }

        private readonly EventService _eventService;

        public AddMemberToEventWindowViewModel(Event selectedEvent, ObservableCollection<Member> members)
        {
            _eventService = new EventService();
            SelectedEvent = selectedEvent;
            ValidMembers = members.Where(m => !SelectedEvent.Participants.Any(p => p.Id == m.Id))
                .OrderBy(m => m.Name)
                .ToList();
            ValidMembers = ValidMembers.OrderBy(m => m.Name).ToList();
        }

        public RelayCommand btnAddMember => new RelayCommand(async execute => await btnAddMember_Click());
        public RelayCommand btnCloseWindow => new RelayCommand(execute => BtnCloseWindow());

        private void BtnCloseWindow()
        {
            RequestClose.Invoke();
        }

        private async Task btnAddMember_Click()
        {
            if (!(SelectedMember == null))
            {
                SelectedEvent.AddParticipant(SelectedMember);
                await _eventService.AddParticipantAsync(SelectedEvent.Id, SelectedMember.Id);
                RequestClose.Invoke();
            }
        }
    }
}
