using System.Linq.Expressions;
using System.Net.Quic;
using System.Text;
using apiExemplo.src.Data;
using apiExemplo.src.Helpers;
using apiExemplo.src.IHandlers;
using apiExemplo.src.Models;
using apiExemplo.src.Requests;
using apiExemplo.src.Requests.Cliente;
using apiExemplo.src.Requests.User;
using apiExemplo.src.Response.Shared;
using Microsoft.AspNetCore.Http.Timeouts;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace apiExemplo.src.Handlers
{
    public class ClienteHandler(AppDbContext context) : IClienteHandler
    {
        public async Task<Response<PagedResponse<List<Cliente>>>> GetAllAsync(GetAllRequest request)
        {
            List<Cliente>? list = await context.Clientes.Find(x => !x.Deletedo).ToListAsync();
            PagedResponse<List<Cliente>> response = new(list, 20, 1, 20);
            return new(response, 200, string.Empty, null);
        }

        public async Task<Response<Cliente?>> GetByIdAsync(GetByIdRequest request)
        {
            var cliente = await context.Clientes.Find(x => x.Id == request.Id).FirstOrDefaultAsync();
            Console.WriteLine(JsonConvert.SerializeObject(cliente, Formatting.Indented));
            if (cliente == null)
            {
                return new Response<Cliente?>(null, 404, "Cliente não encontrado", null);
            }
            return new(cliente);
        }

        public async Task<Response<dynamic?>> CreateAsync(CreateClienteRequest request)
        {
            //CONSOLE LOG DOS CAMPOS
            Console.WriteLine(request.RazaoSocial);
            Console.WriteLine(request.NomeFantasia);
            Console.WriteLine(request.Cnpj);
            Console.WriteLine(request.Logradouro);
            Console.WriteLine(request.Numero);
            Console.WriteLine(request.Bairro);
            Console.WriteLine(request.Cidade);
            Console.WriteLine(request.UF);
            Console.WriteLine(request.CEP);
            Console.WriteLine(request.ValorCredito);
            Console.WriteLine(request.QuantidadeFuncionarios);
            Console.WriteLine(request.DataCliente);
            Console.WriteLine(request.Ativo);
            Console.WriteLine(request.DataCadastro);
            Console.WriteLine(request.Deletado);

            //CRIAR OBJETO USUARIO
            Cliente cliente = new()
            {
                Id = request.ClienteId,
                RazaoSocial = request.RazaoSocial,
                NomeFantasia = request.NomeFantasia,
                Cnpj = request.Cnpj,
                Logradouro = request.Logradouro,
                Numero = request.Numero,
                Bairro = request.Bairro,
                Cidade = request.Cidade,
                Uf = request.UF,
                Cep = request.CEP,
                ValorCredito = request.ValorCredito,
                QuantidadeFuncionarios = request.QuantidadeFuncionarios,
                DataCliente = request.DataCliente,
                Ativo = request.Ativo,
                DataCadastro = DateTime.Now,
                Deletedo = request.Deletado,
            };

            Console.WriteLine(JsonConvert.SerializeObject(cliente, Formatting.Indented));
            await context.Clientes.InsertOneAsync(cliente);
            return new(cliente, 201, "Cliente Cadastrado");
        }

        public async Task<Response<dynamic?>> UpdateAsync(UpdateClienteRequest request)
        {
            try
            {
                Console.WriteLine(JsonConvert.SerializeObject(request, Formatting.Indented));
                Cliente cliente = await context.Clientes.Find(x => x.Id == request.Id).FirstOrDefaultAsync();
                if (cliente is null) return new(data: null, code: 404, message: "Usuario não encontrado");

                cliente.RazaoSocial = request.RazaoSocial;
                cliente.NomeFantasia = request.NomeFantasia;
                cliente.Cnpj = request.Cnpj;
                cliente.Logradouro = request.Logradouro;
                cliente.Numero = request.Numero;
                cliente.Bairro = request.Bairro;
                cliente.Cidade = request.Cidade;
                cliente.Uf  = request.UF;
                cliente.Cep = request.CEP;
                cliente.ValorCredito = request.ValorCredito;
                cliente.QuantidadeFuncionarios = request.QuantidadeFuncionarios;
                cliente.DataCliente = request.DataCliente;
                cliente.Ativo = request.Ativo;
                cliente.DataCadastro = DateTime.Now;
                cliente.Deletedo = request.Deletado;

              //  Expression<Func<Cliente, bool>> filter = x => x.Id.Equals(cliente.Id);
                await context.Clientes.ReplaceOneAsync(x => x.Id == cliente.Id, cliente);

                return new(cliente, 200, "Cliente atualizado com sucesso");
            }
            catch
            {
                return new(data: null, code: 500, message: "Falha ao atualizar Cliente");
            }
        }
        public async Task<Response<dynamic?>> DeleteAsync(DeleteRequest request)
        {
            try
            {
                Console.WriteLine(JsonConvert.SerializeObject(request, Formatting.Indented));
                var cliente = await context.Clientes.Find(x => x.Id == request.Id).FirstOrDefaultAsync();
                if (cliente is null) return new(data: null, code: 404, message: "Usuario não encontrado");

                // Expression<Func<User, bool>> filter = x => x.Id.Equals(usuario.Id);
                await context.Clientes.DeleteOneAsync(x => x.Id == cliente.Id);

                return new Response<dynamic?>(cliente, 200, "Cliente excluído com sucesso");
            }
            catch
            {
                return new(data: null, code: 500, message: "Falha ao excluir cliente");
            }
        }
    }
}