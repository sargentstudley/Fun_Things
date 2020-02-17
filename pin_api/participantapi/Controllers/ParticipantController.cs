namespace participant.participantapi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class ParticipantController : ControllerBase
    {
        [HttpGet("{id}")]
        public Participant Get(int id)
        {
            return new Participant(id, "DefaultName");
        }
    }
}