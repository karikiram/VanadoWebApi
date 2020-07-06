using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vanado.Models;

namespace Vanado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FailureController : ControllerBase
    {
        private readonly FailureRepository Failurerepository;

        public FailureController()
        {
            Failurerepository = new FailureRepository();
        }
        [HttpGet]
        public IEnumerable<Failure> GetFailures()
        {
            return Failurerepository.GetAllFailures();
        }

        [HttpGet("{id}")]
        public Failure GetFailure(int id)
        {
            return Failurerepository.GetFailureById(id);
        }

        [HttpPost]
        public void PostFailure([FromBody]Failure fail)
        {
            if (ModelState.IsValid)
                Failurerepository.AddFailure(fail);
        }

        [HttpPost("{id}")]
        public void ChangeFailureStatus(int id)
        {
            Failurerepository.UpdateFailureStatus(id);
        }

        [HttpPut("{id}")]
        public void PutFailure(int id, [FromBody]Failure fail)
        {
            fail.Failure_id = id;
            if (ModelState.IsValid)
                Failurerepository.UpdateFailure(fail);
        }

        [HttpDelete("{id}")]
        public void DeleteFailure(int id)
        {
            Failurerepository.DeleteFailure(id);
        }

    }
}
