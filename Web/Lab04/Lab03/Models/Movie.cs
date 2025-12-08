using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovieFinal.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Vui lòng nhập tên phim")]
        [Display(Name = "Tên Phim")]
        public string? Title { get; set; }

        // --- Mới thêm: Tác giả / Đạo diễn ---
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Vui lòng nhập tên tác giả")]
        [Display(Name = "Tác giả")]
        public string? Author { get; set; }

        // --- Mới thêm: Ngày sản xuất ---
        [Display(Name = "Ngày sản xuất")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Vui lòng chọn ngày sản xuất")]
        public DateTime ProductionDate { get; set; }

        [Display(Name = "Ngày phát hành")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Giá vé")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        [Display(Name = "Đánh giá")]
        public string? Rating { get; set; }

        [Display(Name = "Thể loại")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}