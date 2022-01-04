using System.Threading.Tasks;

namespace Incidents.DataAccess.Repositories.Interfaces;

public interface IRepositoryWrapper
{
    IRepositoryAccount Account { get; }
    IRepositoryIncident Incident { get; }
    IRepositoryContact Contact { get; }
    void Save();
    Task SaveAsync();
}