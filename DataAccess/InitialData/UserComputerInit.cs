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
                Name = "First computer",
            };

            user.Computers.Add(newComputer);

            // Add cpus
            newComputer.CPUs.Add(new CPU
            {
                Id = 1
            });

            // Add gpus
            newComputer.GPUs.Add(new GPU
            {
                Id = 1
            });

            // Add Hdds
            newComputer.HDDs.Add(new HDD
            {
                Id = 1
            });

            // Add network cards
            newComputer.NetworkCards.Add(new NetworkCard
            {
                Id = 1
            });

            // Add RAM
            newComputer.RAMs.Add(new RAM
            {
                Id = 1
            });

            db.SaveChanges();
        }
    }
}
