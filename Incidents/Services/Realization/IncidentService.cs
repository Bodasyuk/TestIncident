using Incidents.DataAccess.Repositories.Interfaces;
using Incidents.Services.DTO;
using Incidents.Services.Interfaces;
using AutoMapper;

namespace Incidents.Services.Realization;

public class IncidentService : IIncidentService
{
    private readonly IRepositoryWrapper _wrapper;

    public IncidentService(IRepositoryWrapper wrapper)
    {
        _wrapper = wrapper;
    }
    public async Task CreateAsync(DataAccess.Entities.Incidents incident)
    {
        await _wrapper.Incident.CreateAsync(incident);
    }
}