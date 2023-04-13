using AutoMapper;
using E_commerceMVCProject.Models;
using E_commerceMVCProject.Repository;
using E_commerceMVCProject.viewmodels;
using System.Drawing;

namespace E_commerceMVCProject.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IRepository<ProductImage> _ImageRepository;
        private readonly IMapper _mapper;
        public ProductImageService(IRepository<ProductImage> ImageRepository, IMapper mapper)
        {
            _ImageRepository = ImageRepository;
            _mapper = mapper;
        }
        public List<ImageVM> GetAllImages()
        {
            List<ProductImage> images = _ImageRepository.GetAll().ToList();
            return _mapper.Map<List<ImageVM>>(images);
        }
        public ImageVM GetImageByID(int id)
        {
            ProductImage image = _ImageRepository.GetById(id);
            return _mapper.Map<ImageVM>(image);
        }
        public void AddImage(ImageVM ImageVM)
        {
            ProductImage image = _mapper.Map<ProductImage>(ImageVM);
            _ImageRepository.Insert(image);
        }
        public void UpdateImage(ImageVM ImageVM)
        {
            ProductImage image = _mapper.Map<ProductImage>(ImageVM);
            _ImageRepository.Update(image);
        }
        public void DeleteImage(int id)
        {
            _ImageRepository.Delete(id);
        }
    }
}
