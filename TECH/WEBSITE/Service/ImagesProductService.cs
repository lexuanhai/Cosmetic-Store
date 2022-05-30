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
        //PagedResult<ImagesProductModelView> GetAllPaging(ImagesProductViewModelSearch imagesProductViewModelSearch);
        //ImagesProductModelView GetById(int id);
        //int Add(ImagesProductModelView view);
        //bool Update(ImagesProductModelView view);
        //bool Deleted(int id);
        //void Save();
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
        //public ImagesProductModelView GetById(int id)
        //{
        //    var data = _imagesProductRepository.FindAll(p=>p.Id == id).FirstOrDefault();
        //    if (data != null)
        //    {
        //        var model = new ImagesProductModelView()
        //        {
        //            Id = data.Id,
        //            Name = data.Name,
        //        };
        //        return model;
        //    }
        //    return null;
        //}

        //public int Add(ImagesProductModelView view)
        //{            
        //    try
        //    {
        //        if (view != null)
        //        {
        //            var _product = new Product
        //            {
        //                Name = view.Name,
        //                Decription = view.Decription,
        //                SubDecription = view.SubDecription,
        //                CategoryId = view.CategoryId,
        //                Total = view.Total,
        //                Price = view.Price,
        //                ReducedPrice = view.ReducedPrice,
        //                BrandsId = view.BrandsId,                        
        //            };
        //            _imagesProductRepository.Add(_product);
        //            Save();

        //            return _product.Id;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //return false;
        //    }
        //    return 0;

        //}
        //public void Save()
        //{
        //    _unitOfWork.Commit();
        //}
        //public bool Update(ImagesProductModelView view)
        //{
        //    try
        //    {
        //        var dataServer = _imagesProductRepository.FindById(view.Id);
        //        if (dataServer != null)
        //        {
        //            dataServer.Name = view.Name;
        //            dataServer.Decription = view.Decription;
        //            dataServer.SubDecription = view.SubDecription;
        //            dataServer.CategoryId = view.CategoryId;
        //            dataServer.Total = view.Total;
        //            dataServer.Price = view.Price;
        //            dataServer.ReducedPrice = view.ReducedPrice;
        //            dataServer.BrandsId = view.BrandsId;  
        //            _imagesProductRepository.Update(dataServer);
        //            Save();
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //    return false;
        //}
        //public bool Deleted(int id)
        //{
        //    try
        //    {
        //        var dataServer = _imagesProductRepository.FindById(id);
        //        if (dataServer != null)
        //        {
        //            var listCategoryChild = _imagesProductRepository.FindAll().Where(c => c.Id == dataServer.Id).ToList();
        //            foreach (var itemChild in listCategoryChild)
        //            {
        //                _imagesProductRepository.Remove(itemChild);
        //            }

        //            _imagesProductRepository.Remove(dataServer);
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //    return false;
        //}
        //public PagedResult<ImagesProductModelView> GetAllPaging(ProductViewModelSearch ProductViewModelSearch)
        //{
        //    try
        //    {
        //        var query = _imagesProductRepository.FindAll();
        //        if (ProductViewModelSearch.CategoryParentId.HasValue && ProductViewModelSearch.CategoryParentId.Value > 0)
        //        {
        //            if (!ProductViewModelSearch.CategoryId.HasValue)
        //            {
        //                query = query.Where(c => c.Id == ProductViewModelSearch.CategoryParentId.Value);
        //            }
        //            else
        //            {
        //                if (ProductViewModelSearch.CategoryId.HasValue && ProductViewModelSearch.CategoryId.Value > 0)
        //                {
        //                    query = query.Where(c => c.Id == ProductViewModelSearch.CategoryId.Value);
        //                }
        //            }
                    
        //        }
        //        else
        //        {
        //            if (ProductViewModelSearch.CategoryId.HasValue && ProductViewModelSearch.CategoryId.Value > 0)
        //            {
        //                query = query.Where(c => c.Id == ProductViewModelSearch.CategoryId.Value);
        //            }
        //        }
                
        //        int totalRow = query.Count();
        //        query = query.Skip((ProductViewModelSearch.PageIndex - 1) * ProductViewModelSearch.PageSize).Take(ProductViewModelSearch.PageSize);
        //        var data = query.Select(c => new ImagesProductModelView()
        //        {
        //            Name = c.Name,
        //            Id = c.Id,
        //            //ParentId = c.ParentId
        //        }).ToList();
        //        var pagingData = new PagedResult<ImagesProductModelView>
        //        {
        //            Results = data,
        //            CurrentPage = ProductViewModelSearch.PageIndex,
        //            PageSize = ProductViewModelSearch.PageSize,
        //            RowCount = totalRow,
        //        };
        //        return pagingData;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
       
        //}
    }
}
