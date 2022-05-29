using Microsoft.EntityFrameworkCore;
using System;
using WEBSITE.Data.DatabaseEntity;

namespace WEBSITE.Reponsitory
{
    public interface IProductRepository : IRepository<Product, int>
    {
       
    }

    public class ProductRepository : EFRepository<Product, int>, IProductRepository
    {
        public ProductRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
