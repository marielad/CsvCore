using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestASPNET.Services;
using Microsoft.EntityFrameworkCore;
using TestASPNET.Entity;
using TestASPNET.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TestASPNET.Services
{
    public class VehicleService : IVehicleService
    {

        private ICsvManager<VehicleEntity> csvManager = new CsvVehicle();
        private string filePath = "./vehicles.csv";

        public List<VehicleEntity> getAll()
        {
            return csvManager.readCsv(filePath);
        }

        public List<VehicleEntity> exportAllValids()
        {
            List<VehicleEntity> allVehicleEntities = getAll();
            List<VehicleEntity> allValidVehicleEntities = new List<VehicleEntity>();

            foreach (var vehicle in allVehicleEntities)
            {
                if (vehicle.ReturnCode.Equals("Valid")) {
                    allValidVehicleEntities.Add(vehicle);
                }
            }

            return allValidVehicleEntities;
        }

        public VehicleEntity addVehicle(VehicleEntity vehicleEntity)
        {
            Console.WriteLine("Default Return Code: " + vehicleEntity.ReturnCode);
            VehicleEntity validatedVehicleEntity = vehicleValidator(vehicleEntity);
            Console.WriteLine("Valid Return Code: " + validatedVehicleEntity.ReturnCode);
            csvManager.writeCsv(validatedVehicleEntity, filePath);  
            return vehicleEntity;
        }

        private VehicleEntity vehicleValidator(VehicleEntity vehicleEntity) {
            Console.WriteLine(vehicleEntity.VehicleId.ToString());
            if (vehicleEntity.VehicleId.HasValue && vehicleEntity.Price.HasValue &&
                !String.IsNullOrEmpty(vehicleEntity.Type) && !String.IsNullOrEmpty(vehicleEntity.ManufacturerNameShort)
            )
            {
                vehicleEntity.ReturnCode = VehicleValidationResultCode.Valid.ToString();
            }
            else {
                vehicleEntity.ReturnCode = VehicleValidationResultCode.Invalid.ToString();
            }
            return vehicleEntity;
        }
    }
}
