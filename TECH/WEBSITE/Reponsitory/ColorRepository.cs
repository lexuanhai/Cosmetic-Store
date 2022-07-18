using Microsoft.EntityFrameworkCore;
using System;
using WEBSITE.Data.DatabaseEntity;

namespace WEBSITE.Reponsitory
{
    public interface IColorRepository : IRepository<AppSize, int>
    {
       
    }

    public class ColorRepository : EFRepository<AppSize, int>, IColorRepository
    {
        public ColorRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
