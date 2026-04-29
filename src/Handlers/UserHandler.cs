using System.Linq.Expressions;
using System.Text;
using apiExemplo.src.Data;
using apiExemplo.src.Helpers;
using apiExemplo.src.IHandlers;
using apiExemplo.src.Models;
using apiExemplo.src.Requests;
using apiExemplo.src.Requests.User;
using apiExemplo.src.Response.Shared;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace apiExemplo.src.Handlers
{
    public class UserHandler(AppDbContext context) : IUserHandler
    {
        public async Task<Response<PagedResponse<List<User>>>> GetAllAsync(GetAllRequest request)
        {
            List<User>? list = await context.Usuarios.Find(x => !x.Deletedo).ToListAsync();
            PagedResponse<List<User>> response = new(list, 20, 1, 20);
            return new(response, 200, string.Empty, null);
        }

        public async Task<Response<User?>> GetByIdAsync(GetByIdRequest request)
        {
            var usuario = await context.Usuarios.Find(x => x.Id == request.Id).FirstOrDefaultAsync();
            Console.WriteLine(JsonConvert.SerializeObject(usuario, Formatting.Indented));
            if (usuario == null)
            {
                return new Response<User?>(null, 404, "Usuário não encontrado", null);
            }
            return new(usuario);

            // var usuario = await context.Usuarios.Find(x => x.Id == request.Id).FirstOrDefaultAsync();
            // return new(usuario);
            // throw new NotImplementedException();
        }

        public async Task<Response<dynamic?>> CreateAsync(CreateUserRequest request)
        {
            //CONSOLE LOG DOS CAMPOS
            Console.WriteLine(request.Nome);
            Console.WriteLine(request.Email);
            Console.WriteLine(request.DataNascimento.ToString());
            Console.WriteLine(request.Idade);
            Console.WriteLine(request.Cidade);
            Console.WriteLine(request.Estado);
            Console.WriteLine(request.Permissoes);
            Console.WriteLine(request.Ativo);

            //CRIAR OBJETO USUARIO
            User usuario = new()
            {
                Nome = request.Nome,
                Email = request.Email,
                // DataNascimento = request.DataNascimento,
                Cidade = request.Cidade,
                Estado = request.Estado,
                Idade = request.Idade,
                Permissoes = request.Permissoes,
                Ativo = request.Ativo,
                DataCadastro = DateTime.Now
            };

            Console.WriteLine(JsonConvert.SerializeObject(usuario, Formatting.Indented));
            await context.Usuarios.InsertOneAsync(usuario);
            return new(usuario, 201, "Usuario Cadastrado");
        }

        public async Task<Response<dynamic?>> UpdateAsync(UpdateUserRequest request)
        {
            try
            {
                Console.WriteLine(JsonConvert.SerializeObject(request, Formatting.Indented));
                User usuario = await context.Usuarios.Find(x => x.Id == request.Id).FirstOrDefaultAsync();
                if (usuario is null) return new(data: null, code: 404, message: "Usuario não encontrado");

                usuario.Nome = request.Nome;
                usuario.Email = request.Email;
                usuario.DataNascimento = request.DataNascimento;
                usuario.Cidade = request.Cidade;
                usuario.Estado = request.Estado;
                usuario.Idade = request.Idade;
                usuario.Permissoes = request.Permissoes;
                usuario.Ativo = request.Ativo;

                // Expression<Func<User,bool>> filter = x => x.Id.Equals(usuario.Id);
                await context.Usuarios.ReplaceOneAsync(x => x.Id == usuario.Id, usuario);

                return new(usuario, 200, "Usuario atualizado com sucesso");
            }
            catch
            {
                return new(data: null, code: 500, message: "Falha ao atualizar Usuario");
            }
        }
        public async Task<Response<dynamic?>> DeleteAsync(DeleteRequest request)
        {
            try
            {
                Console.WriteLine(JsonConvert.SerializeObject(request, Formatting.Indented));
                var usuario = await context.Usuarios.Find(x => x.Id == request.Id).FirstOrDefaultAsync();
                if (usuario is null) return new(data: null, code: 404, message: "Usuario não encontrado");

                // Expression<Func<User, bool>> filter = x => x.Id.Equals(usuario.Id);
                await context.Usuarios.DeleteOneAsync(x => x.Id == usuario.Id);

                return new Response<dynamic?>(usuario, 200, "Usuario excluído com sucesso");
            }
            catch
            {
                return new(data: null, code: 500, message: "Falha ao excluir usuario");
            }
        }
        // public Task<Response<dynamic?>> DeleteAsync(DeleteRequest request)
        // {
        //     throw new NotImplementedException();
        // }
    }
}