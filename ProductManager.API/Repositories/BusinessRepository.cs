using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManager.API.Models;
using ProductManager.API.Repositories;
using ProductManager.API.Data;

namespace ProductManager.API.Repositories
{
    public class BusinessRepository : BaseRepository, IBusinessRepository
    {
        public BusinessRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Business>> ListAsync(int userId)
        {
            return await _context.Businesses.Where(x => x.UserId == userId).ToListAsync();
        }
        public async Task AddAsync(Business business)
        {
            await _context.Businesses.AddAsync(business);
        }
        public async Task<Business> FindByIdAsync(int id)
        {
            return await _context.Businesses.FindAsync(id);
        }
        public async Task<Business> GetUserBusinessByIdAsync(int businessId, int userId)
        {
            return await _context.Businesses.Where(x => x.Id == businessId && x.UserId == userId).FirstAsync();
        }

        public void Update(Business business)
        {
            _context.Businesses.Update(business);
        }
        public void Remove(Business business)
        {
            _context.Businesses.Remove(business);
        }
    }
}