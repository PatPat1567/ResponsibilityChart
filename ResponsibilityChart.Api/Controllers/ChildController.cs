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
  public class ChildController : ControllerBase
  {
    private readonly ILogger<ChildController> logger;
    
    public ChildController(ILogger<ChildController> logger)
    {
      this.logger = logger;
    }
    
    /// <summary>
    /// Gets a list of all children.
    /// </summary>
    /// <returns> A list of children items </returns>
    /// <response code="200">Returns the list of children</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Get()
    {
      // Return full list of children

      return Ok(new List<Child>());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      // Return child

      return Ok(new Child());
    }

    [HttpPost]
    public IActionResult Post([FromBody]Child child)
    {
      // Add child

      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody]Child child)
    {
      // Update child

      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      // Delete child

      return Ok();
    }
  }
}