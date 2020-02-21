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
        public Participant[] Get()
        {
            return _datastore.All().ToArray();
        }

        
        [HttpGet("{id}")]
        public Participant Get(int id)
        {
            return _datastore.Single(p => p.ID == id);
        }

        [HttpPut]
        public IEnumerable<Participant> Put(Participant[] participants)
        {
            return _datastore.Add(participants);
        }
    }
}