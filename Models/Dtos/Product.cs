namespace myproject.Models.Dtos;

public class Product 
{
    public string? ArticleNumber {get; set;} = null!;
    public string? ProductName {get; set;} 
    public string? Ingress {get; set;} 
    public string? Description {get; set;} 
    public string? ImageUrl {get; set;} 
    public string? Price {get; set;} 

    public List<string> Tags {get; set;} = new List<string>();
    

}