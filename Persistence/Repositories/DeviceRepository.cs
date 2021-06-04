using gatewayapi.Domain.Models;
using gatewayapi.Domain.Repositories;
using gatewayapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gatewayapi.Persistence.Repositories
{
    public class DeviceRepository : BaseRepository, IDeviceRepository
    {
        public DeviceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PeripheralDevice>> ListByGateway(string id)
        {
            return await _context.PeripheralDevices.Include(p => p.Gateway).Where(x => x.GatewayID == id).ToListAsync();
        }

        public async Task AddAsync(PeripheralDevice device)
        {
            await _context.PeripheralDevices.AddAsync(device);
        }

        public async Task<PeripheralDevice> GetAsync(int id)
        {
            return await _context.PeripheralDevices.FirstOrDefaultAsync(x => x.Uid == id);
        }

        public void Remove(PeripheralDevice device)
        {
            _context.PeripheralDevices.Remove(device);
        }

    }
}
