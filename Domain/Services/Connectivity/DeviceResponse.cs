using gatewayapi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gatewayapi.Domain.Services.Connectivity
{
    public class DeviceResponse: BaseResponse
    {
        public PeripheralDevice Device { get; private set; }

        private DeviceResponse(bool success, string message, PeripheralDevice device) : base(success, message)
        {
            Device = device;
        }

        public DeviceResponse(PeripheralDevice device) : this(true, string.Empty, device)
        { }

        public DeviceResponse(string message) : this(false, message, null)
        { }
    }
	
}
