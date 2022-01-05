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

    /// <summary>
    /// Create Contact
    /// </summary>
    /// <param name="contacts">The fields of the contact</param>
    /// <response code="200">Successful operation</response>
    /// <response code="400">Bad Request</response>
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
    
    /// <summary>
    /// Create Account to Contact
    /// </summary>
    /// <param name="name">The field of the account</param>
    /// <param name="mail">The mail of the contact</param>
    /// <response code="200">Successful operation</response>
    /// <response code="400">Bad Request</response>
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
    
    /// <summary>
    /// Get Contacts
    /// </summary>
    /// <returns>Contacts</returns>
    /// <response code="200">Successful operation</response>
    /// <response code="400">Bad Request</response>
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

    /// <summary>
    /// Delete Contact
    /// </summary>
    /// <param name="mail">The mail of the contact</param>
    /// <response code="200">Successful operation</response>
    /// <response code="400">Bad Request</response>
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