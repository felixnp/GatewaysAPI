using gatewayapi.Domain.Models;
using gatewayapi.Domain.Repositories;
using gatewayapi.Domain.Services;
using gatewayapi.Domain.Services.Connectivity;
using gatewayapi.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gatewayapi.Services
{
    public class GatewayService : IGatewayService
    {
        private readonly IGatewayRepository _gatewayRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GatewayService(IGatewayRepository gatewayRepository, IUnitOfWork unitOfWork)
        {
            _gatewayRepository = gatewayRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult<IEnumerable<Gateway>>> ListAsync()
        {
            return await _gatewayRepository. ListAsync();
        }

        public async Task<ActionResult<Gateway>> GetAsync(string id)
        {
            return await _gatewayRepository.GetAsync(id);
        }

        public async Task<SaveGatewayResponse> SaveAsync(Gateway gateway)
        {
            try
            {
                System.Net.IPAddress ip;
                if (!System.Net.IPAddress.TryParse(gateway.IpAddress, out ip))
                    return new SaveGatewayResponse("IP address is not Valid");

                await _gatewayRepository.AddAsync(gateway);
                await _unitOfWork.CompleteAsync();

                return new SaveGatewayResponse(gateway);
            }
            catch (Exception ex)
            {
                return new SaveGatewayResponse($"Error saving the Gateway: {ex.Message}");
            }
        }
    }
}
