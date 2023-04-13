using E_commerceMVCProject.viewmodels;

namespace E_commerceMVCProject.Services
{
    public interface IProductImageService
    {
        List<ImageVM> GetAllImages();
        ImageVM GetImageByID(int id);
        void AddImage(ImageVM imageVM);
        void UpdateImage(ImageVM imageVM);
        void DeleteImage(int id);
    }
}
