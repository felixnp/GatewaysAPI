using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gatewayapi.Resources
{
    public class SaveDeviceResource
    {
        [Required]
        [MaxLength(50)]
        public string Vendor { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public bool Online { get; set; }
        [Required]
        [MaxLength(50)]
        public string GatewayID { get; set; }
    }
}
