using System.ComponentModel.DataAnnotations;
namespace SurveyApp.Models
{
    public class FormModel
    {
        [Required(ErrorMessage="Name is required!")]
        [MinLength(3, ErrorMessage="Name must be at least 3 characters in length.")]
        public string? Name { get; set; }
        [Required]
        public string? DojoLocation { get; set; }
        [Required]
        public string? FavoriteLanguage { get; set; }
        [MinLength(20, ErrorMessage="Comment must be at least 20 characters in length.")]
        public string? Comment { get; set; }
    }
}