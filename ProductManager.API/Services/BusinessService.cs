using System.Collections.Generic;
using System.Threading.Tasks;
using ProductManager.API.Models;
using ProductManager.API.Repositories;
using ProductManager.API.Services;
using ProductManager.API.Services.Communication;
using ProductManager.API.Persistence;

namespace ProductManager.API.Services
{
    public class BusinessService : IBusinessService
    {
    private readonly IBusinessRepository _businessRepository;
	private readonly IUnitOfWork _unitOfWork;

	public BusinessService(IBusinessRepository businessRepository, IUnitOfWork unitOfWork)
	{
		_businessRepository = businessRepository;
		_unitOfWork = unitOfWork;
	}

    
	public async Task<IEnumerable<Business>> ListAsync(string userId)
	{
         var _userId = Int16.Parse(userId);
		return await _businessRepository.ListAsync(_userId);
	}
    public async Task<Business> GetUserBusinessByIdAsync(int businessId, string userId)
    {
        var _userId = Int16.Parse(userId);
        return await _businessRepository.GetUserBusinessByIdAsync(businessId, _userId);
    }
    public async Task<Business> FindByIdAsync(int id)
    {
        return await _businessRepository.FindByIdAsync(id);
    }
	public async Task<BusinessResponse> SaveAsync(Business Business, string userId)
	{
		try
		{
            var _userId = Int16.Parse(userId);
            Business.UserId = _userId;
			await _businessRepository.AddAsync(Business);
			await _unitOfWork.CompleteAsync();
			
			return new BusinessResponse(Business);
		}
		catch (Exception ex)
		{
			// Do some logging stuff
			return new BusinessResponse($"An error occurred when saving the Business: {ex.Message}");
		}
     }
    public async Task<BusinessResponse> UpdateAsync(int id, Business business)
    {
            var existingBusiness = await _businessRepository.FindByIdAsync(id);

            if (existingBusiness == null)
                return new BusinessResponse("Business not found.");

            existingBusiness.Name = business.Name;

            try
            {
                _businessRepository.Update(existingBusiness);
                await _unitOfWork.CompleteAsync();

                return new BusinessResponse(existingBusiness);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BusinessResponse($"An error occurred when updating the Business: {ex.Message}");
            }
    }
    public async Task<BusinessResponse> DeleteAsync(int id)
    {
            var existingBusiness = await _businessRepository.FindByIdAsync(id);

            if (existingBusiness == null)
                return new BusinessResponse("Business not found.");

            try
            {
                _businessRepository.Remove(existingBusiness);
                await _unitOfWork.CompleteAsync();

                return new BusinessResponse(existingBusiness);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BusinessResponse($"An error occurred when deleting the Business: {ex.Message}");
            }
        }
    }
}