using Laboration_2.Model;
using Laboration_2.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

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

        public AddMemberToEventWindowViewModel(Event selectedEvent, ObservableCollection<Member> members)
        {
            SelectedEvent = selectedEvent;
            ValidMembers = members.Where(m => !SelectedEvent.Participants.Contains(m)).ToList();
            ValidMembers = ValidMembers.OrderBy(m => m.Name).ToList();
        }

        public RelayCommand btnAddMember => new RelayCommand(execute => btnAddMember_Click());
        public RelayCommand btnCloseWindow => new RelayCommand(execute => BtnCloseWindow());

        private void BtnCloseWindow()
        {
            RequestClose.Invoke();
        }

        private void btnAddMember_Click()
        {
            if (!(SelectedMember == null))
            {
                SelectedEvent.AddParticipant(SelectedMember);
                RequestClose.Invoke();
            }
        }
    }
}
