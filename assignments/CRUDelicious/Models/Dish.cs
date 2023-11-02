#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
public class Dish
{
    [Key]
    public int DishId { get; set; }
    [Required(ErrorMessage = "Need a Name")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Need a Chef")]
    public string Chef { get; set; }
    [Required(ErrorMessage = "Need Tastiness")]
    [Range(1,10)]
    public int Tastiness { get; set; }
    [Required(ErrorMessage = "Need Calories")]
    [Range(0,2000)]
    public int Calories { get; set; }
    [Required(ErrorMessage = "Need a Description")]
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}