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
    public interface IAppUserService
    {
        PagedResult<UserModelView> GetAllPaging(UserModelViewSearch userModelViewSearch);
        UserModelView GetById(int id);
        int Add(UserModelView view);
        bool Update(UserModelView view);
        bool Deleted(int id);
        void Save();
    }

    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;
        private IUnitOfWork _unitOfWork;
        public AppUserService(IAppUserRepository appUserRepository, IUnitOfWork unitOfWork)
        {
            _appUserRepository = appUserRepository;
            _unitOfWork = unitOfWork;
        }
        public UserModelView GetById(int id)
        {
            var data = _appUserRepository.FindAll(p => p.Id == id).FirstOrDefault();
            if (data != null)
            {
                var model = new UserModelView()
                {
                    Id = data.Id,
                    Name = data.Name,
                    //Code = data.Code
                };
                return model;
            }
            return null;
        }

        public int Add(UserModelView view)
        {
            try
            {
                if (view != null)
                {
                    var appUser = new AppUser
                    {

                        Name = view.Name,
                        Phone = view.Phone,
                        Email  = view.Email,
                        UserName = view.UserName,
                        Birthday  = view.Birthday,
                        Address  = view.Address,
                        City  = view.City,
                        Avartar   = view.Avartar,
                        PhoneNumber = view.PhoneNumber,
                    };
                    _appUserRepository.Add(appUser);
                    Save();
                    
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
        public bool Update(UserModelView view)
        {
            try
            {
                var dataServer = _appUserRepository.FindById(view.Id);
                if (dataServer != null)
                {
                    dataServer.Name = view.Name;
                    dataServer.Phone = view.Phone;
                    dataServer.Email = view.Email;
                    dataServer.UserName = view.UserName;
                    dataServer.Birthday = view.Birthday;
                    dataServer.Address = view.Address;
                    dataServer.City = view.City;
                    dataServer.Avartar = view.Avartar;
                    dataServer.PhoneNumber = view.PhoneNumber;
                    _appUserRepository.Update(dataServer);
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
                var dataServer = _appUserRepository.FindById(id);
                if (dataServer != null)
                {
                    _appUserRepository.Remove(dataServer);
                    return true;

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return false;
        }
        public PagedResult<UserModelView> GetAllPaging(UserModelViewSearch userModelViewSearch)
        {
            try
            {
                var query = _appUserRepository.FindAll();

                if (!string.IsNullOrEmpty(userModelViewSearch.Name))
                {
                    query = query.Where(c => c.Name.ToLower() == userModelViewSearch.Name.ToLower());
                }


                int totalRow = query.Count();
                query = query.Skip((userModelViewSearch.PageIndex - 1) * userModelViewSearch.PageSize).Take(userModelViewSearch.PageSize);
                var data = query.Select(c => new UserModelView()
                {
                    Name = c.Name,
                    Id = c.Id,
                    Phone = c.Phone,
                    Email = c.Email,
                    UserName = c.UserName,
                    Birthday = c.Birthday,
                    Address = c.Address,
                    City = c.City,
                    Avartar = c.Avartar,
                    PhoneNumber = c.PhoneNumber,
                 }).ToList();
                var pagingData = new PagedResult<UserModelView>
                {
                    Results = data,
                    CurrentPage = userModelViewSearch.PageIndex,
                    PageSize = userModelViewSearch.PageSize,
                    RowCount = totalRow,
                };
                return pagingData;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<UserModelView> GetAll()
        {
            var data = _appUserRepository.FindAll().Select(c => new UserModelView()
            {
                Id = c.Id,
                Name = c.Name,
                //Code = c.Code
            }).ToList();

            return data;
        }

    }
}
