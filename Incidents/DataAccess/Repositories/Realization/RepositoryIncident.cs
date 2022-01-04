using Incidents.DataAccess.Repositories.Interfaces;

namespace Incidents.DataAccess.Repositories.Realization;

public class RepositoryIncident : RepositoryBase<Entities.Incidents>, IRepositoryIncident
{
    public RepositoryIncident(IncidentsDBContext dbContext)
        : base(dbContext)
    {
    }
}