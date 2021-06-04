using gatewayapi.Domain.Models;
using gatewayapi.Domain.Services.Connectivity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gatewayapi.Domain.Services
{
    public interface IGatewayService
    {
        Task<ActionResult<IEnumerable<Gateway>>> ListAsync();
        Task<SaveGatewayResponse> SaveAsync(Gateway gateway);
        Task<ActionResult<Gateway>> GetAsync(string id);
    }
}
