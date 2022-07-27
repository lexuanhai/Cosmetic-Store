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
    public interface IQuantityProductService
    {
        //List<ImagesProductModelView> GetAll(int productId);
        bool Add(QuantityProductModelView view);
        bool Deleted(int id);
        List<QuantityProductModelView> GetQuantityProductForProductId(int productId);
    }
    public class QuantityProductService : IQuantityProductService
    {
        private readonly IQuantityProductRepository _quantityProductRepository;
        private IUnitOfWork _unitOfWork;
        public QuantityProductService(IQuantityProductRepository quantityProductRepository, IUnitOfWork unitOfWork)
        {
            _quantityProductRepository = quantityProductRepository;
            _unitOfWork = unitOfWork;
        }
        public bool Add(QuantityProductModelView view)
        {
            try
            {
                if (view != null)
                {
                    var _quantityProduct = new QuantityProduct
                    {
                        ProductId = view.Product != null ? view.Product.Id: 0,
                        AppSizeId = view.AppSize  != null ? view.AppSize.Id: 0,
                        TotalImported = view.TotalImported,
                        TotalSold = view.TotalSold,
                        TotalStock = view.TotalStock,
                        DateImport = view.DateImport,
                    };
                    _quantityProductRepository.Add(_quantityProduct);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        public List<QuantityProductModelView> GetQuantityProductForProductId(int productId)
        {
            try
            {
                var lstQuantityProduct = _quantityProductRepository.FindAll(q=>q.IsDeleted !=true).Where(q=>q.ProductId == productId).Select(p=>new QuantityProductModelView() { 
                    Id = p.Id,
                    TotalImported = p.TotalImported,
                    TotalSold = p.TotalSold,
                    TotalStock = p.TotalStock,
                    IsDeleted = p.IsDeleted,
                    DateImport = p.DateImport,
                    ProductId = p.ProductId,
                    AppSizeId = p.AppSizeId
                }).OrderByDescending(p=>p.Id).ToList();

                return lstQuantityProduct;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Deleted(int id)
        {
            try
            {
                var dataServer = _quantityProductRepository.FindAll().Where(i=>i.Id == id).FirstOrDefault();
                if (dataServer != null)
                {
                    dataServer.IsDeleted = true;
                    _quantityProductRepository.Remove(dataServer);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return false;
        }
        //public List<ImagesProductModelView> GetAll(int productId)
        //{
        //    try
        //    {
        //        var model = _imagesProductRepository.FindAll(x => x.ProductId == productId).Select(ip=> new ImagesProductModelView() { 
        //            Url = ip.Url,
        //            Alt = ip.Alt,
        //            ProductId = ip.ProductId
        //        }).ToList();

        //        return model;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
    }
}
