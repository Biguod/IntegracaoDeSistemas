using Avaliacao1.JonStore.Domain.Contracts.Request;
using Avaliacao1.JonStore.Service.Interfaces;

namespace Avaliacao1.Endpoints
{
    public static class JonStoreEndpoints
    {
        public static void AddJonStoreEndpoints(this WebApplication app)
        {
            app.AddGetListProducts();
            app.AddGetProductByName();
            app.AddPostInsertProduct();
            app.AddPutUpdateProduct();
            app.AddDeleteProduct();
        }

        private static void AddGetListProducts(this WebApplication app)
        {
            app.MapGet("/api/listproducts", async (IProductService service) =>
            {
                try
                {
                    var results = await service.GetAllProducts();
                    if (results == null)
                        return Results.NotFound();
                    return Results.Ok(results);

                }
                catch (Exception ex)
                {

                    return Results.Problem(detail: "Internal Error", statusCode: 500);
                }
            });
        }

        private static void AddGetProductByName(this WebApplication app)
        {
            app.MapGet("/api/searchproduct", async (IProductService service, string request) =>
            {
                try
                {
                    var result = await service.GetProductByName(request);
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(detail: "Internal Error", statusCode: 500);
                }
            });
        }

        private static void AddPostInsertProduct(this WebApplication app)
        {
            app.MapPost("/api/insertproduct", async (IProductService service, InsertProductRequestModel request) =>
            {
                try
                {
                    var result = await service.InsertProduct(request);
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(detail: "Internal Error", statusCode: 500);
                }
            });
        }

        private static void AddPutUpdateProduct(this WebApplication app)
        {
            app.MapPut("/api/updateproduct", async (IProductService service, UpdateProductRequestModel request) =>
            {
                try
                {
                    var result = await service.UpdateProduct(request);
                    if (!result)
                    {
                        return Results.Problem("Couldn't update Product properly");
                    }
                    return Results.Ok("Product Updated!");
                }
                catch (Exception ex)
                {
                    return Results.Problem(detail: "Internal Error", statusCode: 500);
                }
            });
        }

        private static void AddDeleteProduct(this WebApplication app)
        {
            app.MapDelete("/api/deleteproduct", async (IProductService service, Guid request) =>
            {
                try
                {
                    var result = await service.DeleteProduct(request);
                    if (!result)
                    {
                        return Results.Problem("Couldn't delete Product!");
                    }
                    return Results.Ok("Product Deleted!");
                }
                catch (Exception ex)
                {
                    return Results.Problem(detail: "Internal Error", statusCode: 500);
                }
            });
        }
    }
}
