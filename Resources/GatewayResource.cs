using gatewayapi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gatewayapi.Resources
{
    public class GatewayResource
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public IList<PeripheralDevice> Devices { get; set; } = new List<PeripheralDevice>();
    }
}
