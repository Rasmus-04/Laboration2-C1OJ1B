using Laboration_2.Data;
using Laboration_2.Model;
using Microsoft.EntityFrameworkCore;

namespace Laboration_2.Service
{
    public class EventService : Repository<Event>
    {
        public async Task AddEventAsync(Event eventToAdd)
        {
            eventToAdd.EventGame = null;

            _context.Events.Add(eventToAdd);

            await _context.SaveChangesAsync();
        }

        public async Task AddParticipantAsync(int eventId, int memberId)
        {
            var exists = await _context.EventMembers
                .AnyAsync(em =>
                    em.EventId == eventId &&
                    em.MemberId == memberId);

            if (exists)
                return;

            _context.EventMembers.Add(new EventMember
            {
                EventId = eventId,
                MemberId = memberId
            });

            await _context.SaveChangesAsync();
        }

        public async Task RemoveParticipantAsync(int eventId, int memberId)
        {
            var eventMember = await _context.EventMembers.FirstOrDefaultAsync(em => em.EventId == eventId && em.MemberId == memberId);

            if (eventMember != null)
            {
                _context.EventMembers.Remove(eventMember);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await _context.Events
                .AsNoTracking()
                .Include(e => e.EventGame)
                .Include(e => e.EventMembers)
                .ThenInclude(em => em.Member)
                .ToListAsync();
        }

        public async Task UpdateEventAsync(Event updatedEvent)
        {
            var dbEvent = await _context.Events
                .FirstAsync(e => e.Id == updatedEvent.Id);

            dbEvent.Name = updatedEvent.Name;
            dbEvent.EventDate = updatedEvent.EventDate;
            dbEvent.GameId = updatedEvent.GameId;
            dbEvent.MaxParticipants = updatedEvent.MaxParticipants;

            await _context.SaveChangesAsync();
        }
    }
}