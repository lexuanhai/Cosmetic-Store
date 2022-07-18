using Microsoft.EntityFrameworkCore;
using System;
using WEBSITE.Data.DatabaseEntity;

namespace WEBSITE.Reponsitory
{
    public interface IColorsProductRepository : IRepository<AppSizeProduct, int>
    {
       
    }

    public class ColorsProductRepository : EFRepository<AppSizeProduct, int>, IColorsProductRepository
    {
        public ColorsProductRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
