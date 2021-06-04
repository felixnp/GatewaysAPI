using AutoMapper;
using gatewayapi.Domain.Models;
using gatewayapi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gatewayapi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Gateway, GatewayResource>();
            CreateMap<PeripheralDevice, DeviceResource>();
        }
    }
}
