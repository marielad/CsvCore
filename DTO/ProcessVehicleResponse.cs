using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestASPNET.DTO
{
    public class ProcessVehicleResponse
    {
        public int VehicleId { get; set; }
        public VehicleValidationResultCode ReturnCode { get; set; }
    }

}
