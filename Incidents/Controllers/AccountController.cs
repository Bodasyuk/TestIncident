using Incidents.DataAccess.Entities;
using Incidents.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Incidents.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController:ControllerBase
{
    private IAccountService _service;
    private IContactService _serviceC;

    public AccountController(IAccountService service, IContactService serviceC)
    {
        _service = service;
        _serviceC = serviceC;
    }
    
    /// <summary>
    /// Create Account
    /// </summary>
    /// <param name="accounts">The fields of the account</param>
    /// <param name="mail">The mail of the contact</param>
    /// <response code="200">Successful operation</response>
    /// <response code="400">Bad Request</response>
    [HttpPost]
    public async Task<IActionResult> CreateAsync(Accounts? accounts, string mail)
    {
        if (accounts != null && await _serviceC.CheckMail(mail))
        {
            await _service.CreateAsync(accounts, mail);
            return Ok();
        }

        return BadRequest();
    }
    
    /// <summary>
    /// Get Accounts
    /// </summary>
    /// <returns>Acounts</returns>
    /// <response code="200">Successful operation</response>
    /// <response code="400">Bad Request</response>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            return Ok(await _service.GetAllAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Link Incident to Account
    /// </summary>
    /// <param name="name">The name of the account</param>
    /// <param name="incidentName">The name of the incident</param>
    /// <response code="200">Successful operation</response>
    /// <response code="400">Bad Request</response>
    [HttpPut]
    public async Task<IActionResult> LinkIncident(string name, string incidentName)
    {
        try
        {
            if (!await _serviceC.CheckIfNameIsExit(name))
                return NotFound();
            await _service.LinkIncident(name, incidentName);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
       
    }

    [HttpDelete]

    public async Task<IActionResult> Delete(string name)
    {
        try
        {
            await _service.Update(await _service.GetFirstOrDefaultAsync(name));
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}