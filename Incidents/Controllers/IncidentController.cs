using Incidents.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Incidents.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IncidentController : ControllerBase
{
    private readonly IIncidentService _incidentService;

    public IncidentController(IIncidentService incidentService)
    {
        _incidentService = incidentService;
    }
    
    /// <summary>
    /// Create Incident
    /// </summary>
    /// <param name="incidents">The fields of the incident</param>
    /// <param name="name">The name of the account</param>
    /// <response code="200">Successful operation</response>
    /// <response code="400">Bad Request</response>
    [HttpPost]
    public async Task<IActionResult> CreateAsync(DataAccess.Entities.Incidents incidents, string name)
    {
        if (incidents != null)
        {
            await _incidentService.CreateAsync(incidents, name);
            return Ok();
        }

        return BadRequest();
    }

    /// <summary>
    /// Get Incidents
    /// </summary>
    /// <returns>Incidents</returns>
    /// <response code="200">Successful operation</response>
    /// <response code="400">Bad Request</response>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            return Ok(await _incidentService.GetAllAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Delete Incident
    /// </summary>
    /// <param name="name">The name of the account</param>
    /// <response code="200">Successful operation</response>
    /// <response code="400">Bad Request</response>
    [HttpDelete]
    public async Task<IActionResult> Delete(string name)
    {
        try
        {
            await _incidentService.Delete(name);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Update Incident
    /// </summary>
    /// <param name="description">The description of the incident</param>
    /// <param name="name">The name of the account</param>
    /// <response code="200">Successful operation</response>
    /// <response code="400">Bad Request</response>
    [HttpPut]
    public async Task<IActionResult> Update(string name, string description)
    {
        try
        {
            await _incidentService.Update(name, description);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}