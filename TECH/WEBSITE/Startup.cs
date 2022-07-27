using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeduCoreApp.Helpers;
using WEBSITE.Data.DatabaseEntity;
using WEBSITE.Reponsitory;
using WEBSITE.Service;

namespace WEBSITE
{
    public class Startup
    {
        public Startup(IConfiguration configuration
            //IHttpContextAccessor httpContextAccessor
            )
        {
            //_httpContextAccessor = httpContextAccessor;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        //public IHttpContextAccessor _httpContextAccessor { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<DataBaseEntityContext>(options =>
            {
                // Đọc chuỗi kết nối
                string connectstring = Configuration.GetConnectionString("AppDbContext");
                // Sử dụng MS SQL Server
                options.UseSqlServer(connectstring);
            });
            services.AddHttpContextAccessor();
            services.AddSession();
            //services.AddIdentity<AppUser, AppRoles>()
            //.AddEntityFrameworkStores<DataBaseEntityContext>()
            //.AddDefaultTokenProviders();

            //services.AddHttpContextAccessor();
            services.AddOptions();                                        // Kích hoạt Options
            var mailsettings = Configuration.GetSection("MailSettings");  // đọc config
            services.Configure<MailSettings>(mailsettings);               // đăng ký để Inject

            //services.AddTransient<IEmailSender, SendMailService>();

            services.AddMvc().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = null;
                o.JsonSerializerOptions.DictionaryKeyPolicy = null;
            });
            //services.AddRazorPages();

            services.Configure<IdentityOptions>(options => {
                // Thiết lập về Password
                options.Password.RequireDigit = false; // Không bắt phải có số
                options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
                options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
                options.Password.RequireUppercase = false; // Không bắt buộc chữ in
                options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
                options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

                // Cấu hình Lockout - khóa user
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
                options.Lockout.MaxFailedAccessAttempts = 105; // Thất bại 5 lầ thì khóa
                options.Lockout.AllowedForNewUsers = false;

                // Cấu hình về User.
                options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;  // Email là duy nhất

                // Cấu hình đăng nhập.
                 options.SignIn.RequireConfirmedEmail = false;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
                 options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại

            });

            services.AddScoped(typeof(IUnitOfWork), typeof(EFUnitOfWork));
            services.AddScoped(typeof(IRepository<,>), typeof(EFRepository<,>));
           // services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, CustomClaimsPrincipalFactory>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAppSizeRepository, AppSizeRepository>();
            services.AddScoped<IImagesProductRepository, ImagesProductRepository>();
            services.AddScoped<IAppImagesRepository, AppImagesRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBrandsRepository, BrandsRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IAppRoleRepository, AppRoleRepository>();
            services.AddScoped<IAppUserRolesRepository, AppUserRolesRepository>();


            // service
            //services.AddTransient<IUserService, UserService>();
            //services.AddTransient<IRoleService, RoleService>();
           
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAppSizeService, AppSizeService>();
            services.AddScoped<IImagesProductService, ImagesProductService>();
            services.AddScoped<IAppImagesService, AppImagesService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBrandsService, BrandsService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAppRoleService, AppRoleService>();
            services.AddScoped<IAppUserRoleService, AppUserRoleService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                   name: "admin",
                   areaName: "Admin",
                   pattern: "admin/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
