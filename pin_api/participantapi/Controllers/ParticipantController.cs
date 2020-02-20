namespace participant.participantapi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using participantapi.DataStore;

    [ApiController]
    [Route("[controller]")]
    public class ParticipantController : ControllerBase
    {
        private IRepository<Participant> _datastore;
        public ParticipantController(IRepository<Participant> datastore)
        {
            _datastore = datastore;
        }
        
        [HttpGet("{id}")]
        public Participant Get(int id)
        {
            return _datastore.Single(p => p.ID == id);
        }

        [HttpPut]
        public void Put(Participant[] participants)
        {
            _datastore.Add(participants);
        }
    }
}