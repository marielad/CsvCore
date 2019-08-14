using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestASPNET.Entity;

namespace TestASPNET.Services
{
    public interface IVehicleService
    {
        List<VehicleEntity> getAll();
        List<VehicleEntity> exportAllValids();
        VehicleEntity addVehicle(VehicleEntity vehicleEntity);

    }
}
