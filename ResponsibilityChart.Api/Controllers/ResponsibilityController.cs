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
  [Produces("application/json")]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public class ResponsibilityController : ControllerBase
  {
    private readonly ILogger<ResponsibilityController> logger;
    private readonly IResponsibilityService service;

    public ResponsibilityController(ILogger<ResponsibilityController> logger, IResponsibilityService service)
    {
      this.logger = logger;
      this.service = service;
    }

    /// <summary>
    /// Returns the full list of responsibilities.
    /// </summary>
    /// <returns>The list of resopnsibilities available.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     Get /api/Responsibility
    ///
    /// </remarks>
    /// <response code="200">Returns all responsibilities.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Get()
    {
      var responsiblities = service.Get();
      return Ok(responsiblities);
    }

    /// <summary>
    /// Returns the specific responsibility.
    /// </summary>
    /// <returns>The specific responsibility, if exists.</returns>
    /// <param name="id">The id of the responsibility.</param>
    /// <remarks>
    /// Sample request:
    ///
    ///     Get /api/Responsibility/1
    ///
    /// </remarks>
    /// <response code="200">Returns responsibility.</response>
    /// <response code="400">If the responsibility does not exist.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Get(int id)
    {
      var responsibility = service.Get(id);
      if (responsibility is null)
        return BadRequest();
      return Ok(responsibility);
    }

    /// <summary>
    /// Adds the specific responsibility.
    /// </summary>
    /// <returns>The new responsibility, if exists.</returns>
    /// <param name="responsibility">The new responsibility.</param>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/Responsibility
    ///     {
    ///        "name": "Responsibility Name",
    ///        "imageLink": "",
    ///        "recommendedAgeGroups": [
    ///           0
    ///        ]
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns responsibility.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Create([FromBody]Responsibility responsibility)
    {
      service.Add(responsibility);
      return CreatedAtAction(nameof(Create), new { id = responsibility.Id}, responsibility);
    }

    /// <summary>
    /// Updates the specific responsibility.
    /// </summary>
    /// <param name="id">The id of the responsibility.</param>
    /// <param name="responsibility">The updated responsibility value.</param>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /api/Responsibility/1
    ///     {
    ///        "id": 1,
    ///        "name": "Responsibility Name",
    ///        "imageLink": "",
    ///        "recommendedAgeGroups": [
    ///           0
    ///        ]
    ///     }
    ///
    /// </remarks>
    /// <response code="204">Success</response>
    /// <response code="400">If the id does not match the passed in responsibility</response>
    /// <response code="404">If the responsibility does not exist.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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

    /// <summary>
    /// Deletes the specific responsibility.
    /// </summary>
    /// <param name="id">The id of the responsibility.</param>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE /api/Responsibility/1
    ///
    /// </remarks>
    /// <response code="204">Success</response>
    /// <response code="404">If the responsibility does not exist.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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