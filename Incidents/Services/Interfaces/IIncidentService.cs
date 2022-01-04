using Incidents.Services.DTO;

namespace Incidents.Services.Interfaces;

public interface IIncidentService
{
    Task CreateAsync(DataAccess.Entities.Incidents incident);
}