using Microsoft.EntityFrameworkCore;
using System;
using WEBSITE.Data.DatabaseEntity;

namespace WEBSITE.Reponsitory
{
    public interface IAppUserRolesRepository : IRepository<AppUserRoles, int>
    {
       
    }

    public class AppUserRolesRepository : EFRepository<AppUserRoles, int>, IAppUserRolesRepository
    {
        public AppUserRolesRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
