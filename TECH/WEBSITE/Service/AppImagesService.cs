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
    public interface IAppImagesService
    {
       List<AppImagesModelView> GetImagesByProductId(int productId);

       List<ImagesProductModelView> AddImages(int productId, string[] images);

       AppImages GetAppImagesById(int imageId);

       void Save();
    }

    public class AppImagesService : IAppImagesService
    {
        private readonly IAppImagesRepository _appImagesRepository;
        private readonly IImagesProductRepository _imagesProductRepository;
        private IUnitOfWork _unitOfWork;

        public AppImagesService(IAppImagesRepository appImagesRepository,
            IImagesProductRepository imagesProductRepository,
            IUnitOfWork unitOfWork)
        {
            _appImagesRepository = appImagesRepository;
            _imagesProductRepository = imagesProductRepository;
            _unitOfWork = unitOfWork;
        }
       
        public List<ImagesProductModelView> AddImages(int productId, string[] images)
        {
            try
            {
                var lstImageProduct = new List<ImagesProductModelView>();
                foreach (var image in images)
                {
                    var appImages = new AppImages()
                    {
                        Url = image,
                    };
                    _appImagesRepository.Add(appImages);
                    Save();
                    lstImageProduct.Add(new ImagesProductModelView() { 
                        ProductId = productId,
                        AppImageId = appImages.Id
                    });
                }

                return lstImageProduct;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public AppImages GetAppImagesById(int imageId)
        {
            var AppImage = _appImagesRepository.FindById(imageId);
            if (AppImage != null && !AppImage.IsDeleted)           
                return AppImage;                
            
            return null;
        }

        public List<AppImagesModelView> GetImagesByProductId(int productId)
        {
            try
            {
                var lstImagesModel = new List<AppImagesModelView>();
                var model = _imagesProductRepository.FindAll(x => x.ProductId == productId).Select(ip=> new ImagesProductModelView() { 
                    AppImageId = ip.AppImageId,
                    ProductId = ip.ProductId
                }).ToList();

                if (model != null && model.Count > 0)
                {
                    foreach (var item in model)
                    {
                        if (item.AppImageId.HasValue && item.AppImageId.Value > 0)
                        {
                            var AppImages = GetAppImagesById(item.AppImageId.Value);
                            if (AppImages != null)
                            {
                                lstImagesModel.Add(new AppImagesModelView()
                                {
                                    AppImageId = AppImages.Id,
                                    ProductId = productId,
                                    Url = AppImages.Url
                                });
                            }
                        }
                    }
                }
                return lstImagesModel;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
