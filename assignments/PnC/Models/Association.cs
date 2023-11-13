#pragma warning disable CS8618, CS8600,CS8602
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Association
{
    [Key]    
    public int AssociationId { get; set; } 
    public int ProductId { get; set; }    
    public int CatagoryId { get; set; }


    public Product? Product { get; set; }    
    public Catagory? Catagory { get; set; }
}