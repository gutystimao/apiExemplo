using apiExemplo.src.Models;
using apiExemplo.src.Requests;
using apiExemplo.src.Requests.Product;
using apiExemplo.src.Requests.Products;
using apiExemplo.src.Response.Shared;

namespace apiExemplo.src.IHandlers
{
    public interface IProductHandler
    {
        Task<Response<PagedResponse<List<Product>>>> GetAllAsync(GetAllRequest request);
        Task<Response<Product?>> GetByIdAsync(GetByIdRequest request);
        Task<Response<dynamic?>> CreateAsync(CreateProductRequest request);
        Task<Response<dynamic?>> UpdateAsync(UpdateProductRequest request);
        Task<Response<dynamic?>> DeleteAsync(DeleteRequest request);
    }
}