using Incidents.DataAccess.Entities;
using Incidents.DataAccess.Repositories.Interfaces;

namespace Incidents.DataAccess.Repositories.Realization;

public class RepositoryContact: RepositoryBase<Contacts>, IRepositoryContact
{
    public RepositoryContact(IncidentsDBContext _dbContext) 
        : base(_dbContext)
    {
    }
}