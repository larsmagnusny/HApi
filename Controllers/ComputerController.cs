using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HApi.Models;
using HApi.Crypto;
using HApi.DataAccess;
using HApi.Authorization;
using Microsoft.EntityFrameworkCore;

namespace HApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComputerController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly HContext _db;

        public ComputerController(ILogger<LoginController> logger, HContext context)
        {
            _logger = logger;
            _db = context;
        }

        [HttpGet]
        [VerifyToken]
        public IEnumerable<ComputerResult> Get(Guid token)
        {
            Guid userGuid = (Guid)HttpContext.Items["UserId"];
            var user = _db.Users
                .Include(o => o.Computers)
                    .ThenInclude(o => o.Motherboard)
                .Include(o => o.Computers)
                    .ThenInclude(o => o.CPUs)
                    .ThenInclude(o => o.CPU)
                .Include(o => o.Computers)
                    .ThenInclude(o => o.GPUs)
                    .ThenInclude(o => o.GPU)
                .Include(o => o.Computers)
                    .ThenInclude(o => o.RAMs)
                    .ThenInclude(o => o.RAM)
                .Include(o => o.Computers)
                    .ThenInclude(o => o.HDDs)
                    .ThenInclude(o => o.HDD)
                .Include(o => o.Computers)
                    .ThenInclude(o => o.NetworkCards)
                    .ThenInclude(o => o.NetworkCard)
                .AsNoTracking()
                .FirstOrDefault(o => o.UserId == userGuid);

            var result = new List<ComputerResult>();

            foreach(var computer in user.Computers)
            {
                var motherboard = computer.Motherboard;
                var rCPUs = new List<CPUResult>();
                var rGPUs = new List<GPUResult>();
                var rHDDs = new List<HDDResult>();
                var rNETs = new List<NETResult>();
                var rRAMs = new List<RAMResult>();

                foreach (var cpu in computer.CPUs) {
                    rCPUs.Add(new CPUResult
                    {
                        NumCores = cpu.CPU.NumCores,
                        MHZ = cpu.CPU.MHZ,
                        Name = cpu.CPU.Name
                    });
                }

                foreach (var gpu in computer.GPUs)
                {
                    rGPUs.Add(new GPUResult
                    {
                        CoreMhz = gpu.GPU.CoreMhz,
                        MB = gpu.GPU.MB,
                        MemMhz = gpu.GPU.MemMhz,
                        Name = gpu.GPU.Name,
                        NumCores = gpu.GPU.NumCores
                    });
                }

                foreach (var hdd in computer.HDDs)
                {
                    rHDDs.Add(new HDDResult
                    {
                        MB = hdd.HDD.MB,
                        Name = hdd.HDD.Name
                    });
                }

                foreach (var ram in computer.RAMs)
                {
                    rRAMs.Add(new RAMResult
                    {
                        MB = ram.RAM.MB,
                        MHZ = ram.RAM.MHZ,
                        Name = ram.RAM.Name
                    });
                }

                foreach (var net in computer.NetworkCards)
                {
                    rNETs.Add(new NETResult
                    {
                        Kbs = net.NetworkCard.Kbs,
                        Name = net.NetworkCard.Name
                    });
                }

                result.Add(new ComputerResult
                {
                    Cpus = rCPUs.ToArray(),
                    Gpus = rGPUs.ToArray(),
                    Hdds = rHDDs.ToArray(),
                    Nets = rNETs.ToArray(),
                    Rams = rRAMs.ToArray(),
                    SataSlots = motherboard?.SataSlots ?? 0,
                    CPUSlots = motherboard?.CPUSlots ?? 0,
                    PCISlots = motherboard?.PCISlots ?? 0,
                    RAMSlots = motherboard?.RAMSlots ?? 0,
                    Name = motherboard?.Name
                });
            }

            return result;
        }
    }
}
