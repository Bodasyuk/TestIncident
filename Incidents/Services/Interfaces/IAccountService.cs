using Incidents.DataAccess.Entities;

namespace Incidents.Services.Interfaces;

public interface IAccountService
{
    Task CreateAsync(Accounts accounts, string mail);
    public void Create(Accounts entity);
    public Task Update(Accounts entity);
    public Task Delete(string name);
    public Task<IEnumerable<Accounts>> GetAllAsync();
    public Task LinkIncident(string name, string incidentName);
    public Task<Accounts> GetFirstOrDefaultAsync(string name);
}