using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestASPNET.DTO;

namespace TestASPNET.Services
{
    public interface IVehicleService
    {
        List<Vehicle> getAll();
        ProcessVehicleResponse addVehicle();

    }
}
