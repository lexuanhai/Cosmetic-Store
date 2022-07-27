using Microsoft.EntityFrameworkCore;
using System;
using WEBSITE.Data.DatabaseEntity;

namespace WEBSITE.Reponsitory
{
    public interface IQuantityProductRepository : IRepository<QuantityProduct, int>
    {
       
    }

    public class QuantityProductRepository : EFRepository<QuantityProduct, int>, IQuantityProductRepository
    {
        public QuantityProductRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
