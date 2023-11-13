#pragma warning disable CS8618, CS8600,CS8602
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [Key]    
    public int ProductId { get; set; }
    
    [Required(ErrorMessage = "Need a Name.")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Need a Description.")]  
    [MinLength(2, ErrorMessage = "Description must be at least 10 characters.")]      
    public string Description { get; set; }     
    [Required(ErrorMessage = "Need a Price.")]
    [Range(0, int32.MaxValue)]
    public double price { get; set; }
    public DateTime CreatedAt {get;set;} = DateTime.Now;   
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

     public List<Association> Type { get; set; } = new List<Association>();

}




