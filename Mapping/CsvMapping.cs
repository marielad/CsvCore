using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestASPNET.Entity;

namespace TestASPNET.Mapping
{
    public class CsvMapping : ClassMap<VehicleEntity>
    {
        public CsvMapping() {
            Map(m => m.VehicleId).Index(0).Name("VehicleId");
            Map(m => m.Type).Index(1).Name("Type");
            Map(m => m.ManufacturerNameShort).Index(2).Name("ManufacturerNameShort");
            Map(m => m.Price).Index(3).Name("Price");
            Map(m => m.ReturnCode).Index(4).Name("ReturnCode");
        }
    }
}
