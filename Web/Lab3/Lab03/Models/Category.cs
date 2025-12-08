using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab03.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public bool IsActive { get; set; } = true;

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // === 1 Category - n Movies ===
        public ICollection<Movie> Movies { get; set; }
    }
}
