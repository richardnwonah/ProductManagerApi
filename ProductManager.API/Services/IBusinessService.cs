
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductManager.API.Models;
using ProductManager.API.Services.Communication;

namespace ProductManager.API.Services
{
    public interface IBusinessService
    {
    Task<Business> FindByIdAsync(int id);
    Task<IEnumerable<Business>> ListAsync(string userId);
	Task<BusinessResponse> SaveAsync(Business business, string userId);
    Task<Business> GetUserBusinessByIdAsync(int businessId, string userId);
	Task<BusinessResponse> UpdateAsync(int id, Business business);
    Task<BusinessResponse> DeleteAsync(int id);
    }

 }

