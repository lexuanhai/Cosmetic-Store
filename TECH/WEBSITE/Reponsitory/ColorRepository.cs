using Microsoft.EntityFrameworkCore;
using System;
using WEBSITE.Data.DatabaseEntity;

namespace WEBSITE.Reponsitory
{
    public interface IColorRepository : IRepository<Colors, int>
    {
       
    }

    public class ColorRepository : EFRepository<Colors, int>, IColorRepository
    {
        public ColorRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
