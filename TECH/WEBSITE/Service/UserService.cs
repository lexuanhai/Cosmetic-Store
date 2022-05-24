using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBSITE.Areas.Admin.Models;
using WEBSITE.Data.DatabaseEntity;

namespace WEBSITE.Service
{
    public interface IUserService
    {
       List<UserModelView> GetAllUser();
       Task<UserModelView> GetUserById(string userId);

       Task<bool> AddUser(UserModelView userView);
       Task<bool> UpdateUser(UserModelView userView);
    }
    public class UserService : IUserService
    {
        private readonly UserManager<Staff> _userManager;
        public UserService(UserManager<Staff> userManager)
        {
            _userManager = userManager;
        }
        public  List<UserModelView> GetAllUser()
        {
            return _userManager.Users.Select(u =>new UserModelView() { 
                Id = u.Id,
                UserName = u.UserName,
                Phone = u.PhoneNumber != null ? u.PhoneNumber : "",
                Name = u.Name,
                Email = u.Email != null ? u.Email : "",
                Address = u.Address != null? u.Address:"",
                Birthday = u.Birthday
            }).ToList();
        }
        
        public async Task<UserModelView> GetUserById(string userId) {
            var data = await _userManager.FindByIdAsync(userId);           
            if (data != null)
            {
                var model = new UserModelView()
                {
                    Id = data.Id,
                    UserName = data.UserName,
                    Phone = data.PhoneNumber != null ? data.PhoneNumber : "",
                    Name = data.Name,
                    Email = data.Email != null ? data.Email : "",
                    Address = data.Address != null ? data.Address : "",
                    Birthday = data.Birthday
                };
                return model;
            }
            return null;
        }

        public async Task<bool> AddUser(UserModelView userView)
        {
            if (userView != null)
            {
                var _user = new Staff
                {
                    UserName = userView.UserName,
                    Name = userView.Name,
                    Email = userView.Email,
                    PhoneNumber = userView.Phone,
                    Address = userView.Address,
                    Birthday = userView.Birthday,
                    //EmailConfirmed = true,
                    //PhoneNumberConfirmed = true,
                };
                string _password = "";
                if (string.IsNullOrEmpty(userView.PassWord))
                {
                    _password = "123456a@";
                }

                var result = await _userManager.CreateAsync(_user, _password);
                if (result != null && result.Succeeded)
                {
                    return  true;
                }
            }
            return false;
            
        }
        public async Task<bool> UpdateUser(UserModelView userView)
        {
            var userServer = await _userManager.FindByIdAsync(userView.Id);
            if (userServer != null)
            {
                userServer.UserName = userView.UserName;
                userServer.Name = userView.Name;
                userServer.Email = userView.Email;
                userServer.PhoneNumber = userView.Phone;
                userServer.Address = userView.Address;
                userServer.Birthday = userView.Birthday;
                var _userUpdate = await _userManager.UpdateAsync(userServer);
                if (_userUpdate.Succeeded)
                {
                    return true;
                }               
            }
            return false;
        }
    }
}
