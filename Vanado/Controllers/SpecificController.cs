using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vanado.Models;

namespace Vanado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificController : ControllerBase
    {
        private readonly FailureRepository Failurerepository;
        private readonly MachineRepository Machinerepository;

        public SpecificController()
        {
            Failurerepository = new FailureRepository();
            Machinerepository = new MachineRepository();
        }

        [HttpGet("{id}")]
        public List<Failure> GetFailures(int id)
        {
            return Failurerepository.GetFailuresByMachineId(id);
        }
    }
}
