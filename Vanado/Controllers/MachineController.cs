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
    public class MachineController : ControllerBase
    {
        private readonly MachineRepository Machinerepository;

        public MachineController()
        {
            Machinerepository = new MachineRepository();
        }
        [HttpGet]
        public IEnumerable<Machine> GetMachines()
        {
            return Machinerepository.GetAllMachines();
        }

        [HttpGet("{id}")]
        public Machine GetMachine(int id)
        {
            return Machinerepository.GetMachineById(id);
        }

        [HttpPost]
        public void PostMachine([FromBody] Machine mach)
        {
            if (ModelState.IsValid)
                Machinerepository.AddMachine(mach);
        }

        [HttpPut("{id}")]
        public void PutMachine(int id, [FromBody] Machine mach)
        {
            mach.Machine_id = id;
            if (ModelState.IsValid)
                Machinerepository.UpdateMachine(mach);
        }

        [HttpDelete("{id}")]
        public void DeleteMachine(int id)
        {
            Machinerepository.DeleteMachine(id);
        }
    }
}
