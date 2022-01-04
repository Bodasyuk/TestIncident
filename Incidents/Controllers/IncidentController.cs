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

    [HttpPost]
    public async Task<IActionResult> CreateAsync(DataAccess.Entities.Incidents incidents)
    {
        if (incidents != null)
        {
            await _incidentService.CreateAsync(incidents);
            return Ok();
        }

        return BadRequest();
    }
}