using gatewayapi.Domain.Models;
using gatewayapi.Domain.Repositories;
using gatewayapi.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gatewayapi.Persistence.Repositories
{
    public class GatewayRepository : BaseRepository, IGatewayRepository
    {
        public GatewayRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ActionResult<IEnumerable<Gateway>>> ListAsync()
        {
            return await _context.Gateways.Include(x => x.Devices).ToListAsync();
        }

        public async Task<ActionResult<Gateway>> GetAsync( string id)
        {
            var gateway = await _context.Gateways.FirstOrDefaultAsync(x => x.Id == id);
            if (gateway!=null)
                _context.Entry(gateway).Collection(b => b.Devices).Load();
            return gateway;
        }

        public async Task AddAsync(Gateway gateway)
        {
            await _context.Gateways.AddAsync(gateway);
        }
    }
}
