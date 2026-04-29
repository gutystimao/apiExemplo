using System.Linq.Expressions;
using System.Net.Quic;
using System.Text;
using apiExemplo.src.Data;
using apiExemplo.src.Helpers;
using apiExemplo.src.IHandlers;
using apiExemplo.src.Models;
using apiExemplo.src.Requests;
using apiExemplo.src.Requests.Product;
using apiExemplo.src.Requests.Products;
using apiExemplo.src.Response.Shared;
using Microsoft.AspNetCore.Http.Timeouts;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace apiExemplo.src.Handlers
{
    public class ProductHandler(AppDbContext context) : IProductHandler
    {
        public async Task<Response<PagedResponse<List<Product>>>> GetAllAsync(GetAllRequest request)
        {
            List<Product>? list = await context.Products.Find(x => !x.Deletedo).ToListAsync();
            PagedResponse<List<Product>> response = new(list, 20, 1, 20);
            return new(response, 200, string.Empty, null);
        }

        public async Task<Response<Product?>> GetByIdAsync(GetByIdRequest request)
        {
            var product = await context.Products.Find(x => x.Id == request.Id).FirstOrDefaultAsync();
            Console.WriteLine(JsonConvert.SerializeObject(product, Formatting.Indented));
            if (product == null)
            {
                return new Response<Product?>(null, 404, "Produto não encontrado", null);
            }
            return new(product);
        }

        public async Task<Response<dynamic?>> CreateAsync(CreateProductRequest request)
        {
            //CONSOLE LOG DOS CAMPOS
            Console.WriteLine(request.Code);
            Console.WriteLine(request.Type);
            Console.WriteLine(request.UnitOfMeasure);
            Console.WriteLine(request.Description);
            Console.WriteLine(request.Price);
            Console.WriteLine(request.Warehouse);
            Console.WriteLine(request.StockQuantity);
            Console.WriteLine(request.Batch);
            Console.WriteLine(request.ExpirationDate);
            Console.WriteLine(request.Status);
            Console.WriteLine(request.Image);

            //CRIAR OBJETO
            Product product = new()
            {
                Id = request.ProductId,
                Code = request.Code,
                Type = request.Type,
                UnitOfMeasure = request.UnitOfMeasure,
                Description = request.Description,
                Price = request.Price,
                Warehouse = request.Warehouse,
                StockQuantity = request.StockQuantity,
                Batch = request.Batch,
                ExpirationDate = request.ExpirationDate,
                Ativo = request.Status,
                Image = request.Image,
            };

            Console.WriteLine(JsonConvert.SerializeObject(product, Formatting.Indented));
            await context.Products.InsertOneAsync(product);
            return new(product, 201, "Produto Cadastrado");
        }

        public async Task<Response<dynamic?>> UpdateAsync(UpdateProductRequest request)
        {
            try
            {
                Console.WriteLine(JsonConvert.SerializeObject(request, Formatting.Indented));
                Product product = await context.Products.Find(x => x.Id == request.Id).FirstOrDefaultAsync();
                if (product is null) return new(data: null, code: 404, message: "Produto não encontrado");

                product.Code = request.Code;
                product.Type = request.Type;
                product.UnitOfMeasure = request.UnitOfMeasure;
                product.Description = request.Description;
                product.Price = request.Price;
                product.Warehouse = request.Warehouse;
                product.StockQuantity = request.StockQuantity;
                product.Batch = request.Batch;
                product.ExpirationDate = request.ExpirationDate;
                product.Ativo = request.Status;
                product.Image = request.Image;

              //  Expression<Func<Cliente, bool>> filter = x => x.Id.Equals(cliente.Id);
                await context.Products.ReplaceOneAsync(x => x.Id == product.Id, product);

                return new(product, 200, "Produto atualizado com sucesso");
            }
            catch
            {
                return new(data: null, code: 500, message: "Falha ao atualizar Produto");
            }
        }
        public async Task<Response<dynamic?>> DeleteAsync(DeleteRequest request)
        {
            try
            {
                Console.WriteLine(JsonConvert.SerializeObject(request, Formatting.Indented));
                var product = await context.Products.Find(x => x.Id == request.Id).FirstOrDefaultAsync();
                if (product is null) return new(data: null, code: 404, message: "Produto não encontrado");

                // Expression<Func<User, bool>> filter = x => x.Id.Equals(usuario.Id);
                await context.Products.DeleteOneAsync(x => x.Id == product.Id);

                return new Response<dynamic?>(product, 200, "Produto excluído com sucesso");
            }
            catch
            {
                return new(data: null, code: 500, message: "Falha ao excluir produto");
            }
        }
    }
}