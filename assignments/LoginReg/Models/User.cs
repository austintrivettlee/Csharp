#pragma warning disable CS8618, CS8600,CS8602
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key]    
    public int UserId { get; set; }
    
    [Required(ErrorMessage = "Need a First Name")]
    [MinLength(2, ErrorMessage = "First Name must be at least 2 characters")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Need a Last Name")]  
    [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters")]      
    public string LastName { get; set; }     
    
    [Required(ErrorMessage = "Need a Email")]
    [EmailAddress]
    [UniqueEmail]
    public string Email { get; set; }    
    
    [Required(ErrorMessage = "Need a Password")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string Password { get; set; } 
    [Required]
    [NotMapped]
    [Compare("Password")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    [DataType(DataType.Password)]
    public string PassConf { get; set; }   
    
    public DateTime CreatedAt {get;set;} = DateTime.Now;   
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}

public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value == null)
        {
            return new ValidationResult("Email is required!");
        }
    
    	
        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));
        
    	if(_context.Users.Any(e => e.Email == value.ToString()))
        {

            return new ValidationResult("Email must be unique!");
        } else {
    	    
            return ValidationResult.Success;
        }
    }
}

