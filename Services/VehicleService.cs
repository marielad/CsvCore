using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestASPNET.Services;
using Microsoft.EntityFrameworkCore;
using TestASPNET.Entity;
using TestASPNET.DTO;

namespace TestASPNET.Services
{
    public class VehicleService : IVehicleService
    {

        private ICsvManager<VehicleEntity> csvManager = new CsvVehicle();

        public ProcessVehicleResponse addVehicle()
        {
            throw new NotImplementedException();
        }

        public List<VehicleEntity> getAll()
        {
            return csvManager.readCsv("./vehicles.csv");
        }
    }
}
