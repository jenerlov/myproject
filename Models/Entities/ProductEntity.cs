using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myproject.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public int ArticleNumber {get; set;}

        public string Name {get; set;} = null!;
        [Column(TypeName = "price")]

        public decimal Price {get; set;}

    }
}