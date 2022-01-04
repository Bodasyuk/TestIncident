using Incidents.DataAccess.Repositories.Interfaces;

namespace Incidents.DataAccess.Repositories.Realization;

public class RepositoryWrapper : IRepositoryWrapper
{
    private IRepositoryAccount _account;
    private IRepositoryIncident _incident;
    private IRepositoryContact _contact;
    private IncidentsDBContext _dbContext;

    public IRepositoryAccount Account
    {
        get
        {
            if (_account == null)
            {
                _account = new RepositoryAccount(_dbContext);
            }

            return _account;
        }
    }
    
    public IRepositoryIncident Incident
    {
        get
        {
            if (_incident == null)
            {
                _incident = new RepositoryIncident(_dbContext);
            }

            return _incident;
        }
    }
    
    public IRepositoryContact Contact
    {
        get
        {
            if (_contact == null)
            {
                _contact = new RepositoryContact(_dbContext);
            }

            return _contact;
        }
    }

    public RepositoryWrapper(IncidentsDBContext dbContext)
    {
        _dbContext = dbContext;
    } 
    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}