using Avaliacao1.JonStore.Domain.Contracts.Request;
using Avaliacao1.JonStore.Domain.Contracts.Response;
using Avaliacao1.JonStore.Domain.Models;

namespace Avaliacao1.JonStore.Service.Interfaces
{
    public interface IProductService
    {
        Task<GetAllProductsResponseModel> GetAllProducts();

        Task<Guid> InsertProduct(InsertProductRequestModel request);

        Task<Product> GetProductByName(string request);

        Task<bool> UpdateProduct(UpdateProductRequestModel request);

        Task<bool> DeleteProduct(Guid productId);
    }
}
