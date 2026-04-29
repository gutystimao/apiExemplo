using apiExemplo.src.Models;
using apiExemplo.src.Requests;
using apiExemplo.src.Requests.User;
using apiExemplo.src.Response.Shared;

namespace apiExemplo.src.IHandlers
{
    public interface IUserHandler
    {
        Task<Response<PagedResponse<List<User>>>> GetAllAsync(GetAllRequest request);
        Task<Response<User?>> GetByIdAsync(GetByIdRequest request);
        Task<Response<dynamic?>> CreateAsync(CreateUserRequest request);
        Task<Response<dynamic?>> UpdateAsync(UpdateUserRequest request);
        Task<Response<dynamic?>> DeleteAsync(DeleteRequest request);
    }
}