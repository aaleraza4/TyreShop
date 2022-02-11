using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyre.Data.Entities;

namespace Tyre.Data.Repos
{
    public interface ISuperadminRepo
    {
        Task<Guid> CreateSuperadminAccount(SuperadminAccount FrontEndmodel);
        Task<SuperadminAccount> CheckSuperadminEmailExist(string Email);
    }
}
