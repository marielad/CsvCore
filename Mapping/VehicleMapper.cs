using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TestASPNET.Entity;
using TestASPNET.DTO;

namespace TestASPNET.Mapping
{
    public class VehicleMapper : Profile
    {
        public VehicleMapper() {
            CreateMap<Vehicle, VehicleEntity>().ForMember(dest => dest.ReturnCode, opt => opt.Ignore()).ReverseMap();
            CreateMap<ProcessVehicleResponse, VehicleEntity>()
                .ForMember(dest => dest.Type, opt => opt.Ignore())
                .ForMember(dest => dest.ManufacturerNameShort, opt => opt.Ignore())
                .ForMember(dest => dest.Price, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
