using Microsoft.EntityFrameworkCore;

namespace myproject.Models.Entities
{
    [PrimaryKey("ArticleNumber", "TagId")]
    public class ProductTagEntity
    {
        public string ArticleNumber {get; set;} = null!;
        public ProductEntity Product {get; set;} = null!;
        public int TagId {get; set;}
        public  TagEntity Tag {get; set;} = null!;
    }
}