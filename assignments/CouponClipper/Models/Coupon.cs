#pragma warning disable CS8618, CS8600,CS8602
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Coupon
{
    [Key]    
    public int CouponId { get; set; }
    [Required(ErrorMessage = "Need a CouponCode")]
    public string CouponCode { get; set; } 
    [Required(ErrorMessage = "Need a Website")]
    public string Website { get; set; } 
    [Required(ErrorMessage = "Need a Description")]
    [MinLength(10, ErrorMessage = "Description must be at least 10 characters")]
    public string Description { get; set; } 
    public DateTime CreatedAt {get;set;} = DateTime.Now;   
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    public List<Utilize> Users { get; set; } = new List<Utilize>();
    public int UserId { get; set; }
    public User? Creator { get; set; }
}