using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBSITE.Areas.Admin.Models;
using WEBSITE.Areas.Admin.Models.Search;
using WEBSITE.Data.DatabaseEntity;
using WEBSITE.Reponsitory;
using WEBSITE.Utilities;

namespace WEBSITE.Service
{
    public interface IImagesProductService
    {
        List<ImagesProductModelView> GetAll(int productId);
       bool AddImages(int productId, string[] images);
    }
    public class ImagesProductService : IImagesProductService
    {
        private readonly IImagesProductRepository _imagesProductRepository;
        private IUnitOfWork _unitOfWork;
        public ImagesProductService(IImagesProductRepository imagesProductRepository, IUnitOfWork unitOfWork)
        {
            _imagesProductRepository = imagesProductRepository;
            _unitOfWork = unitOfWork;
        }
        public bool AddImages(int productId, string[] images)
        {
            try
            {
                _imagesProductRepository.RemoveMultiple(_imagesProductRepository.FindAll(x => x.ProductId == productId).ToList());
                foreach (var image in images)
                {
                    _imagesProductRepository.Add(new ImagesProduct()
                    {
                        Url = image,
                        ProductId = productId,
                    });
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<ImagesProductModelView> GetAll(int productId)
        {
            try
            {
                var model = _imagesProductRepository.FindAll(x => x.ProductId == productId).Select(ip=> new ImagesProductModelView() { 
                    Url = ip.Url,
                    Alt = ip.Alt,
                    ProductId = ip.ProductId
                }).ToList();
                
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
