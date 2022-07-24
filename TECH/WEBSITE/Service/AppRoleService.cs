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
    public interface IAppRoleService
    {
        PagedResult<RoleModelView> GetAllPaging(ColorViewModelSearch colorViewModelSearch);
        List<RoleModelView> GetAll();
        RoleModelView GetById(int id);
        int Add(RoleModelView view);
        bool Update(RoleModelView view);
        bool Deleted(int id);
        void Save();
    }

    public class AppRoleService : IAppRoleService
    {
        private readonly IAppRoleRepository _appRoleRepository;
        private IUnitOfWork _unitOfWork;
        public AppRoleService(IAppRoleRepository appRoleRepository, IUnitOfWork unitOfWork)
        {
            _appRoleRepository = appRoleRepository;
            _unitOfWork = unitOfWork;
        }
        public RoleModelView GetById(int id)
        {
            var data = _appRoleRepository.FindAll(p => p.Id == id).FirstOrDefault();
            if (data != null)
            {
                var model = new RoleModelView()
                {
                    Id = data.Id,
                    Name = data.Name,
                    //Code = data.Code
                };
                return model;
            }
            return null;
        }

        public int Add(RoleModelView view)
        {
            try
            {
                if (view != null)
                {
                    var appRoles = new AppRoles
                    {
                        Name = view.Name,
                        Description = view.Description
                        //Code = view.Code,
                    };
                    _appRoleRepository.Add(appRoles);
                    Save();
                    return appRoles.Id;
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
        public bool Update(RoleModelView view)
        {
            try
            {
                var dataServer = _appRoleRepository.FindById(view.Id);
                if (dataServer != null)
                {
                    dataServer.Name = view.Name;
                    dataServer.Description = view.Description;
                    _appRoleRepository.Update(dataServer);
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
                var dataServer = _appRoleRepository.FindById(id);
                if (dataServer != null)
                {
                    _appRoleRepository.Remove(dataServer);
                    return true;

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return false;
        }
        public PagedResult<RoleModelView> GetAllPaging(ColorViewModelSearch colorViewModelSearch)
        {
            try
            {
                var query = _appRoleRepository.FindAll();
                
                if (!string.IsNullOrEmpty(colorViewModelSearch.Name))
                {
                    query = query.Where(c => c.Name.ToLower() == colorViewModelSearch.Name.ToLower());
                }


                int totalRow = query.Count();
                query = query.Skip((colorViewModelSearch.PageIndex - 1) * colorViewModelSearch.PageSize).Take(colorViewModelSearch.PageSize);
                var data = query.Select(c => new RoleModelView()
                {
                    Name = c.Name,
                    //Code = c.Code,
                    Id = c.Id,
                    Description = c.Description
                }).ToList();
                var pagingData = new PagedResult<RoleModelView>
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
        public List<RoleModelView> GetAll()
        {
            var data = _appRoleRepository.FindAll().Select(c => new RoleModelView()
            {
                Id = c.Id,
                Name = c.Name,
                //Code = c.Code
            }).ToList();

            return data;
        }

    }
}
