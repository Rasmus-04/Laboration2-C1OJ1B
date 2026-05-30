using Laboration_2.Data;
using Laboration_2.Model;
using Microsoft.EntityFrameworkCore;

namespace Laboration_2.Service
{
    internal class MemberService
    {
        private readonly ApplicationDbContext _context;

        public MemberService()
        {
            _context = new ApplicationDbContext();
        }

        public async Task<List<Member>> GetAllAsync()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task AddAsync(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Member member)
        {
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
        }
    }
}
