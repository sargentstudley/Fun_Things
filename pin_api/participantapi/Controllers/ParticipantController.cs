namespace participant.participantapi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using participantapi.DataStore;
    using System.Linq;
    using System.Collections.Generic;

    [ApiController]
    [Route("[controller]")]
    public class ParticipantController : ControllerBase
    {
        private IRepository<Participant> _datastore;
        public ParticipantController(IRepository<Participant> datastore)
        {
            _datastore = datastore;
        }

        [HttpGet]
        public ActionResult<Participant[]> Get()
        {
            return _datastore.All().ToArray();
        }

        
        [HttpGet("{id}")]
        public ActionResult<Participant> Get(int id)
        {
            var result = _datastore.Single(p => p.ID == id);
            if (result != null) return result;
            return NotFound();
        }

        [HttpPut]
        public ActionResult<IEnumerable<Participant>> Put(Participant[] participants)
        {
            return _datastore.Add(participants).ToArray();
        }
    }
}