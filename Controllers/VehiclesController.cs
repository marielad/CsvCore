using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Swashbuckle.AspNetCore.Annotations;
using TestASPNET.DTO;
using TestASPNET.Entity;
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
        [Route("validvehicles")]
        [Produces("text/csv")]
        [SwaggerOperation(
            Summary = "Gets all valid vehicles",
            Description = "Gets all valid vehicles in a csv file",
            Tags = new[] { "CSV" }
            )]
        [SwaggerResponse(200, "Returns a csv file with the valid vehicles", typeof(List<Vehicle>))]
        [SwaggerResponse(204, "No content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(406, "Not Acceptable")]
        public ActionResult<FileResult> CsvExport()
        {
            List<Vehicle> vehicles = _mapper.Map<List<Vehicle>>(_service.exportAllValids());
            return ;
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
            ProcessVehicleResponse processVehicleResponse = new ProcessVehicleResponse();
            processVehicleResponse =_mapper.Map<ProcessVehicleResponse>(
                _service.addVehicle(_mapper.Map<VehicleEntity>(value)));
        }

        [HttpPost]
        [Route("/vehicles.csv")]
        [Produces("text/csv")]
        [SwaggerOperation(
            Summary = "Adds a list of new Vehicles from a csv file",
            Description = "Adds a list of new Vehicles from a csv file",
            Tags = new[] { "CSV" }
            )]
        [SwaggerResponse(201, "The list of vehicles was added", typeof(List<ProcessVehicleResponse>))]
        [SwaggerResponse(400, "Bad Request")]
        public IActionResult CsvImport(
            [SwaggerParameter(Description = "Csv file you want to import", Required = true)]
            [FromBody] FileResult value
            )
        {
            try
            {
                var file = Request.Form.Files[0];
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory());

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
