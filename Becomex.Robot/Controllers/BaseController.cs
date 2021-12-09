using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Becomex.Robot.Api.Controllers
{
    /// <summary>
    /// Base controller.
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]s")]
    public abstract class BaseController : ControllerBase
    {
        
    }
}
