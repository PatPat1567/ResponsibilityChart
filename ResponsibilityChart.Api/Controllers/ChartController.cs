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
  public class ChartController : ControllerBase
  {
    private readonly ILogger<ChartController> logger;
    
    public ChartController(ILogger<ChartController> logger)
    {
      this.logger = logger;
    }
    
    /// <summary>
    /// Gets a list of all charts.
    /// </summary>
    /// <returns> A list of chart items </returns>
    /// <response code="200">Returns the list of charts</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Get()
    {
      // Return full list of charts

      return Ok(new List<Chart>());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      // Return chart

      return Ok(new Chart());
    }

    [HttpPost]
    public IActionResult Post([FromBody]Chart chart)
    {
      // Add chart

      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody]Chart chart)
    {
      // Update chart

      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      // Delbete chart8ui

      return Ok();
    }
  }
}