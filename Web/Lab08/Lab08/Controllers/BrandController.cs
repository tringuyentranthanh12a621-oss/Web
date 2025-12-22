using Lab08.Models;
using Lab08.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab08.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        // 1. GET: /Brand (Danh sách)
        public IActionResult Index()
        {
            var brands = _brandService.GetAllBrands();
            return View(brands);
        }

        // 2. GET: /Brand/Details/5 (Chi tiết)
        public IActionResult Details(int id)
        {
            var brand = _brandService.GetBrandById(id);
            if (brand == null) return NotFound();
            return View(brand); // Trả về 1 đối tượng Brand
        }

        // 3. GET: /Brand/Create (Form tạo mới)
        public IActionResult Create()
        {
            return View();
        }

        // 4. POST: /Brand/Create (Xử lý tạo mới)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Brand brand)
        {
            // --- QUAN TRỌNG: Bỏ qua kiểm tra danh sách xe (tránh lỗi Validation) ---
            ModelState.Remove("Car");
            // ---------------------------------------------------------------------

            if (ModelState.IsValid)
            {
                _brandService.CreateBrand(brand);
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // 5. GET: /Brand/Edit/5 (Form sửa)
        public IActionResult Edit(int id)
        {
            var brand = _brandService.GetBrandById(id);
            if (brand == null) return NotFound();
            return View(brand);
        }

        // 6. POST: /Brand/Edit (Xử lý sửa)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Brand brand)
        {
            // --- QUAN TRỌNG: Bỏ qua kiểm tra danh sách xe ---
            ModelState.Remove("Car");
            // ----------------------------------------------

            if (ModelState.IsValid)
            {
                _brandService.UpdateBrand(brand);
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // 7. GET: /Brand/Delete/5 (Trang xác nhận xóa)
        public IActionResult Delete(int id)
        {
            var brand = _brandService.GetBrandById(id);
            if (brand == null) return NotFound();
            return View(brand); // Trả về 1 đối tượng Brand để View hiển thị
        }

        // 8. POST: /Brand/Delete/5 (Thực hiện xóa)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _brandService.DeleteBrand(id);
            return RedirectToAction(nameof(Index));
        }
    }
}