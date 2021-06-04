using AutoMapper;
using gatewayapi.Domain.Models;
using gatewayapi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gatewayapi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveGatewayResource, Gateway>();
            CreateMap<SaveDeviceResource, PeripheralDevice>();
        }
    }
}
