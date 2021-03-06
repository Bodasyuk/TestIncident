namespace Incidents.Services.Interfaces;

public interface IIncidentService
{
    Task CreateAsync(DataAccess.Entities.Incidents incident, string name);
    public void Create(DataAccess.Entities.Incidents entity);
    public Task Update(string name, string description);
    public Task Delete(string name);
    public Task<IEnumerable<DataAccess.Entities.Incidents>> GetAllAsync();
}