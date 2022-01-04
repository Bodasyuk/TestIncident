using Incidents.DataAccess.Entities;
using Incidents.DataAccess.Repositories.Interfaces;

namespace Incidents.DataAccess.Repositories.Realization;

public class RepositoryAccount : RepositoryBase<Accounts>, IRepositoryAccount
{
    public RepositoryAccount(IncidentsDBContext _dbContext) 
        : base(_dbContext)
    {
    }
}