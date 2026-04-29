using apiExemplo.src.Models;
using apiExemplo.src.Requests;
using apiExemplo.src.Requests.Cliente;
using apiExemplo.src.Requests.User;
using apiExemplo.src.Response.Shared;

namespace apiExemplo.src.IHandlers
{
    public interface IClienteHandler
    {
        Task<Response<PagedResponse<List<Cliente>>>> GetAllAsync(GetAllRequest request);
        Task<Response<Cliente?>> GetByIdAsync(GetByIdRequest request);
        Task<Response<dynamic?>> CreateAsync(CreateClienteRequest request);
        Task<Response<dynamic?>> UpdateAsync(UpdateClienteRequest request);
        Task<Response<dynamic?>> DeleteAsync(DeleteRequest request);
    }
}