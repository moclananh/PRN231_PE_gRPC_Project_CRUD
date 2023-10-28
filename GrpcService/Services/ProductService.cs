using Grpc.Core;
using GrpcService.Models;
using MyProto;
using System.Linq;
using System.Threading.Tasks;
using static MyProto.GrpcProduct;

namespace GrpcService.Services
{
    public class ProductService : GrpcProductBase
    {
        public readonly PRN231_OnPE_gRPCContext _db;

        public ProductService(PRN231_OnPE_gRPCContext db)
        {
            _db = db;
        }

        public override Task<ProductList> GetAll(MyProto.Empty requestData, ServerCallContext context)
        {
            ProductList response = new ProductList();
            var cusList = from obj in _db.Products
                          select new MyProto.Product()
                          {
                              ProductId = obj.ProductId,
                              ProductName = obj.ProductName,
                              CategoryId = (int)obj.CategoryId,
                              UnitPrice = obj.UnitPrice,
                              UnitsInStock = obj.UnitsInStock,
                              Description = obj.Description,
                             
                          };
            response.Product.AddRange(cusList);

            return Task.FromResult(response);
        }

        public override Task<CategoryList> GetAllCategory(MyProto.Empty requestData, ServerCallContext context)
        {
            CategoryList response = new CategoryList();
            var cusList = from obj in _db.Categories
                          select new MyProto.Category()
                          {
                              CategoryId = obj.CategoryId,
                              CategoryName = obj.CategoryName,

                          };
            response.Category.AddRange(cusList);

            return Task.FromResult(response);
        }

        public override Task<MyProto.Product> GetProductById(IDRequest request, ServerCallContext context)
        {

            var obj = this._db.Products.Find(request.Id);

            if (obj == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Product not found"));
            }


            MyProto.Product Product = new MyProto.Product()
            {
                ProductId = obj.ProductId,
                ProductName = obj.ProductName,
                CategoryId = (int)obj.CategoryId,
                UnitPrice = obj.UnitPrice,
                UnitsInStock = obj.UnitsInStock,
                Description = obj.Description,
            };

            return Task.FromResult(Product);
        }

        public override async Task<MyProto.Product> CreateProduct(CreateProductRequest request, ServerCallContext context)
        {
            var ProductEntity = new Models.Product()
            {
                ProductName = request.ProductName,
                CategoryId = request.CategoryId,
                UnitPrice = request.UnitPrice,
                UnitsInStock = request.UnitsInStock,
                Description = request.Description
            };

            _db.Products.Add(ProductEntity);
            await _db.SaveChangesAsync();

            var Product = new MyProto.Product()
            {
                ProductId = ProductEntity.ProductId,
                ProductName = ProductEntity.ProductName,
                CategoryId = (int)ProductEntity.CategoryId,
                UnitPrice = ProductEntity.UnitPrice,
                UnitsInStock = ProductEntity.UnitsInStock,
                Description = ProductEntity.Description
               
            };

            return Product;
        }

        public override async Task<MyProto.Product> UpdateProduct(UpdateProductRequest request, ServerCallContext context)
        {
            var ProductEntity = _db.Products.Find(request.ProductId);

            if (ProductEntity == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Product not found"));
            }

            ProductEntity.ProductName = request.ProductName;
            ProductEntity.CategoryId = request.CategoryId;
            ProductEntity.UnitPrice = request.UnitPrice;
            ProductEntity.UnitsInStock = request.UnitsInStock;
            ProductEntity.Description = request.Description;

            await _db.SaveChangesAsync();

            var updatedProduct = new MyProto.Product()
            {
                ProductId = ProductEntity.ProductId,
                ProductName = ProductEntity.ProductName,
                CategoryId = (int)ProductEntity.CategoryId,
                UnitPrice = ProductEntity.UnitPrice,
                UnitsInStock = ProductEntity.UnitsInStock,
                Description = ProductEntity.Description
               
            };

            return updatedProduct;
        }

        public override async Task<Empty> DeleteProduct(IDRequest request, ServerCallContext context)
        {
            var ProductEntity = _db.Products.Find(request.Id);

            if (ProductEntity == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Product not found"));
            }

            _db.Products.Remove(ProductEntity);
            await _db.SaveChangesAsync();

            return new Empty();
        }

        public override Task<ProductList> SearchProduct(SearchRequest request, ServerCallContext context)
        {
            ProductList response = new ProductList();

            var searchResults = _db.Products
                .Where(ProductEntity => ProductEntity.ProductName.Contains(request.Query) || ProductEntity.UnitPrice.ToString() == request.Query)
                .Select(ProductEntity => new MyProto.Product
                {
                    ProductId = ProductEntity.ProductId,
                    ProductName = ProductEntity.ProductName,
                    CategoryId = (int)ProductEntity.CategoryId,
                    UnitPrice = ProductEntity.UnitPrice,
                    UnitsInStock = ProductEntity.UnitsInStock,
                    Description = ProductEntity.Description

                });

            response.Product.AddRange(searchResults);

            return Task.FromResult(response);
        }

    }

}
