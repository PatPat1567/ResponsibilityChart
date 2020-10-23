using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResponsibilityChart.Api.Models;

namespace ResponsibilityChart.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ResponsibilityController : ControllerBase
  {
    private readonly ILogger<ResponsibilityController> logger;

    public ResponsibilityController(ILogger<ResponsibilityController> logger)
    {
      this.logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
      //Return list of responsibilities
      return Ok(new List<Responsibility>());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      //Return single responsibility
      return Ok(new Responsibility());
    }

    [HttpPost]
    public IActionResult Post([FromBody]Responsibility responsibility)
    {
      //Add new responsibility
      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody]Responsibility responsibility)
    {
      //Update a responsibility
      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      //Delete a responsibility

      return Ok();
    }
    
  }
}