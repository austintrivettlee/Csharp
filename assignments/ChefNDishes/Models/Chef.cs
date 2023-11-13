#pragma warning disable CS8618, CS8600,CS8602
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Chef
{
    [Key]    
    public int ChefId { get; set; }
    
    [Required(ErrorMessage = "Need a First Name")]
    [MinLength(2, ErrorMessage = "First Name must be at least 2 characters")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Need a Last Name")]  
    [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters")]      
    public string LastName { get; set; }     
    [Required(ErrorMessage = "Need a Date Of Birth")]
    [MinimumAge(18, ErrorMessage = "You must be at least 18 years old.")]
    public DateTime DOB { get; set; }
    public DateTime CreatedAt {get;set;} = DateTime.Now;   
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    public List<Dish> AllDishes { get; set; } = new();
}




