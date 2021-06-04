using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gatewayapi.Resources
{
    public class DeviceResource
    {
        public int Uid { get; set; }
        public string Vendor { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Online { get; set; }
    }
}
