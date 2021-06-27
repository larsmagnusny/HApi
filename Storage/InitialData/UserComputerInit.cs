using HApi.Storage.Entities;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HApi.Storage.InitialData
{
    public static class UserComputerInit
    {
        public static void Init(LiteDatabase db, Guid userId)
        {
            var computers = db.GetCollection<Computer>();

            var newComputer = new Computer
            {
                MotherboardId = 1,
                Name = "First computer"
            };
            computers.Insert(newComputer);
            computers.EnsureIndex(o => o.Id);

            // Add cpus
            var computerCPUs = db.GetCollection<ComputerCPUParts>();

            computerCPUs.Insert(new ComputerCPUParts
            {
                ComputerId = newComputer.Id,
                CPUId = 1,
                MotherboardId = 1
            });

            computerCPUs.EnsureIndex(o => o.ComputerId);

            // Add gpus
            var computerGPUs = db.GetCollection<ComputerGPUParts>();

            computerGPUs.Insert(new ComputerGPUParts
            {
                ComputerId = newComputer.Id,
                GPUId = 1,
                MotherboardId = 1
            });

            computerGPUs.EnsureIndex(o => o.ComputerId);

            // Add Hdds
            var computerHDDs = db.GetCollection<ComputerHDDParts>();

            computerHDDs.Insert(new ComputerHDDParts
            {
                ComputerId = newComputer.Id,
                HDDId = 1,
                MotherboardId = 1
            });

            computerHDDs.EnsureIndex(o => o.ComputerId);

            // Add network cards
            var computerNetworkCards = db.GetCollection<ComputerNetworkCardParts>();

            computerNetworkCards.Insert(new ComputerNetworkCardParts
            {
                ComputerId = newComputer.Id,
                MotherboardId = 1,
                NetworkCardId = 1
            });

            computerNetworkCards.EnsureIndex(o => o.ComputerId);

            // Add RAM
            var computerRAMs = db.GetCollection<ComputerRAMParts>();

            computerRAMs.Insert(new ComputerRAMParts
            {
                ComputerId = newComputer.Id,
                MotherboardId = 1,
                RAMId = 1
            });

            computerRAMs.EnsureIndex(o => o.ComputerId);

            var userComputers = db.GetCollection<UserComputer>();

            userComputers.Insert(new UserComputer
            {
                ComputerId = newComputer.Id,
                UserId = userId
            });

            userComputers.EnsureIndex(o => o.UserId );
        }
    }
}
