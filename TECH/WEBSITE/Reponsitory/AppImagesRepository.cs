using Microsoft.EntityFrameworkCore;
using System;
using WEBSITE.Data.DatabaseEntity;

namespace WEBSITE.Reponsitory
{
    public interface IAppImagesRepository : IRepository<AppImages, int>
    {
       
    }

    public class AppImagesRepository : EFRepository<AppImages, int>, IAppImagesRepository
    {
        public AppImagesRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
