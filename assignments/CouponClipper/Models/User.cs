#pragma warning disable CS8618, CS8600,CS8602
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key]    
    public int UserId { get; set; }
    [Required(ErrorMessage = "Need a User Name")]
    [MinLength(2, ErrorMessage = "User Name must be at least 2 characters")]
    public string Username { get; set; } 
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
    public List<Coupon> CouponsCreated { get; set; } = new List<Coupon>();
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

