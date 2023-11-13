#pragma warning disable CS8618, CS8600,CS8602
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Association
{
    public int AssociationId { get; set; }
    public int WeddingId { get; set; }
    public int UserId { get; set; }
    
    public User? User { get; set; }
    public Wedding? Wedding { get; set; }
}