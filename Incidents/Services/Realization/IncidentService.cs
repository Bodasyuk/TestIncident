using Incidents.DataAccess.Repositories.Interfaces;
using Incidents.Services.Interfaces;
using AutoMapper;
using Incidents.DataAccess.Entities;

namespace Incidents.Services.Realization;

public class IncidentService : IIncidentService
{
    private readonly IRepositoryWrapper _wrapper;

    public IncidentService(IRepositoryWrapper wrapper)
    {
        _wrapper = wrapper;
    }
    public async Task CreateAsync(DataAccess.Entities.Incidents incident, string name)
    {
        var account = await _wrapper.Account.GetFirstOrDefaultAsync(x => x.Name == name);
        if (account.IncidentName != null)
            throw new Exception();
        account.IncidentName = incident.IncidentName;
        incident.Accounts = new List<Accounts>() { account };
        await _wrapper.Incident.CreateAsync(incident);
        _wrapper.Account.Update(account);
        await _wrapper.SaveAsync();
    }

    public void Create(DataAccess.Entities.Incidents entity)
    {
        _wrapper.Incident.Create(entity);
        _wrapper.Save();
    }

    public async Task Update(string name, string description)
    {
        var incident = await _wrapper.Incident.GetFirstOrDefaultAsync(x => x.IncidentName.ToString() == name);
        if (incident == null)
            throw new Exception();
        incident.Description = description;
        _wrapper.Incident.Update(incident);
    }

    public async Task Delete(string name)
    {
        var incident = await _wrapper.Incident.GetFirstOrDefaultAsync(x => x.IncidentName.ToString() == name);
        if (incident == null)
            throw new Exception();
        _wrapper.Incident.Delete(incident);
    }

    public async Task<IEnumerable<DataAccess.Entities.Incidents>> GetAllAsync()
    {
        return await _wrapper.Incident.GetAllAsync();
    }

}