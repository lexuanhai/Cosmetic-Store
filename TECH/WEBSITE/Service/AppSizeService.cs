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
    public interface IAppSizeService
    {
        PagedResult<ColorModelView> GetAllPaging(ColorViewModelSearch colorViewModelSearch);
        List<ColorModelView> GetAll();
        ColorModelView GetById(int id);
        bool Add(ColorModelView view);
        bool Update(ColorModelView view);
        bool Deleted(int id);
        void Save();
    }
    public class AppSizeService : IAppSizeService
    {
        private readonly IAppSizeRepository _appSizeRepository;
        private IUnitOfWork _unitOfWork;
        public AppSizeService(IAppSizeRepository appSizeRepository, IUnitOfWork unitOfWork)
        {
            _appSizeRepository = appSizeRepository;
            _unitOfWork = unitOfWork;
        }
        public ColorModelView GetById(int id)
        {
            var data = _appSizeRepository.FindAll(p => p.Id == id).FirstOrDefault();
            if (data != null)
            {
                var model = new ColorModelView()
                {
                    Id = data.Id,
                    Name = data.Name,
                    //Code = data.Code
                };
                return model;
            }
            return null;
        }

        public bool Add(ColorModelView view)
        {
            try
            {
                if (view != null)
                {
                    var _colors = new AppSize
                    {
                        Name = view.Name,
                        //Code = view.Code,
                    };
                    _appSizeRepository.Add(_colors);
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
        public bool Update(ColorModelView view)
        {
            try
            {
                var dataServer = _appSizeRepository.FindById(view.Id);
                if (dataServer != null)
                {
                    dataServer.Name = view.Name;
                    //dataServer.Code = view.Code;
                    _appSizeRepository.Update(dataServer);
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
                var dataServer = _appSizeRepository.FindById(id);
                if (dataServer != null)
                {
                    _appSizeRepository.Remove(dataServer);
                    return true;

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return false;
        }
        public PagedResult<ColorModelView> GetAllPaging(ColorViewModelSearch colorViewModelSearch)
        {
            try
            {
                var query = _appSizeRepository.FindAll();
               
                if (!string.IsNullOrEmpty(colorViewModelSearch.Name))
                {
                    query = query.Where(c => c.Name.ToLower() == colorViewModelSearch.Name.ToLower());
                }


                int totalRow = query.Count();
                query = query.Skip((colorViewModelSearch.PageIndex - 1) * colorViewModelSearch.PageSize).Take(colorViewModelSearch.PageSize);
                var data = query.Select(c => new ColorModelView()
                {
                    Name = c.Name,
                    //Code = c.Code,
                    Id = c.Id,
                    //ParentId = c.ParentId
                }).ToList();
                var pagingData = new PagedResult<ColorModelView>
                {
                    Results = data,
                    CurrentPage = colorViewModelSearch.PageIndex,
                    PageSize = colorViewModelSearch.PageSize,
                    RowCount = totalRow,
                };
                return pagingData;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public List<ColorModelView> GetAll()
        {
            var data = _appSizeRepository.FindAll(c => c.IsDeleted != true).Select(c => new ColorModelView()
            {
                Id = c.Id,
                Name = c.Name,
                //Code = c.Code
            }).ToList();

            return data;
        }
    }
}
