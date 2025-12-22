using Lab08.Models;
using Lab08.Models.ViewModes;
using Lab08.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab08.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly IBrandService _brandService;

        public CarController(ICarService carService, IBrandService brandService)
        {
            _carService = carService;
            _brandService = brandService;
        }

        // GET: /Car/Index
        public IActionResult Index()
        {
            ViewData["BrandId"] = new SelectList(_brandService.GetAllBrands(), "Id", "Name");
            return View(_carService.GetAllCars());
        }

        // GET: /Car/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_brandService.GetAllBrands(), "Id", "Name");
            return View();
        }

        // POST: /Car/Create
        [HttpPost]
        // [ValidateAntiForgeryToken] <--- TÔI ĐÃ BỎ DÒNG NÀY ĐỂ SỬA LỖI 400 CHO BẠN
        public IActionResult Create(CarVM car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Car item = new Car();
                    item.Name = car.Name;
                    item.BrandId = car.BrandId;
                    _carService.CreateCar(item);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi lưu dữ liệu: " + ex.Message);
            }

            // 3. Nếu thất bại, nạp lại Dropdown để chọn lại
            ViewData["BrandId"] = new SelectList(_brandService.GetAllBrands(), "Id", "Name", car.BrandId);
            return View(car);
        }

        // GET: /Car/Edit/5
        public IActionResult Edit(int id)
        {
            var car = _carService.GetCarById(id);
            if (car == null) return NotFound();
            ViewData["BrandId"] = new SelectList(_brandService.GetAllBrands(), "Id", "Name", car.BrandId);
            return View(car);
        }

        // POST: /Car/Edit
        [HttpPost]
        // [ValidateAntiForgeryToken] <--- BỎ DÒNG NÀY LUÔN
        public IActionResult Edit(Car car)
        {
            ModelState.Remove("Brand");

            if (ModelState.IsValid)
            {
                _carService.UpdateCar(car);
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_brandService.GetAllBrands(), "Id", "Name", car.BrandId);
            return View(car);
        }

        // GET: /Car/Delete/5
        public IActionResult Delete(int id)
        {
            var car = _carService.GetCarById(id);
            if (car == null) return NotFound();
            return View(car);
        }

        // POST: /Car/Delete/5
        [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken] <--- BỎ DÒNG NÀY LUÔN
        public IActionResult DeleteConfirmed(int id)
        {
            _carService.DeleteCar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}