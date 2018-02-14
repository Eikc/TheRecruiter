using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Recruiters.Controllers
{
    [Produces("application/json")]
    [Route("candidates")]
    public class CandidatesController : Controller
    {
        private readonly InMemoryDatabase _database;

        public CandidatesController(InMemoryDatabase database)
        {
            _database = database;
        }

        // GET: api/Candidates
        //[HttpGet]
        //public IEnumerable<Candidate> Get()
        //{
        //    return _database.GetAll();
        //}

        // GET: api/Candidates?name="candidateName"
        [HttpGet]
        public Candidate Get([FromQuery(Name = "name")]string candidateName)
        {
            return _database.GetByName(candidateName);
        }

        // POST: api/Candidates
        [HttpPost]
        public IActionResult Post([FromForm]Candidate candidate)
        {
            _database.Add(candidate);

            return StatusCode(201);
        }

    }
}
