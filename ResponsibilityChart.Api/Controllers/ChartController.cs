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
  [Produces("application/json")]
  [Route("api/[controller]")]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public class ChartController : ControllerBase
  {
    private readonly ILogger<ChartController> logger;
    private readonly IChartService service;
    
    public ChartController(ILogger<ChartController> logger, IChartService service)
    {
      this.logger = logger;
      this.service = service;
    }
    
    /// <summary>
    /// Returns the full list of charts.
    /// </summary>
    /// <returns>The list of charts available.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     Get /api/Chart
    ///
    /// </remarks>
    /// <response code="200">Returns all charts.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
#nullable enable
    public IActionResult Get(string? searchTerm, int? size, int? offset, string? sortBy)
#nullable disable
    {
      var charts = service.Get(
          searchTerm, 
          size.GetValueOrDefault(), 
          offset.GetValueOrDefault(),
          sortBy);

      return Ok(charts);
    }

    /// <summary>
    /// Returns the specific chart.
    /// </summary>
    /// <returns>The specific chart, if exists.</returns>
    /// <param name="id">The id of the chart.</param>
    /// <remarks>
    /// Sample request:
    ///
    ///     Get /api/Chart/1
    ///
    /// </remarks>
    /// <response code="200">Returns chart.</response>
    /// <response code="400">If the chart does not exist.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Get(int id)
    {
      var chart = service.Get(id);
      if (chart is null)
        return BadRequest();

      return Ok(chart);
    }

    /// <summary>
    /// Adds the specific chart.
    /// </summary>
    /// <returns>The new chart, if exists.</returns>
    /// <param name="chart">The new chart.</param>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/Chart
    ///     {
    ///       "id": 0,
    ///       "weekStart": "2021-11-16T19:02:18.219Z",
    ///       "goal": "string",
    ///       "performance": 0,
    ///       "assignedChild": {
    ///         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///         "name": "string",
    ///         "dateOfBrith": "2021-11-16T19:02:18.219Z",
    ///         "gender": 0
    ///       },
    ///       "assignedResponsibilities": [
    ///         {
    ///           "id": 0,
    ///           "name": "string",
    ///           "imageLink": "string",
    ///           "recommendedAgeGroups": [
    ///             0
    ///           ]
    ///         }
    ///       ],
    ///       "completedResponsibilities": [
    ///         {
    ///           "id": 0,
    ///           "assignedDay": 0,
    ///           "completed": true,
    ///           "responsibility": {
    ///             "id": 0,
    ///             "name": "string",
    ///             "imageLink": "string",
    ///             "recommendedAgeGroups": [
    ///               0
    ///             ]
    ///           }
    ///         }
    ///       ]
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns chart.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Create([FromBody]Chart chart)
    {
      service.Create(chart);

      return CreatedAtAction(nameof(Create), new {id = chart.Id}, chart);
    }

    /// <summary>
    /// Updates the specific chart.
    /// </summary>
    /// <param name="id">The id of the chart.</param>
    /// <param name="chart">The updated chart value.</param>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /api/Chart/1
    ///     {
    ///       "id": 0,
    ///       "weekStart": "2021-11-16T19:02:18.219Z",
    ///       "goal": "string",
    ///       "performance": 0,
    ///       "assignedChild": {
    ///         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///         "name": "string",
    ///         "dateOfBrith": "2021-11-16T19:02:18.219Z",
    ///         "gender": 0
    ///       },
    ///       "assignedResponsibilities": [
    ///         {
    ///           "id": 0,
    ///           "name": "string",
    ///           "imageLink": "string",
    ///           "recommendedAgeGroups": [
    ///             0
    ///           ]
    ///         }
    ///       ],
    ///       "completedResponsibilities": [
    ///         {
    ///           "id": 0,
    ///           "assignedDay": 0,
    ///           "completed": true,
    ///           "responsibility": {
    ///             "id": 0,
    ///             "name": "string",
    ///             "imageLink": "string",
    ///             "recommendedAgeGroups": [
    ///               0
    ///             ]
    ///           }
    ///         }
    ///       ]
    ///     }
    ///
    /// </remarks>
    /// <response code="204">Success</response>
    /// <response code="400">If the id does not match the passed in chart</response>
    /// <response code="404">If the chart does not exist.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(int id, [FromBody]Chart chart)
    {
      if (id != chart.Id)
        return BadRequest();

      var existingChart = service.Get(chart.Id);
      if (existingChart is null)
        return NotFound();

      service.Update(chart);

      return NoContent();
    }

    /// <summary>
    /// Deletes the specific chart.
    /// </summary>
    /// <param name="id">The id of the chart.</param>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE /api/Chart/1
    ///
    /// </remarks>
    /// <response code="204">Success</response>
    /// <response code="404">If the chart does not exist.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
      var chart = service.Get(id);
      if (chart is null)
        return NotFound();

      service.Delete(id);
      return NoContent();
    }
  }
}