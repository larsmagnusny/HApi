using HApi.DataAccess.Entities;
using LiteDB;
using System.Collections.Generic;
using System.Linq;

namespace HApi.DataAccess.InitialData {
    public static class ItemInit {
        public static void Init(HContext db)
        {
            var cpuIds = new HashSet<int>(db.CPUs.Select(o => o.Id));

            if(!cpuIds.Contains(1))
            {
                db.CPUs.Add(new CPU
                {
                    Id = 1,
                    MHZ = 200,
                    Name = "Irtel Perntium",
                    NumCores = 1,
                    Price = 120
                });
            }

            var RAMIds = new HashSet<int>(db.RAMs.Select(o => o.Id));

            if(!RAMIds.Contains(1))
            {
                db.RAMs.Add(new RAM
                {
                    Id = 1,
                    MB = 128,
                    MHZ = 100,
                    Name = "Mextor SDRAM",
                    Price = 40
                });
            }

            var GPUIds = new HashSet<int>(db.GPUs.Select(o => o.Id));

            if(!GPUIds.Contains(1))
            {
                db.GPUs.Add(new GPU
                {
                    Id = 1,
                    CoreMhz = 100,
                    MB = 25,
                    MemMhz = 100,
                    NumCores = 1,
                    Price = 100,
                    Name = "Nidia GTX 0.1"
                });
            }

            var HDDIds = new HashSet<int>(db.HDDs.Select(o => o.Id));

            if(!HDDIds.Contains(1))
            {
                db.HDDs.Add(new HDD
                {
                    Id = 1,
                    MB = 100,
                    Name = "SunDisk Mini",
                    Price = 59
                });
            }

            var NetworkCardIds = new HashSet<int>(db.NetworkCards.Select(o => o.Id));

            if(!NetworkCardIds.Contains(1))
            {
                db.NetworkCards.Add(new NetworkCard
                {
                    Id = 1,
                    Kbs = 128,
                    Name = "PIMM Card",
                    Price = 30
                });
            }

            var MotherboardIds = new HashSet<int>(db.Motherboards.Select(o => o.Id));

            if(!MotherboardIds.Contains(1))
            {
                db.Motherboards.Add(new Motherboard
                {
                    Id = 1,
                    SataSlots = 2,
                    CPUSlots = 1,
                    PCISlots = 2,
                    RAMSlots = 2,
                    Name = "MISA Board",
                    Price = 200
                });
            }

            db.SaveChanges();
        }
    }
}