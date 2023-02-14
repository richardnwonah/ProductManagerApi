using System.Threading.Tasks;

namespace ProductManager.API.Persistence
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}