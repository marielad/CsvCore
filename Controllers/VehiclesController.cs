using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TestASPNET.DTO;
using TestASPNET.Services;

namespace TestASPNET.Controllers
{ 
    [SwaggerTag("Manage Vehicles")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {

        private IVehicleService _service = new VehicleService();
        private readonly IMapper _mapper;

        public VehiclesController(IMapper mapper) {
            _mapper = mapper;
        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Gets all vehicles",
            Description = "Gets all vehicles valid or not",
            Tags = new[] { "Vehicles"}
            )]
        [SwaggerResponse(201, "Returns a list of vehicles", typeof(List<Vehicle>))]
        [SwaggerResponse(400, "BAD REQUEST")]
        public ActionResult<IEnumerable<Vehicle>> Get()
        {
            List<Vehicle> vehicles = _mapper.Map<List<Vehicle>>(_service.getAll());
            return vehicles;
        }

        [HttpGet()]
        [Route("Export/vehicles.csv")]
        [Produces("text/csv")]
        [SwaggerOperation(
            Summary = "Gets all valid vehicles",
            Description = "Gets all valid vehicles in a csv file",
            Tags = new[] { "CSV" }
            )]
        [SwaggerResponse(201, "Returns a csv file with the valid vehicles", typeof(List<Vehicle>))]
        [SwaggerResponse(400, "BAD REQUEST")]
        public ActionResult<FileResult> CsvExport()
        {
            return null;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Adds a new Vehicle",
            Description = "Creates a new vehicle and returns the vehicle's id and its return code",
            Tags = new[] { "Vehicles" }
            )]
        [SwaggerResponse(201, "The vehicle was added", typeof(ProcessVehicleResponse))]
        [SwaggerResponse(400, "BAD REQUEST")]
        public void Post(
            [SwaggerParameter(Description = "Vehicle json object you want to add", Required = true)]
            [FromBody] Vehicle value )
        {
            Console.WriteLine("New Vehicle" + value.Type);
        }

        [HttpPost]
        [Route("Import/vehicles.csv")]
        [Produces("text/csv")]
        [SwaggerOperation(
            Summary = "Adds a list of new Vehicles from a csv file",
            Description = "Adds a list of new Vehicles from a csv file",
            Tags = new[] { "CSV" }
            )]
        [SwaggerResponse(201, "The list of vehicles was added", typeof(List<ProcessVehicleResponse>))]
        [SwaggerResponse(400, "BAD REQUEST")]
        public void CsvImport(
            [SwaggerParameter(Description = "Csv file you want to import", Required = true)]
            [FromBody] FileResult value
            )
        {
        }
    }
}
