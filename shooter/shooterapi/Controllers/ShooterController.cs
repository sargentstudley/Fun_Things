namespace shooter.shooterapi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class ShooterController : ControllerBase
    {
        [HttpGet("{id}")]
        public Shooter Get(int id)
        {
            return new Shooter(id, "DefaultName");
        }
    }
}