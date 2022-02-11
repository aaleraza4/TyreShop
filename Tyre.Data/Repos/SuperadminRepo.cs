using Microsoft.EntityFrameworkCore;
using Tyre.Data.DbContexts;
using Tyre.Data.EFRepository;
using Tyre.Data.Entities;

namespace Tyre.Data.Repos
{
    public class SuperadminRepo : Repository<SuperadminAccount>, ISuperadminRepo
    {
        public SuperadminRepo(QtyrePlusDbContext eduLicenseDbContext) : base(eduLicenseDbContext)
        {

        }
        public async Task<SuperadminAccount> CheckSuperadminEmailExist(string Email)
        {
            return await GetAll().Where(x => x.Email.ToLower() == Email.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<Guid> CreateSuperadminAccount(SuperadminAccount FrontEndmodel)
        {
            FrontEndmodel = FrontEndmodel == null ? new SuperadminAccount() : FrontEndmodel;
            FrontEndmodel.IsActive = true;
            FrontEndmodel.FirstName = FrontEndmodel.LastName;
            FrontEndmodel.LastName = FrontEndmodel.FirstName;
            FrontEndmodel.Email = FrontEndmodel.Email;
            FrontEndmodel.Username = FrontEndmodel.Username;
            FrontEndmodel.Password = FrontEndmodel.Password;
            await Add(FrontEndmodel);
            return FrontEndmodel.Id;
        }

    }
}
