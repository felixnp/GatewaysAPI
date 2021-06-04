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
    public class DevicesController : Controller
    {
        private readonly IDeviceService _deviceService;
        private readonly IMapper _mapper;

        public DevicesController(IDeviceService deviceService, IMapper mapper)
        {
            _deviceService = deviceService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDeviceResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            };
            try
            {
                var device = _mapper.Map<SaveDeviceResource, PeripheralDevice>(resource);
                var result = await _deviceService.SaveAsync(device);

                if (!result.Success)
                    return BadRequest(result.Message);

                var categoryResource = _mapper.Map<PeripheralDevice, DeviceResource>(result.Device);
                return Ok(categoryResource);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _deviceService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<PeripheralDevice, DeviceResource>(result.Device);
            return Ok(categoryResource);
        }
		
    }
}
