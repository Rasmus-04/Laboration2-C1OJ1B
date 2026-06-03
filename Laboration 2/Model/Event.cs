using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Laboration_2.Model
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public Game EventGame { get; set; }
        public int GameId { get; set; }

        public int MaxParticipants { get; set; }
        public ObservableCollection<EventMember> EventMembers { get; set; } = new();
        public bool IsFull
        {
            get
            {
                return EventMembers.Count >= MaxParticipants;
            }
        }
        public int CurrentParticipants
        {
            get { return EventMembers.Count(); }
        }
        public IEnumerable<Member> Participants => EventMembers.Select(em => em.Member);

        public Event()
        {
        }
        public Event(
            string name,
            DateTime eventDate,
            Game eventGame,
            int maxParticipants)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Aktiviteten måste ha ett namn");

            if (maxParticipants <= 0)
                throw new Exception("Maxdeltagare måste vara större än 0");

            Name = name;
            EventDate = eventDate;
            EventGame = eventGame;
            GameId = eventGame.Id;
            MaxParticipants = maxParticipants;
        }

        public void AddParticipant(Member memeber)
        {
            if (Participants.Contains(memeber))
                throw new Exception("Medlem redan tillagd");

            if (Participants.Count() >= MaxParticipants)
                return;
        }

        public void RemoveParticipant(Member member)
        {
            EventMember? eventMember = EventMembers.FirstOrDefault(em => em.MemberId == member.Id);

            if (eventMember != null)
            {
                EventMembers.Remove(eventMember);
            }
        }

        // LINQ - Sortering efter datum
        public static List<Event> SortByDate(List<Event> events)
        {
            return events
                .OrderBy(a => a.EventDate)
                .ToList();
        }
    }
}