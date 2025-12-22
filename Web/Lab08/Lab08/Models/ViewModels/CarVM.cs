using System.ComponentModel.DataAnnotations.Schema;

namespace Lab08.Models.ViewModes
{
    [NotMapped]
    public class CarVM
    {
        public string Name { get; set; } = null!;
        public int BrandId { get; set; }
    }
}
