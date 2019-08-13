using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestASPNET.DTO
{
    public class Vehicle
    {
        [JsonProperty("VehicleId")]
        public int VehicleId { get; set; }
        [JsonProperty("Type")]
        public string Type { get; set; }
        [JsonProperty("ManufacturerNameShort")]
        public string ManufacturerNameShort { get; set; }
        [JsonProperty("Price")]
        public decimal Price { get; set; }
        public VehicleValidationResultCode ReturnCode { get; set; }
    }
}
