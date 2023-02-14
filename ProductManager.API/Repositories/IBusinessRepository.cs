using System.Collections.Generic;
using System.Threading.Tasks;
using ProductManager.API.Models;

namespace ProductManager.API.Repositories
{
    public interface IBusinessRepository
    {
        Task<IEnumerable<Business>> ListAsync(int userId);
         Task<Business> GetUserBusinessByIdAsync(int businessId, int userId);
        Task AddAsync(Business business);
        Task<Business> FindByIdAsync(int id);
	    void Update(Business business);
        void Remove(Business business);
    }
}