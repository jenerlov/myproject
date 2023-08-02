using System.ComponentModel.DataAnnotations;

namespace myproject.Models.Entities

{
    public class ProductEntity
    {
        [Key]
        public string ArticleNumber {get; set;} = null!;
        public string? ProductName  {get; set;} 
        public string? Ingress {get; set;} 
        public string? Description  {get; set;} 
        public string? Image  {get; set;} 
        public string? Price  {get; set;} 
        public ICollection<ProductTagEntity> Tags {get; set;} = new HashSet<ProductTagEntity>();
    }
}

