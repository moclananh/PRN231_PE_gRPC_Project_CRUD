using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static MyProto.GrpcProduct;

namespace Client.Controllers
{
    public class ProductsController : Controller
    {
        // GET: CustomersController
        public IActionResult Index()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new GrpcProductClient(channel);
            MyProto.ProductList data = client.GetAll(new MyProto.Empty());
            ViewBag.Data = data;

            MyProto.CategoryList CategoryData = client.GetAllCategory(new MyProto.Empty());

            ViewBag.CategoryData = CategoryData;

            return View();
        }

        // GET: CustomersController/GetCustomer/5
        public IActionResult Details(int id)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new GrpcProductClient(channel);
            MyProto.Product data = client.GetProductById(new MyProto.IDRequest() { Id = id });
            ViewBag.Data = data;
            MyProto.CategoryList audata = client.GetAllCategory(new MyProto.Empty());
            ViewBag.CategoryData = audata;

            return View();
        }

        // GET: CustomersController
        public IActionResult GetAllCategory()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new GrpcProductClient(channel);
            MyProto.CategoryList data = client.GetAllCategory(new MyProto.Empty());
            ViewBag.CategoryData = data;

            return View();
        }

        // GET: ProductsController/Create
        public IActionResult Create()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new GrpcProductClient(channel);
            MyProto.CategoryList data = client.GetAllCategory(new MyProto.Empty());
            ViewBag.CategoryData = data;

            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        public IActionResult Create(MyProto.CreateProductRequest model)
        {
            if (ModelState.IsValid)
            {
                using var channel = GrpcChannel.ForAddress("https://localhost:5001");
                var client = new GrpcProductClient(channel);


                // Create a new Product using gRPC
                var response = client.CreateProduct(model);

                // Redirect to the details page of the newly created Product
                return RedirectToAction("Index", new { id = response.ProductId });
            }

            // If the ModelState is not valid, return to the Create view with errors
            return View(model);
        }

        // GET: ProductsController/Update/5
        public IActionResult Edit(int id)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new GrpcProductClient(channel);

            MyProto.CategoryList audata = client.GetAllCategory(new MyProto.Empty());
            ViewBag.CategoryData = audata;
            // Get the Product by ID
            MyProto.Product data = client.GetProductById(new MyProto.IDRequest() { Id = id });

            // Display the Product details in the Update view
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(MyProto.Product model)
        {
            if (ModelState.IsValid)
            {
                using var channel = GrpcChannel.ForAddress("https://localhost:5001");
                var client = new GrpcProductClient(channel);

                // Create an UpdateProductRequest object and populate it with data from the Product model
                var updateRequest = new MyProto.UpdateProductRequest
                {
                    ProductId = model.ProductId,
                    ProductName = model.ProductName,
                    CategoryId = model.CategoryId,
                    UnitPrice = model.UnitPrice,
                    UnitsInStock = model.UnitsInStock,
                    Description = model.Description
                };

                // Update the Product using gRPC
                var response = client.UpdateProduct(updateRequest);

                // Redirect to the details page of the updated Product
                return RedirectToAction("Index", new { id = response.ProductId });
            }

            // If the ModelState is not valid, return to the Update view with errors
            return View(model);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new GrpcProductClient(channel);
            MyProto.Product data = client.GetProductById(new MyProto.IDRequest() { Id = (int)id });
            ViewBag.Data = data;
            MyProto.CategoryList audata = client.GetAllCategory(new MyProto.Empty());
            ViewBag.CategoryData = audata;
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new GrpcProductClient(channel);

            // Create an IDRequest with the Product ID to be deleted
            var idRequest = new MyProto.IDRequest { Id = id };

            try
            {
                // Call the DeleteProduct gRPC method to delete the Product
                client.DeleteProduct(idRequest);

                // Redirect to the Product list or another appropriate page
                return RedirectToAction("Index");
            }
            catch (RpcException ex)
            {
                return View("Error");
            }
        }

        // GET: BooksController/Search
        public IActionResult Search(string query)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new GrpcProductClient(channel);

            MyProto.ProductList searchResults;

            if (string.IsNullOrWhiteSpace(query))
            {
                // If the query is null or empty, retrieve the full list
                searchResults = client.GetAll(new MyProto.Empty());
            }
            else
            {
                // Create a SearchRequest with the search query
                var searchRequest = new MyProto.SearchRequest { Query = query };

                // Call the SearchBooks gRPC method to search for books
                searchResults = client.SearchProduct(searchRequest);
            }
            ViewBag.SearchData = searchResults;

            MyProto.CategoryList CategoryData = client.GetAllCategory(new MyProto.Empty());
            ViewBag.CategoryData = CategoryData;



            return View();
        }
    }
}
