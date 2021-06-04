using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace gatewayapi.Domain.Models
{
    public class PeripheralDevice
    {
        public int Uid { get; set; }
        public string Vendor { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Online { get; set; }
        [JsonIgnore]
        public string GatewayID { get; set; }
        [JsonIgnore]
        public Gateway Gateway { get; set; }
    }
}
