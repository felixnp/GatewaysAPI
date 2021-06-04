using gatewayapi.Domain.Models;
using gatewayapi.Domain.Repositories;
using gatewayapi.Domain.Services;
using gatewayapi.Domain.Services.Connectivity;
using gatewayapi.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gatewayapi.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeviceService(IDeviceRepository deviceRepository, IUnitOfWork unitOfWork)
        {
            _deviceRepository = deviceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PeripheralDevice> GetAsync(int id)
        {
            return await _deviceRepository.GetAsync(id);
        }

        public async Task<IEnumerable<PeripheralDevice>> ListByGateway(string id)
        {
            return await _deviceRepository.ListByGateway(id);
        }
        public async Task<DeviceResponse> SaveAsync(PeripheralDevice device)
        {
            try
            {
                var gatewayDevices = await ListByGateway(device.GatewayID);
                if (gatewayDevices.ToList().Count > 9 )
                    throw new Exception("Only 10 peripheral devices allowed per gateway");

                await _deviceRepository.AddAsync(device);
                await _unitOfWork.CompleteAsync();

                return new DeviceResponse(device);
            }
            catch (Exception ex)
            {
                return new DeviceResponse($"Error while saving the peripheral  device to the database: {ex.Message}");
            }
        }

        public async Task<DeviceResponse> DeleteAsync(int id)
        {
            var existingDevice = await _deviceRepository.GetAsync(id);

            if (existingDevice == null)
                return new DeviceResponse("Device not found.");

            try
            {
                _deviceRepository.Remove(existingDevice);
                await _unitOfWork.CompleteAsync();

                return new DeviceResponse(existingDevice);
            }
            catch (Exception ex)
            {
                return new DeviceResponse($"Error deleting the peripheral device: {ex.Message}");
            }
        }
    }
}
