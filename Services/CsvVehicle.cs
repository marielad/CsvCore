using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestASPNET.DTO;
using TestASPNET.Entity;
using CsvHelper;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using CsvHelper.Configuration;

namespace TestASPNET.Services
{
    public class CsvVehicle : ICsvManager<VehicleEntity> 
    {
        public List<VehicleEntity> readCsv(string csvPath)
        {
            csvExists(csvPath);
            StreamReader streamReader = new StreamReader(csvPath);
            CsvReader csvReader = new CsvReader(streamReader);
            List<VehicleEntity> vehicleEntities = csvReader.GetRecords<VehicleEntity>().ToList();
            streamReader.Close();
            return vehicleEntities;
        }

        public void writeCsv(VehicleEntity vehicleEntity, string csvPath)
        {
            csvExists(csvPath);
            Console.WriteLine("Starts Writing");
            StreamWriter writer = new StreamWriter(csvPath);
            CsvWriter csw = new CsvWriter(writer, new Configuration().UseNewObjectForNullReferenceMembers = true);
            csw.WriteRecord(vehicleEntity);
            writer.Flush();
            writer.Close();
            Console.WriteLine("Finish Writing");
        }

        public void writeListToCsv(List<VehicleEntity> vehicleEntityList, string csvPath)
        {
            csvExists(csvPath);
            StreamWriter writer = new StreamWriter(File.OpenWrite(csvPath));
            CsvWriter csw = new CsvWriter(writer, new Configuration().UseNewObjectForNullReferenceMembers = true);
            csw.WriteRecords(vehicleEntityList);
            writer.Flush();
            writer.Close();
        }

        private void csvExists(string csvPath) {
            if (!File.Exists(csvPath)) {
                File.Create(csvPath).Dispose();
                Console.WriteLine("New File Created!");
            }
        }
    }
}
