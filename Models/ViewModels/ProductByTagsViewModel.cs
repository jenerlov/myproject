// using myproject.Migrations;
using myproject.Models.Dtos;

namespace myproject.Models.ViewModels
{
    public class ProductsByTagViewModel
    {
        public string?  Title {get; set;}

        public IEnumerable<Product> NewProducts {get; set;} = new List<Product>();
        public IEnumerable<Product> PopularProducts {get; set;} = new List<Product>();
        // public IEnumerable<Product> FeaturedProducts {get; set;} = new List<Product>();
    }
}