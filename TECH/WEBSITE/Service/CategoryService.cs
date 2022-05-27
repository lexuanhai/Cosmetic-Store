using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBSITE.Areas.Admin.Models;
using WEBSITE.Data.DatabaseEntity;
using WEBSITE.Reponsitory;

namespace WEBSITE.Service
{
    public interface ICategoryService
    {
       List<CategoryModelView> GetAll();
       List<CategoryModelView> GetAllParent();
       CategoryModelView GetById(int id);
       bool Add(CategoryModelView view);
       bool Update(CategoryModelView view);
       bool Deleted(int id);
       void Save();
    }
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        public  List<CategoryModelView> GetAll()
        {
            var dataModel = _categoryRepository.FindAll().Select(c => new CategoryModelView()
            {
                Id = c.Id,
                Name = c.Name,
                ParentId = c.ParentId,
                //ParentName = (c.ParentId.HasValue && c.ParentId.Value > 0 ? _categoryRepository.FindById(c.ParentId.Value).Name :"") 
            }).ToList();
            if (dataModel != null && dataModel.Count > 0)
            {
                foreach (var item in dataModel)
                {
                    if (item.ParentId.HasValue && item.ParentId.Value > 0)
                    {
                        item.ParentName = dataModel.FirstOrDefault(c => c.Id == item.ParentId.Value).Name;
                    }
                }
            }
            return dataModel;
        }
        public List<CategoryModelView> GetAllParent()
        {
            return _categoryRepository.FindAll().Where(c=>!c.ParentId.HasValue).Select(c => new CategoryModelView()
            {
                Id = c.Id,
                Name = c.Name,                
            }).ToList();
        }

        public CategoryModelView GetById(int id) {
            var data = _categoryRepository.FindById(id);           
            if (data != null)
            {
                var model = new CategoryModelView()
                {
                    Id = data.Id,
                    Name = data.Name,
                    ParentId = data.ParentId
                };
                return model;
            }
            return null;
        }

        public bool Add(CategoryModelView view)
        {
            try
            {
                if (view != null)
                {
                    var _category = new Category
                    {
                        Name = view.Name,
                        ParentId = view.ParentId
                    };
                    _categoryRepository.Add(_category);                    
                    return true;
                }
            }
            catch (Exception ex)
            {
                //return false;
            }

            return false;

        }
        public void Save()
        {
            _unitOfWork.Commit();
        }
        public bool Update(CategoryModelView view)
        {
            try
            {
                var dataServer = _categoryRepository.FindById(view.Id);
                if (dataServer != null)
                {
                    dataServer.ParentId = view.ParentId;
                    dataServer.Name = view.Name;
                    _categoryRepository.Update(dataServer);
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
                var dataServer = _categoryRepository.FindById(id);
                if (dataServer != null)
                {
                    var listCategoryChild = _categoryRepository.FindAll().Where(c => c.ParentId == dataServer.Id).ToList();
                    foreach (var itemChild in listCategoryChild)
                    {
                        _categoryRepository.Remove(itemChild);
                    }

                    _categoryRepository.Remove(dataServer);
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
            return false;
        }
    }
}
