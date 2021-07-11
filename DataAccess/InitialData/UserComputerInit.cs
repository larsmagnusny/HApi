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
                Name = "First computer"
            };

            var motherboard = new Motherboard { Id = 1 };
            db.Motherboards.Attach(motherboard);
            newComputer.Motherboard = motherboard;

            user.Computers.Add(newComputer);

            // Add cpus
            var newCPU = new CPU
            {
                Id = 1
            };
            db.CPUs.Attach(newCPU);
            newComputer.CPUs.Add(newCPU);

            // Add gpus
            var newGPU = new GPU
            {
                Id = 1
            };
            db.GPUs.Attach(newGPU);
            newComputer.GPUs.Add(newGPU);

            // Add Hdds
            var newHDD = new HDD
            {
                Id = 1
            };
            db.HDDs.Attach(newHDD);
            newComputer.HDDs.Add(newHDD);

            // Add network cards
            var newNetworkCard = new NetworkCard
            {
                Id = 1
            };
            db.NetworkCards.Attach(newNetworkCard);
            newComputer.NetworkCards.Add(newNetworkCard);

            // Add RAM
            var newRAM = new RAM
            {
                Id = 1
            };
            db.RAMs.Attach(newRAM);
            newComputer.RAMs.Add(newRAM);

            db.SaveChanges();
        }
    }
}
