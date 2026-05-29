using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Laboration_2.Model
{
    public class Event : INotifyPropertyChanged
    {
        public int Id { get; }

        public string Name { get; set; }

        public DateTime EventDate { get; set; }

        public Game EventGame { get; set; }

        public int MaxParticipants { get; set; }

        public int CurrentParticipants
        {
            get { return participants.Count; }
        }

        private ObservableCollection<Member> participants = new ObservableCollection<Member>();

        public ObservableCollection<Member> Participants
        {
            get { return participants; }
        }

        public Event(
            string name,
            DateTime eventDate,
            Game eventGame,
            int maxParticipants,
            int id = 0)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Aktiviteten måste ha ett namn");

            if (maxParticipants <= 0)
                throw new Exception("Maxdeltagare måste vara större än 0");

            Id = id;
            Name = name;
            EventDate = eventDate;
            EventGame = eventGame;
            MaxParticipants = maxParticipants;
        }

        public void AddParticipant(Member memeber)
        {
            if (participants.Contains(memeber))
                throw new Exception("Medlem redan tillagd");

            if (participants.Count >= MaxParticipants)
                return;

            participants.Add(memeber);

            OnPropertyChanged(nameof(CurrentParticipants));
        }

        public void RemoveParticipant(Member member)
        {
            if (participants.Contains(member))
            {
                participants.Remove(member);

                OnPropertyChanged(nameof(CurrentParticipants));
            }
        }

        // LINQ - Sortering efter datum
        public static List<Event> SortByDate(List<Event> events)
        {
            return events
                .OrderBy(a => a.EventDate)
                .ToList();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}