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
        List<RoleModelView> GetAll();
        Task<RoleModelView> GetById(string id);

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
        public List<RoleModelView> GetAll()
        {
            return _roleManager.Roles.Select(r => new RoleModelView()
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            }).ToList();
        }

        public async Task<RoleModelView> GetById(string userId)
        {
            var data = await _roleManager.FindByIdAsync(userId);
            if (data != null)
            {
                var model = new RoleModelView()
                {
                    Id = data.Id,
                    Name = data.Name,
                    Description = data.Description
                };
                return model;
            }
            return null;
        }

        public async Task<bool> Add(RoleModelView roleView)
        {
            if (roleView != null)
            {
                var _role = new Roles
                {
                    Description = roleView.Description,
                    Name = roleView.Name,
                };

                var result = await _roleManager.CreateAsync(_role);
                if (result != null && result.Succeeded)
                {
                    return true;
                }
            }
            return false;

        }
        public async Task<bool> Update(RoleModelView roleView)
        {
            var roleServer = await _roleManager.FindByIdAsync(roleView.Id);
            if (roleServer != null)
            {
                roleServer.Description = roleView.Description;
                roleServer.Name = roleView.Name;
             
                var _userUpdate = await _roleManager.UpdateAsync(roleServer);
                if (_userUpdate.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }
        public async Task<bool> Deleted(string id)
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
