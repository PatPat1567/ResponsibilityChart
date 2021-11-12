using System.Runtime.Versioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResponsibilityChart.Api.Models;
using ResponsibilityChart.Api.Interfaces;

namespace ResponsibilityChart.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ResponsibilityController : ControllerBase
  {
    private readonly ILogger<ResponsibilityController> logger;
    private readonly IResponsibilityService service;

    public ResponsibilityController(ILogger<ResponsibilityController> logger, IResponsibilityService service)
    {
      this.logger = logger;
      this.service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
      var responsiblities = service.Get();
      return Ok(responsiblities);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      var responsibility = service.Get(id);
      if (responsibility is null)
        return BadRequest();
      return Ok(responsibility);
    }

    [HttpPost]
    public IActionResult Create([FromBody]Responsibility responsibility)
    {
      service.Add(responsibility);
      return CreatedAtAction(nameof(Created), new { id = responsibility.Id}, responsibility);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody]Responsibility responsibility)
    {
      if (id != responsibility.Id)
        return BadRequest();
      
      var existingResponsibility = service.Get(id);
      if (existingResponsibility is null)
        return NotFound();

      service.Update(responsibility);

      return NoContent();

    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var responsibility = service.Get(id);

      if (responsibility is null)
        return NotFound();

      service.Delete(id);
      return NoContent();
    }
    
  }
}