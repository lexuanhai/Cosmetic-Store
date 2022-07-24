using Microsoft.EntityFrameworkCore;
using System;
using WEBSITE.Data.DatabaseEntity;

namespace WEBSITE.Reponsitory
{
    public interface IAppUserRepository : IRepository<AppUser, int>
    {
       
    }

    public class AppUserRepository : EFRepository<AppUser, int>, IAppUserRepository
    {
        public AppUserRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
