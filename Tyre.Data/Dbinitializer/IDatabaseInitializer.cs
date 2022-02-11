using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyre.Data.Dbinitializer
{
    public interface IDatabaseInitializer
    {
        Task MigrateDbsAsync();


        /// <summary>
        /// Adds some default values to the Db
        /// </summary>
        Task SeedDataAsync();
    }
}
