using Microsoft.EntityFrameworkCore;
using WEB_API_ProductsCRUD_CodeFirst.Data;
using WEB_API_ProductsCRUD_CodeFirst.Models;

namespace WEB_API_ProductsCRUD_CodeFirst.Repository
{
    public class OrnamentRepository : IOrnamentRepository
    {
        private AppDbContext _context;
        public OrnamentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddNewOrnament(Ornament ornament)
        {
            ornament.Amount = (ornament.Weight * ornament.Price) + ornament.MakingCharges;
            _context.Ornaments.Add(ornament);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteOrnament(int id)
        {
            Ornament existing = await GetById(id);
            if (existing != null)
            {
                _context.Ornaments.Remove(existing);
            }
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePrice(int id, double price)
        {
            Ornament existing = await GetById(id);
            if (existing != null)
            {
                existing.Price = price;
                existing.Amount = existing.Weight * price + existing.MakingCharges;
            }
            await _context.SaveChangesAsync();
        }
        public async Task<Ornament> GetById(int id)
        {
            return await _context.Ornaments.FindAsync(id);
        }
        public async Task<IEnumerable<Ornament>> GetAllOrnaments()
        {
            return await _context.Ornaments.ToListAsync();
        }
        public async Task<IEnumerable<Ornament>> GetOrnamentsByMetal(string metal)
        {
            return await _context.Ornaments
                .Where(o => o.Metal == metal).
                ToListAsync();
        }
    }
}
