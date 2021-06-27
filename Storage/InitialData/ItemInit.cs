using HApi.Storage.Entities;
using LiteDB;

namespace HApi.Storage.InitialData {
    public static class ItemInit {
        public static void Init(LiteDatabase db)
        {
            var cpus = db.GetCollection<CPU>();

            if(!cpus.Exists(o => o.Id == 1))
            {
                cpus.Insert(new CPU
                {
                    Id = 1,
                    MHZ = 200,
                    Name = "Irtel Perntium",
                    NumCores = 1,
                    Price = 120
                });

                cpus.EnsureIndex(o => o.Id);
            }

            var RAMs = db.GetCollection<RAM>();

            if(!RAMs.Exists(o => o.Id == 1))
            {
                RAMs.Insert(new RAM
                {
                    Id = 1,
                    MB = 128,
                    MHZ = 100,
                    Name = "Mextor SDRAM",
                    Price = 40
                });

                RAMs.EnsureIndex(o => o.Id);
            }

            var GPUs = db.GetCollection<GPU>();

            if(!GPUs.Exists(o => o.Id == 1))
            {
                GPUs.Insert(new GPU
                {
                    Id = 1,
                    CoreMhz = 100,
                    MB = 25,
                    MemMhz = 100,
                    NumCores = 1,
                    Price = 100,
                    Name = "Nidia GTX 0.1"
                });

                GPUs.EnsureIndex(o => o.Id);
            }

            var HDDs = db.GetCollection<HDD>();

            if(!HDDs.Exists(o => o.Id == 1))
            {
                HDDs.Insert(new HDD
                {
                    Id = 1,
                    MB = 100,
                    Name = "SunDisk Mini",
                    Price = 59
                });

                HDDs.EnsureIndex(o => o.Id);
            }

            var NetworkCards = db.GetCollection<NetworkCard>();

            if(!NetworkCards.Exists(o => o.Id == 1))
            {
                NetworkCards.Insert(new NetworkCard
                {
                    Id = 1,
                    Kbs = 128,
                    Name = "PIMM Card",
                    Price = 30
                });

                NetworkCards.EnsureIndex(o => o.Id);
            }

            var Motherboards = db.GetCollection<Motherboard>();

            if(!Motherboards.Exists(o => o.Id == 1))
            {
                Motherboards.Insert(new Motherboard
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
        }
    }
}