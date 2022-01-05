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
}