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
            StreamReader sr = new StreamReader(csvPath);
            CsvReader reader = new CsvReader(sr);
            IEnumerable<VehicleEntity> vehicleEntities = reader.GetRecords<VehicleEntity>();
            sr.Close();
            return vehicleEntities.ToList();
        }

        public void writeCsv(List<VehicleEntity> objectList)
        {
            StreamReader sr = new StreamReader("test.csv");
            //For easy understanding we will be writing same csv data read from one test.csv file to another copyfile.csv file
            StreamWriter write = new StreamWriter("copyfile.csv");

            //Csv reader reads the stream
            CsvReader csvread = new CsvReader(sr);

            //Csv writer stream
            CsvWriter csw = new CsvWriter(write);

            //csvread will fetch all record in one go to the IEnumerable object record
            IEnumerable<VehicleEntity> record = csvread.GetRecords<VehicleEntity>();

            foreach (var rec in record) // Each record will be fetched and printed on the screen
            { 
                //same time writes the csv file to another file : copyfile.csv
                csw.WriteRecord<VehicleEntity>(rec);
            }
            sr.Close();
            write.Close();//close file streams
        }
    }
}
