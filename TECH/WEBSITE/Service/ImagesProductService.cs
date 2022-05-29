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
    public interface IProductService
    {
        PagedResult<ProductModelView> GetAllPaging(ProductViewModelSearch productViewModelSearch);
        ProductModelView GetById(int id);
        int Add(ProductModelView view);
        bool Update(ProductModelView view);
        bool Deleted(int id);
        void Save();
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }              
        public ProductModelView GetById(int id)
        {
            var data = _productRepository.FindAll(p=>p.Id == id).FirstOrDefault();
            if (data != null)
            {
                var model = new ProductModelView()
                {
                    Id = data.Id,
                    Name = data.Name,
                };
                return model;
            }
            return null;
        }

        public int Add(ProductModelView view)
        {            
            try
            {
                if (view != null)
                {
                    var _product = new Product
                    {
                        Name = view.Name,
                        Decription = view.Decription,
                        SubDecription = view.SubDecription,
                        CategoryId = view.CategoryId,
                        Total = view.Total,
                        Price = view.Price,
                        ReducedPrice = view.ReducedPrice,
                        BrandsId = view.BrandsId,                        
                    };
                    _productRepository.Add(_product);
                    Save();

                    return _product.Id;
                }
            }
            catch (Exception ex)
            {
                //return false;
            }
            return 0;

        }
        public void Save()
        {
            _unitOfWork.Commit();
        }
        public bool Update(ProductModelView view)
        {
            try
            {
                var dataServer = _productRepository.FindById(view.Id);
                if (dataServer != null)
                {
                    dataServer.Name = view.Name;
                    dataServer.Decription = view.Decription;
                    dataServer.SubDecription = view.SubDecription;
                    dataServer.CategoryId = view.CategoryId;
                    dataServer.Total = view.Total;
                    dataServer.Price = view.Price;
                    dataServer.ReducedPrice = view.ReducedPrice;
                    dataServer.BrandsId = view.BrandsId;  
                    _productRepository.Update(dataServer);
                    Save();
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return false;
        }
        public bool Deleted(int id)
        {
            try
            {
                var dataServer = _productRepository.FindById(id);
                if (dataServer != null)
                {
                    var listCategoryChild = _productRepository.FindAll().Where(c => c.Id == dataServer.Id).ToList();
                    foreach (var itemChild in listCategoryChild)
                    {
                        _productRepository.Remove(itemChild);
                    }

                    _productRepository.Remove(dataServer);
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return false;
        }
        public PagedResult<ProductModelView> GetAllPaging(ProductViewModelSearch ProductViewModelSearch)
        {
            try
            {
                var query = _productRepository.FindAll();
                if (ProductViewModelSearch.CategoryParentId.HasValue && ProductViewModelSearch.CategoryParentId.Value > 0)
                {
                    if (!ProductViewModelSearch.CategoryId.HasValue)
                    {
                        query = query.Where(c => c.Id == ProductViewModelSearch.CategoryParentId.Value);
                    }
                    else
                    {
                        if (ProductViewModelSearch.CategoryId.HasValue && ProductViewModelSearch.CategoryId.Value > 0)
                        {
                            query = query.Where(c => c.Id == ProductViewModelSearch.CategoryId.Value);
                        }
                    }
                    
                }
                else
                {
                    if (ProductViewModelSearch.CategoryId.HasValue && ProductViewModelSearch.CategoryId.Value > 0)
                    {
                        query = query.Where(c => c.Id == ProductViewModelSearch.CategoryId.Value);
                    }
                }
                
                int totalRow = query.Count();
                query = query.Skip((ProductViewModelSearch.PageIndex - 1) * ProductViewModelSearch.PageSize).Take(ProductViewModelSearch.PageSize);
                var data = query.Select(c => new ProductModelView()
                {
                    Name = c.Name,
                    Id = c.Id,
                    //ParentId = c.ParentId
                }).ToList();
                var pagingData = new PagedResult<ProductModelView>
                {
                    Results = data,
                    CurrentPage = ProductViewModelSearch.PageIndex,
                    PageSize = ProductViewModelSearch.PageSize,
                    RowCount = totalRow,
                };
                return pagingData;
            }
            catch (Exception ex)
            {

                throw;
            }
       
        }
    }
}
