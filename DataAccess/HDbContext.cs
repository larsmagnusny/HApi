using HApi.Storage.InitialData;
using LiteDB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HApi.DataAccess
{
    public class HDbContext : IHDbContext
    {
        public LiteDatabase Database { get; private set; }

        public HDbContext(IOptions<LiteDbOptions> options)
        {
            Database = new LiteDatabase(options.Value.DatabaseLocation);

            ItemInit.Init(Database);
            UserRepair.Repair(Database); // Repair users if they somehow loose their data
        }
    }
}
