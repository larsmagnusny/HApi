using HApi.DataAccess.Entities;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HApi.DataAccess.InitialData
{
    public static class UserComputerInit
    {
        public static void Init(HContext db, Guid userId)
        {
            var user = db.Users.FirstOrDefault(o => o.UserId == userId);

            var newComputer = new Computer
            {
                MotherboardId = 1,
                Name = "First computer"
            };

            // Add cpus
            newComputer.CPUs.Add(new ComputerCPU { CPUId = 1 });

            // Add gpus
            newComputer.GPUs.Add(new ComputerGPU { GPUId = 1 });

            // Add Hdds
            newComputer.HDDs.Add(new ComputerHDD { HDDId = 1 });

            // Add network cards
            newComputer.NetworkCards.Add(new ComputerNetworkCard { NetworkCardId = 1 });

            // Add RAM
            newComputer.RAMs.Add(new ComputerRAM { RAMId = 1 });

            user.Computers.Add(newComputer);

            db.SaveChanges();
        }
    }
}
