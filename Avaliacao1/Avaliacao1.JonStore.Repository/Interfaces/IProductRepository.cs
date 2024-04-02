using Avaliacao1.JonStore.Domain.Models;

namespace Avaliacao1.JonStore.Repository.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> GetByName(string name);
    }
}
