using Avaliacao1.JonStore.Domain.Contracts.Request;
using Avaliacao1.JonStore.Domain.Contracts.Response;
using Avaliacao1.JonStore.Domain.Models;
using Avaliacao1.JonStore.Repository.Interfaces;
using Avaliacao1.JonStore.Service.Interfaces;

namespace Avaliacao1.JonStore.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> DeleteProduct(Guid productId)
        {
            var product = await _productRepository.GetOne(productId);
            if (product == null)
                return false;
            await _productRepository.Delete(product);
            return true;

        }

        public async Task<GetAllProductsResponseModel> GetAllProducts()
        {
            var products = await _productRepository.GetAll();
            if (!products.Any())
                return null;
            var response = new GetAllProductsResponseModel()
            {
                Products = products.ToList()
            };
            return response;
        }

        public async Task<Product> GetProductByName(string request)
        {
            var response = await _productRepository.GetByName(request);
            return response;
        }

        public async Task<Guid> InsertProduct(InsertProductRequestModel request)
        {
            if(request == null) throw new ArgumentNullException(nameof(request));

            if (await _productRepository.Any(a => a.Name == request.Name)) throw new ArgumentException();

            var product = new Product
            {
                Name = request.Name,
                Brand = request.Brand,
                Description = request.Description,
                Price = request.Price,
                Quantity = request.Quantity,
                Supplier = request.Supplier,
            };

            return await _productRepository.Create(product);
        }

        public Task<bool> UpdateProduct(UpdateProductRequestModel request)
        {
            var oldProduct = _productRepository.GetOne(request.Id);
            if (oldProduct != null)
            {
                var product = new Product
                {
                    Id = request.Id,
                    Name = request.Name,
                    Brand = request.Brand,
                    Description = request.Description,
                    Price = request.Price,
                    Quantity = request.Quantity,
                    Supplier = request.Supplier
                };
                _productRepository.Update(product);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
