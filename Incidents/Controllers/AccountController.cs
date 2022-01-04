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

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _service.GetAllAsync());
    }
}