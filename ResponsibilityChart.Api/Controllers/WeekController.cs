using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ResponsibilityChart.Api.Models;

namespace ResponsibilityChart.Api.Controllers
{

  [ApiController]
  [Produces("application/json")]
  [Route("api/[controller]")]
  public class WeekController : ControllerBase
  {
    private readonly ILogger<WeekController> logger;

    public WeekController(ILogger<WeekController> logger)
    {
      this.logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
      // get week
      return Ok(new Week());
    }
  }
}