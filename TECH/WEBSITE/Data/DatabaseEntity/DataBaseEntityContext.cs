using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WEBSITE.Data.DatabaseEntity
{
    public class DataBaseEntityContext : IdentityDbContext<Staff, Roles,string>
    {
        public DataBaseEntityContext(DbContextOptions<DataBaseEntityContext> options) : base(options) { }
        
        public DbSet<Category> Categories { set; get; }
        public DbSet<Brands> Brands { set; get; }
        public DbSet<Colors> Colors { set; get; }
        public DbSet<Customers> Customers { set; get; }
        public DbSet<ImagesProduct> ImagesProduct { set; get; }
        public DbSet<Orders> Orders { set; get; }
        public DbSet<OrdersDetail> OrdersDetail { set; get; }
        public DbSet<Product> Product { set; get; }
        public DbSet<Staff> Staff { set; get; }
        public DbSet<Roles> AppRoles { set; get; }
        public DbSet<ColorsProduct> ColorsProduct { get; set; }
        //public DbSet<Roles> Roles { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Bỏ tiền tố AspNet của các bảng: mặc định các bảng trong IdentityDbContext có
            // tên với tiền tố AspNet như: AspNetUserRoles, AspNetUser ...
            // Đoạn mã sau chạy khi khởi tạo DbContext, tạo database sẽ loại bỏ tiền tố đó
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }

        // Tạo database
        //public void CreateDatabase()
        //{
        //    String databasename = Database.GetDbConnection().Database;
        //    Console.WriteLine("Tạo " + databasename);
        //    bool result = Database.EnsureCreated();
        //    string resultstring = result ? "tạo  thành  công" : "đã có trước đó";
        //    Console.WriteLine($"CSDL {databasename} : {resultstring}");
        //}

        // Xóa Database
        //public void DeleteDatabase()
        //{
        //    String databasename = Database.GetDbConnection().Database;
        //    bool deleted = Database.EnsureDeleted();
        //    string deletionInfo = deleted ? "đã xóa" : "không xóa được";
        //    Console.WriteLine($"{databasename} {deletionInfo}");
        //    //Console.Write($"Có chắc chắn xóa {databasename} (y) ? ");
        //    //string input = Console.ReadLine();

        //    //// // Hỏi lại cho chắc
        //    //if (input.ToLower() == "y")
        //    //{
        //    //    bool deleted =  Database.EnsureDeleted();
        //    //    string deletionInfo = deleted ? "đã xóa" : "không xóa được";
        //    //    Console.WriteLine($"{databasename} {deletionInfo}");
        //    //}
        //}
    }
}
