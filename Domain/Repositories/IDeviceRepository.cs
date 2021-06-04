using gatewayapi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gatewayapi.Domain.Repositories
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<PeripheralDevice>> ListByGateway(string id);
        Task AddAsync(PeripheralDevice device);
        Task<PeripheralDevice> GetAsync(int id);
        void Remove(PeripheralDevice device);
    }
	
}
