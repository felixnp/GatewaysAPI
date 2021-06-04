using gatewayapi.Domain.Models;
using gatewayapi.Domain.Services.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gatewayapi.Domain.Services
{
    public interface IDeviceService 
    {
        Task<IEnumerable<PeripheralDevice>> ListByGateway(string id);
        Task<DeviceResponse> SaveAsync(PeripheralDevice device);
        Task<PeripheralDevice> GetAsync(int id);
        Task<DeviceResponse> DeleteAsync(int id);
    }
}
