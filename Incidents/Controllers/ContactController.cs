using Incidents.DataAccess.Entities;
using Incidents.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Incidents.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(Contacts? contacts)
    {
        try
        {
            if (contacts == null) 
                return BadRequest();
            else if (await _contactService.CheckMail(contacts.Email))
                await _contactService.Update(contacts);
            else
                await _contactService.CreateAsync(contacts);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> LinkContact(string mail, string name)
    {
        try
        {
            if (!await _contactService.CheckIfNameIsExit(name))
                return NotFound();
            await _contactService.LinkContact(mail, name);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            return Ok(await _contactService.GetAllAsync());
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string mail)
    {
        try
        {
            await _contactService.Delete(mail);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}