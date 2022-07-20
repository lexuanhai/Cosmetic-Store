using Microsoft.EntityFrameworkCore;
using System;
using WEBSITE.Data.DatabaseEntity;

namespace WEBSITE.Reponsitory
{
    public interface IAppSizeRepository : IRepository<AppSize, int>
    {
       
    }

    public class AppSizeRepository : EFRepository<AppSize, int>, IAppSizeRepository
    {
        public AppSizeRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
