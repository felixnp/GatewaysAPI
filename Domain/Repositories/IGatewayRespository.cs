using gatewayapi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gatewayapi.Domain.Repositories
{
    public interface IGatewayRepository
    {
        Task<ActionResult<IEnumerable<Gateway>>> ListAsync();
        Task AddAsync(Gateway gateway);
        Task<ActionResult<Gateway>> GetAsync(string id);
    }
	
}
