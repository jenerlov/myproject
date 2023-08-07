using myproject.Helpers.Services;
using myproject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace myproject.Controllers;

public class HomeController : Controller
{
    private readonly ProductService _productService;

    public HomeController(ProductService productService)
    {
        _productService = productService;
    }

    public async Task <IActionResult> Index()
    {
        var viewModel = new HomeIndexViewModel
        {
            New = new ProductsByTagsViewModel
            {
                Title = "New",
                NewProducts = await _productService.GetAllByTagNameAsync("New headphones")
            },

            Popular = new ProductsByTagsViewModel
            {
                Title = "Popular",
                PopularProducts = await _productService.GetAllByTagNameAsync("Popular headphones")




            },

            Featured = new ProductsByTagsViewModel
            {
                Title = "Featured",
                NewProducts = await _productService.GetAllByTagNameAsync("Featured headphones")
            }

            


        };
        
        
        return View(viewModel);
    }


    public async Task<IActionResult> Products()
    {
        var viewModel = new ProductsViewModel
        {
            Products = new AllProductsViewModel
            {
                Title = "Products",
                AllProducts = await _productService.GetAllProductsAsync()
            }

        

            

        };


        return View(viewModel);
    }
}