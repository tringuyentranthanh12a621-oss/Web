using Lab08.Models; // Quan trọng: dùng ViewModel

namespace Lab08.Services.Interfaces
{
    public interface ICarModelService
    {
        // Lấy danh sách (trả về ViewModel để hiển thị BrandName)
        List<CarModelVm> GetCarModels();

        // Lấy chi tiết (trả về ViewModel)
        CarModelVm? GetCarModelById(int id);

        // Tạo mới (nhận vào ViewModel từ form)
        void CreateCarModel(CarModelVm carVm);

        // Cập nhật (nhận vào ViewModel từ form)
        void UpdateCarModel(CarModelVm carVm);

        // Xóa
        void DeleteCarModel(int id);
    }
}