using gatewayapi.Domain.Services.Connectivity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gatewayapi.Resources
{
    public class SaveGatewayResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(15)]
        public string IpAddress { get; set; }
    }
}
