using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HApi.DataAccess.Entities
{
    public class ComputerNetworkCard
    {
        [ForeignKey("Computer")]
        public int ComputerId { get; set; }
        [ForeignKey("NetworkCard")]
        public int NetworkCardId { get; set; }

        public Computer Computer { get; set; }
        public NetworkCard NetworkCard { get; set; }
    }
}
