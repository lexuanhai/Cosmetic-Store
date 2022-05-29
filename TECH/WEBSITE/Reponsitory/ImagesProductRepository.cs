using Microsoft.EntityFrameworkCore;
using System;
using WEBSITE.Data.DatabaseEntity;

namespace WEBSITE.Reponsitory
{
    public interface IImagesProductRepository : IRepository<ImagesProduct, int>
    {
       
    }

    public class ImagesProductRepository : EFRepository<ImagesProduct, int>, IImagesProductRepository
    {
        public ImagesProductRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
