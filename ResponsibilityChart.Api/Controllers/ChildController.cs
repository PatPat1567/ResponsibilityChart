using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ResponsibilityChart.Api.Models;
using ResponsibilityChart.Api.Interfaces;

namespace ResponsibilityChart.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Produces("application/json")]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public class ChildController : ControllerBase
  {
    private readonly ILogger<ChildController> logger;
    private readonly IChildService service;
    
    public ChildController(ILogger<ChildController> logger, IChildService service)
    {
      this.logger = logger;
      this.service = service;
    }
    
    /// <summary>
    /// Returns the full list of children.
    /// </summary>
    /// <returns>The list of children available.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     Get /api/Child
    ///
    /// </remarks>
    /// <response code="200">Returns all children.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Get()
    {
      var children = service.Get();
      return Ok(children);
    }

    /// <summary>
    /// Returns the specific child.
    /// </summary>
    /// <returns>The specific child, if exists.</returns>
    /// <param name="id">The id of the child.</param>
    /// <remarks>
    /// Sample request:
    ///
    ///     Get /api/Child/1
    ///
    /// </remarks>
    /// <response code="200">Returns child.</response>
    /// <response code="400">If the child does not exist.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Get(Guid id)
    {
      var child = service.Get(id);
      if (child is null)
        return BadRequest();
      return Ok(child);
    }

    /// <summary>
    /// Adds the specific child.
    /// </summary>
    /// <returns>The new child, if exists.</returns>
    /// <param name="child">The new child.</param>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/Child
    ///     {
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns child.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Post([FromBody]Child child)
    {
      service.Add(child);
      return CreatedAtAction(nameof(Post), new { id = child.Id}, child);
    }

    /// <summary>
    /// Updates the specific child.
    /// </summary>
    /// <param name="id">The id of the child.</param>
    /// <param name="child">The updated child value.</param>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /api/Child/1
    ///     {
    ///     }
    ///
    /// </remarks>
    /// <response code="204">Success</response>
    /// <response code="400">If the id does not match the passed in child</response>
    /// <response code="404">If the child does not exist.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Put(Guid id, [FromBody]Child child)
    {
      if (id != child.Id)
        return BadRequest();
      
      var existingChild = service.Get(id);
      if (existingChild is null)
        return NotFound();

      service.Update(child);
      return NoContent();
    }

    /// <summary>
    /// Deletes the specific child.
    /// </summary>
    /// <param name="id">The id of the child.</param>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE /api/Child/1
    ///
    /// </remarks>
    /// <response code="204">Success</response>
    /// <response code="404">If the child does not exist.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
      var child = service.Get(id);

      if (child is null)
        return NotFound();

      service.Delete(id);
      return NoContent();
    }
  }
}