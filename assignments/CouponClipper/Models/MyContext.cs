#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<Utilize> Utilized { get; set; }

}