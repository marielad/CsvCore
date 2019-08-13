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
    [SwaggerTag("Create, read, update and delete Vehicles")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehiclesService;
        private readonly IMapper _mapper;

        public VehiclesController(IVehicleService vehiclesService, IMapper mapper)
        {
            _vehiclesService = vehiclesService;
            _mapper = mapper;
        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Gets all vehicles",
            Description = "Gets all vehicles valid or not",
            OperationId = "Get"
            )]
        [SwaggerResponse(201, "Returns a list of vehicles", typeof(List<Vehicle>))]
        [SwaggerResponse(400, "BAD REQUEST")]
        public ActionResult<IEnumerable<Vehicle>> Get()
        {
            return _vehiclesService.getAll();
        }

        [HttpGet()]
        [Route("Export/valids")]
        [Produces("text/csv")]
        [SwaggerOperation(
            Summary = "Gets all valid vehicles",
            Description = "Gets all valid vehicles in a csv file",
            OperationId = "Get"
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
            OperationId = "Add"
            )]
        [SwaggerResponse(201, "The vehicle was added", typeof(ProcessVehicleResponse))]
        [SwaggerResponse(400, "BAD REQUEST")]
        public void Post(
            [SwaggerParameter(Description = "Vehicle json object you want to add", Required = true)]
            [FromBody] Vehicle value )
        {

        }

        [HttpPost]
        [Route("Import/vehicles")]
        [Produces("text/csv")]
        [SwaggerOperation(
            Summary = "Adds a list of new Vehicles from a csv file",
            Description = "Adds a list of new Vehicles from a csv file",
            OperationId = "Add"
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
