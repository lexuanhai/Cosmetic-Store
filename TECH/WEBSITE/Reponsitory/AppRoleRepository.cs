using Microsoft.EntityFrameworkCore;
using System;
using WEBSITE.Data.DatabaseEntity;

namespace WEBSITE.Reponsitory
{
    public interface IAppRoleRepository : IRepository<AppRoles, int>
    {
       
    }

    public class AppRoleRepository : EFRepository<AppRoles, int>, IAppRoleRepository
    {
        public AppRoleRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
