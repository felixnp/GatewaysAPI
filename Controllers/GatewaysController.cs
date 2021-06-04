using AutoMapper;
using gatewayapi.Domain.Models;
using gatewayapi.Domain.Services;
using gatewayapi.Extensions;
using gatewayapi.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gatewayapi.Controllers
{
    [Route("/api/[controller]")]
    public class GatewaysController: Controller
    {
        private readonly IGatewayService _gatewayService;
        private readonly IMapper _mapper;

        public GatewaysController(IGatewayService gatewayService, IMapper mapper)
        {
            _gatewayService = gatewayService;
            _mapper = mapper;
        }

        // GET api/gateways
        [HttpGet]
        public async Task<IEnumerable<GatewayResource>> GetAllAsync()
        {
            var gateways = await _gatewayService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Gateway>, IEnumerable<GatewayResource>>(gateways.Value);
            return resources;
        }

        // GET api/gateways/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Gateway>> GetAsync(string id)
        {
            var response= await _gatewayService.GetAsync(id);
            if (response.Value != null)
                return Ok(response.Value);
            else
                return NotFound("Gateway not found");
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveGatewayResource resource)
        {
            if (!ModelState.IsValid)
                return  BadRequest(ModelState.GetErrorMessages());

            var gateway = _mapper.Map<SaveGatewayResource, Gateway>(resource);

            var result = await _gatewayService.SaveAsync(gateway);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Gateway, GatewayResource>(result.Gateway);
            return Ok(categoryResource);
        }
    }
}
