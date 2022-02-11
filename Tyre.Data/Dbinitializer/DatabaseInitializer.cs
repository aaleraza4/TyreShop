using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyre.Data.DbContexts;
using Tyre.Data.Entities;

namespace Tyre.Data.Dbinitializer
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly QtyrePlusDbContext _qtyrePlusDbContext;
        private readonly IConfiguration _configuration;

        public DatabaseInitializer(QtyrePlusDbContext qtyrePlusDbContext, IConfiguration config,IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
            _qtyrePlusDbContext = qtyrePlusDbContext;
            _configuration = config;
        }
        public async Task MigrateDbsAsync()
        {
            #region [Update the license db schema]
            await _qtyrePlusDbContext.Database.MigrateAsync();
            #endregion
        }
       
        public async Task SeedDataAsync()
        {
            //var AdminId = await AddSuperadminAsync();
        }

        //public async Task<Guid?> AddSuperadminAsync()
        //{
        //    var _superadminManager = _serviceProvider.GetRequiredService<ISuperadminRepo>();
        //    var uniqueGuid = Guid.NewGuid();
        //    var superAdminEmail = _configuration["SuperadminUser:Email"];
        //    var superAdminPassword = _configuration["SuperadminUser:Password"];
        //    var superAdminFirstName = _configuration["SuperadminUser:FirstName"];
        //    var superAdminLastName = _configuration["SuperadminUser:LastName"];
        //    var SuperadminModel = await _superadminManager.CheckSuperadminEmailExist(superAdminEmail);
        //    if (SuperadminModel == null)
        //    {
        //        return await _superadminManager.CreateSuperadminAccount(new SuperadminAccount()
        //        {
        //            Id = uniqueGuid,
        //            Email = superAdminEmail,
        //            Username = superAdminEmail,
        //            FirstName = superAdminFirstName,
        //            LastName = superAdminLastName,
        //            Password = superAdminPassword,
        //        });
        //    }
        //    return null;
        //}
    }
}
