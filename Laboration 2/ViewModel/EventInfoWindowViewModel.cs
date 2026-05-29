using Laboration_2.MVVM;
using Laboration_2.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Laboration_2.ViewModel
{
    internal class EventInfoWindowViewModel : ViewModelBase
    {
        private Event aktivitet;

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

        public string Titel => $"Namn: {aktivitet.Name}";
        public string Datum => $"Datum: {aktivitet.EventDate}";
        public string Spel => $"Spel: {aktivitet.EventGame.Titel}";
        public string Deltagare => $"Deltagare: {aktivitet.CurrentParticipants}/{aktivitet.MaxParticipants}";

        public ICommand RemoveMemberCommand { get; }

        public EventInfoWindowViewModel(Event aktivitet)
        {
            this.aktivitet = aktivitet;
            Members = aktivitet.Participants;
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
                aktivitet.RemoveParticipant(SelectedMember);

                OnPropertyChanged(nameof(Deltagare));
            }
        }
    }
}