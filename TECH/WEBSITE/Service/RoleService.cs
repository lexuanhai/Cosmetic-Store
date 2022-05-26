using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBSITE.Areas.Admin.Models;
using WEBSITE.Data.DatabaseEntity;

namespace WEBSITE.Service
{
    public interface IRoleService
    {
       List<RoleModelView> GetAllUser();
       Task<RoleModelView> GetUserById(string userId);

       Task<bool> Add(RoleModelView roleView);
       Task<bool> Update(RoleModelView roleView);
       Task<bool> Deleted(string userId);
    }
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Roles> _roleManager;
        public RoleService(RoleManager<Roles> roleManager)
        {
            _roleManager = roleManager;
        }
        public  List<RoleModelView> GetAllUser()
        {
            return _roleManager.Roles.Select(r =>new RoleModelView() { 
                Id = r.Id,
                Description = r.Description
            }).ToList();
        }
        
        public async Task<RoleModelView> GetUserById(string userId) {
            var data = await _roleManager.FindByIdAsync(userId);           
            if (data != null)
            {
                var model = new RoleModelView()
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

        public async Task<bool> AddUser(RoleModelView userView)
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

                var result = await _roleManager.CreateAsync(_user, _password);
                if (result != null && result.Succeeded)
                {
                    return  true;
                }
            }
            return false;
            
        }
        public async Task<bool> UpdateUser(RoleModelView userView)
        {
            var userServer = await _roleManager.FindByIdAsync(userView.Id);
            if (userServer != null)
            {
                userServer.UserName = userView.UserName;
                userServer.Name = userView.Name;
                userServer.Email = userView.Email;
                userServer.PhoneNumber = userView.Phone;
                userServer.Address = userView.Address;
                userServer.Birthday = userView.Birthday;
                var _userUpdate = await _roleManager.UpdateAsync(userServer);
                if (_userUpdate.Succeeded)
                {
                    return true;
                }               
            }
            return false;
        }
        public async Task<bool> DeletedUser(string id)
        {
            var userServer = await _roleManager.FindByIdAsync(id);
            if (userServer != null)
            {               
                var _userUpdate = await _roleManager.DeleteAsync(userServer);
                if (_userUpdate.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
