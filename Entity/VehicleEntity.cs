using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;

namespace TestASPNET.Entity
{
    public class VehicleEntity
    {
        public int VehicleId { get; set; }

        public string Type { get; set; }

        public string ManufacturerNameShort { get; set; }

        public decimal Price { get; set; }

        public string ReturnCode { get; set; }
    }
}
