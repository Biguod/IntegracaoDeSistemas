using Avaliacao1.JonStore.Domain.Models;
using Avaliacao1.JonStore.Repository.Common;
using Avaliacao1.JonStore.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Avaliacao1.JonStore.Repository.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory) { }

        public async Task<Product> GetByName(string name)
        {
            return _databaseContext.Product.Where(w => w.Name.ToLower().Contains(name.ToLower())).FirstOrDefault();
        }
    }
}
