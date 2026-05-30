using Laboration_2.Data;
using Laboration_2.Model;
using Microsoft.EntityFrameworkCore;

namespace Laboration_2.Service
{
    public class GameService
    {
        private readonly ApplicationDbContext _context;

        public GameService()
        {
            _context = new ApplicationDbContext();
        }

        public async Task<List<Game>> GetAllAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task AddAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Game game)
        {
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
        }
    }
}
