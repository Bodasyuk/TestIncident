using Incidents.DataAccess.Entities;

namespace Incidents.Services.Interfaces;

public interface IContactService
{
    Task CreateAsync(Contacts contacts);
    public void Create(Contacts entity);
    public Task Update(Contacts entity);
    public Task Delete(string mail);
    public Task<bool> CheckMail(string mail);
    public Task LinkContact(string mail, string nameAccount);
    public Task<bool> CheckIfNameIsExit(string nameAccount);
    public Task<IEnumerable<Contacts>> GetAllAsync();
    public Task<Contacts> GetFirstAsync(string mail);
}