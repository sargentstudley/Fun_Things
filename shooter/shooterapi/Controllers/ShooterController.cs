using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace shooter.shooterapi.Controllers
{
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