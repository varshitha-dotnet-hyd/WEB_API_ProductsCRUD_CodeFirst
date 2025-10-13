using WEB_API_ProductsCRUD_CodeFirst.Models;

namespace WEB_API_ProductsCRUD_CodeFirst.Repository
{
    public interface IOrnamentRepository
    {
        Task AddNewOrnament(Ornament ornament);
        Task DeleteOrnament(int id);
        Task UpdatePrice(int id, double price);
        Task<Ornament> GetById(int id);
        Task<IEnumerable<Ornament>> GetAllOrnaments();
        Task<IEnumerable<Ornament>> GetOrnamentsByMetal(string metal);
    }
}
