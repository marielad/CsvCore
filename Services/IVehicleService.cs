using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestASPNET.Entity;
using TestASPNET.DTO;

namespace TestASPNET.Services
{
    public interface IVehicleService
    {
        List<VehicleEntity> getAll();
        ProcessVehicleResponse addVehicle();

    }
}
