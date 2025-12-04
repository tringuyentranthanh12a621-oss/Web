using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        // Optional: dùng để bật/tắt category
        public bool IsActive { get; set; } = true;

        // Optional: ngày tạo
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
