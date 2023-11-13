#pragma warning disable CS8618, CS8600,CS8602
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Utilize
{
    public int UtilizeId { get; set; }
    public int CouponId { get; set; }
    public int UserId { get; set; }
    
    public User? User { get; set; }
    public Coupon? Coupon { get; set; }
}