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
        }
    }
}
