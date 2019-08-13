using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestASPNET.DTO;
using TestASPNET.Entity;
using CsvHelper;
using System.IO;

namespace TestASPNET.Services
{
    public class CsvVehicle : ICsvManager<VehicleEntity> 
    {
        public List<VehicleEntity> readCsv(string csvPath)
        {
            StreamReader streamReader = new StreamReader(csvPath);
            CsvReader csvReader = new CsvReader(streamReader);
            List<VehicleEntity> vehicleEntities = csvReader.GetRecords<VehicleEntity>().ToList();
            streamReader.Close();
            return vehicleEntities;
        }

        public void writeCsv(VehicleEntity vehicleEntity, string csvPath)
        {
            StreamWriter write = new StreamWriter("copyfile.csv");
            CsvWriter csw = new CsvWriter(write);
            csw.WriteRecord<VehicleEntity>(vehicleEntity);
            write.Close();
        }

        public void writeListToCsv(List<VehicleEntity> vehicleEntityList, string csvPath)
        {
            StreamWriter write = new StreamWriter(csvPath);
            CsvWriter csw = new CsvWriter(write);

            foreach (var vehicleEntity in vehicleEntityList) 
            {
                csw.WriteRecord<VehicleEntity>(vehicleEntity);
            }
            write.Close();
        }
    }
}
