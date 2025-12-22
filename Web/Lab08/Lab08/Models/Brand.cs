using Microsoft.AspNetCore.Mvc.ModelBinding.Validation; // 1. Cần thư viện này
using System.ComponentModel.DataAnnotations;

namespace Lab08.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên hãng không được để trống")]
        public string Name { get; set; } = null!;

        public string? Country { get; set; }

        // 2. Thêm [ValidateNever] để khi Submit form, nó không kiểm tra list này
        [ValidateNever]
        public ICollection<Car> Car { get; set; } = new List<Car>();
    }
}