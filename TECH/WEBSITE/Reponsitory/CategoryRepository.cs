using Microsoft.EntityFrameworkCore;
using System;
using WEBSITE.Data.DatabaseEntity;

namespace WEBSITE.Reponsitory
{
    public interface ICategoryRepository: IRepository<Category, int>
    {
       
    }

    public class CategoryRepository : EFRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
