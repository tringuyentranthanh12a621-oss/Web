using System.ComponentModel.DataAnnotations;

namespace MvcMovieFinal.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        public ICollection<Movie>? Movies { get; set; }

    }
}