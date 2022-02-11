using Tyre.Data.DbContexts;
using Tyre.Data.EFRepository;
using Tyre.Data.Dbinitializer;
using Microsoft.EntityFrameworkCore;
using Tyre.Data.Repos;

namespace TyreShop
{
    public static  class RegisterService
    {
        public static void ConfigureApplicationServices(this WebApplicationBuilder webAppBuilder)
        {

            webAppBuilder.Services.AddRazorPages();
            webAppBuilder.Services.AddDbContext<QtyrePlusDbContext>(options =>
            options.UseSqlServer(
                  webAppBuilder.Configuration.GetConnectionString("DefaultConnection")
                                  ));
            // configure DI for application services
            webAppBuilder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);
            webAppBuilder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            webAppBuilder.Services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();

            #region @@@[------Services]
            //webAppBuilder.Services.AddScoped<IAccountService, AccountService>();
            #endregion

            #region @@@[------Repository]
            webAppBuilder.Services.AddScoped<ISuperadminRepo, SuperadminRepo>();
            #endregion
        }
    }
}
