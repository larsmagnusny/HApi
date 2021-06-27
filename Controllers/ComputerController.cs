using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HApi.Models;
using HApi.Storage;
using HApi.Storage.Entities;
using HApi.Crypto;
using HApi.DataAccess;

namespace HApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComputerController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IHDbContext _db;

        public ComputerController(ILogger<LoginController> logger, IHDbContext context)
        {
            _logger = logger;
            _db = context;
        }

        [HttpGet]
        public IEnumerable<ComputerResult> Get(Guid token)
        {
            if (!TokenStorage.CheckToken(token))
                return new List<ComputerResult>();

            var userGuid = TokenStorage.FindUser(token);

            if (userGuid.HasValue) {

                var userComputers = _db.Database.GetCollection<UserComputer>();
                var userCPUs = _db.Database.GetCollection<ComputerCPUParts>();
                var userGPUs = _db.Database.GetCollection<ComputerGPUParts>();
                var userHDDs = _db.Database.GetCollection<ComputerHDDParts>();
                var userNETs = _db.Database.GetCollection<ComputerNetworkCardParts>();
                var userRAMs = _db.Database.GetCollection<ComputerRAMParts>();
                
                var cpus = _db.Database.GetCollection<CPU>();
                var gpus = _db.Database.GetCollection<GPU>();
                var hdds = _db.Database.GetCollection<HDD>();
                var nets = _db.Database.GetCollection<NetworkCard>();
                var rams = _db.Database.GetCollection<RAM>();
                var comps = _db.Database.GetCollection<Computer>();

                var motherboards = _db.Database.GetCollection<Motherboard>();

                var computers = userComputers.Find(o => o.UserId == userGuid.Value);

                var result = new List<ComputerResult>();

                foreach(var item in computers)
                {
                    var computer = comps.FindOne(o => o.Id == item.ComputerId);
                    var rCPUs = new List<CPUResult>();
                    var rGPUs = new List<GPUResult>();
                    var rHDDs = new List<HDDResult>();
                    var rNETs = new List<NETResult>();
                    var rRAMs = new List<RAMResult>();

                    var motherboard = motherboards.FindOne(o => o.Id == computer.MotherboardId);
                    var uCPUs = userCPUs.Find(o => o.ComputerId == item.ComputerId);
                    var uGPUs = userGPUs.Find(o => o.ComputerId == item.ComputerId);
                    var uHDDs = userHDDs.Find(o => o.ComputerId == item.ComputerId);
                    var uNETs = userNETs.Find(o => o.ComputerId == item.ComputerId);
                    var uRAMs = userRAMs.Find(o => o.ComputerId == item.ComputerId);

                    foreach (var uCPU in uCPUs) {
                        var cpu = cpus.FindOne(o => o.Id == uCPU.CPUId);

                        if (cpu == null)
                            continue;

                        rCPUs.Add(new CPUResult
                        {
                            NumCores = cpu.NumCores,
                            MHZ = cpu.MHZ,
                            Name = cpu.Name
                        });
                    }

                    foreach (var uGPU in uGPUs)
                    {
                        var gpu = gpus.FindOne(o => o.Id == uGPU.GPUId);

                        if (gpu == null)
                            continue;

                        rGPUs.Add(new GPUResult
                        {
                            CoreMhz = gpu.CoreMhz,
                            MB = gpu.MB,
                            MemMhz = gpu.MemMhz,
                            Name = gpu.Name,
                            NumCores = gpu.NumCores
                        });
                    }

                    foreach (var uHDD in uHDDs)
                    {
                        var hdd = hdds.FindOne(o => o.Id == uHDD.HDDId);

                        if (hdd == null)
                            continue;

                        rHDDs.Add(new HDDResult
                        {
                            MB = hdd.MB,
                            Name = hdd.Name
                        });
                    }

                    foreach (var uRAM in uRAMs)
                    {
                        var ram = rams.FindOne(o => o.Id == uRAM.RAMId);

                        if (ram == null)
                            continue;

                        rRAMs.Add(new RAMResult
                        {
                            MB = ram.MB,
                            MHZ = ram.MHZ,
                            Name = ram.Name
                        });
                    }

                    foreach (var uNET in uNETs)
                    {
                        var net = nets.FindOne(o => o.Id == uNET.NetworkCardId);

                        if (net == null)
                            continue;

                        rNETs.Add(new NETResult
                        {
                            Kbs = net.Kbs,
                            Name = net.Name
                        });
                    }

                    result.Add(new ComputerResult
                    {
                        Cpus = rCPUs.ToArray(),
                        Gpus = rGPUs.ToArray(),
                        Hdds = rHDDs.ToArray(),
                        Nets = rNETs.ToArray(),
                        Rams = rRAMs.ToArray(),
                        SataSlots = motherboard.SataSlots,
                        CPUSlots = motherboard.CPUSlots,
                        PCISlots = motherboard.PCISlots,
                        RAMSlots = motherboard.RAMSlots,
                        Name = motherboard.Name
                    });
                }

                return result;
            }

            return new List<ComputerResult>();
        }
    }
}
