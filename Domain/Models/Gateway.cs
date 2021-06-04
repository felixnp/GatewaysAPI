using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace gatewayapi.Domain.Models
{
    public class Gateway
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public IList<PeripheralDevice> Devices { get; set; } 
    }
}

