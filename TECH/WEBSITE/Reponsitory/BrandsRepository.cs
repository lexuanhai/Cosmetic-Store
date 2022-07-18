using Microsoft.EntityFrameworkCore;
using System;
using WEBSITE.Data.DatabaseEntity;

namespace WEBSITE.Reponsitory
{
    public interface IBrandsRepository : IRepository<Brands, int>
    {
       
    }

    public class BrandsRepository : EFRepository<Brands, int>, IBrandsRepository
    {
        public BrandsRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
