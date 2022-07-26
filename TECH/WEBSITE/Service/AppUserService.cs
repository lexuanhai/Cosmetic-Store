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
                    Phone = data.Phone,
                    Email = data.Email,
                    UserName = data.UserName,
                    Birthday = data.Birthday,
                    Address = data.Address,
                    Avartar = data.Avartar,
                    PassWord = data.PassWord
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
                        Avartar   = view.Avartar,                        
                    };
                    _appUserRepository.Add(appUser);
                    Save();

                    return appUser.Id;                    
                }
            }
            catch (Exception ex)
            {
                return 0;
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
                    dataServer.Avartar = view.Avartar;
                    dataServer.PassWord = view.PassWord;
                    _appUserRepository.Update(dataServer);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
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
                    dataServer.IsDeleted = true;
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
        public PagedResult<UserModelView> GetAllPaging(UserModelViewSearch userModelViewSearch)
        {
            try
            {
                var query = _appUserRepository.FindAll().Where(u=>!u.IsDeleted);

                if (!string.IsNullOrEmpty(userModelViewSearch.Name))
                {
                    query = query.Where(c => c.Name.ToLower() == userModelViewSearch.Name.ToLower());
                }

                int totalRow = query.Count();
                query = query.Skip((userModelViewSearch.PageIndex - 1) * userModelViewSearch.PageSize).Take(userModelViewSearch.PageSize);
                var data = query.Select(c => new UserModelView()
                {
                    Name = (!string.IsNullOrEmpty(c.Name) ? c.Name:""),
                    Id = c.Id,
                    Phone = !string.IsNullOrEmpty(c.Phone) ? c.Phone : "",
                    Email = !string.IsNullOrEmpty(c.Email) ? c.Email : "",
                    UserName = !string.IsNullOrEmpty(c.UserName) ? c.UserName : "",
                    Birthday = c.Birthday,
                    BirthdayStr = c.Birthday.HasValue ? c.Birthday.Value.ToString("dd/MM/yyyy"):"",
                    Address = !string.IsNullOrEmpty(c.Address) ? c.Address : "",                    
                    Avartar = c.Avartar,
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
