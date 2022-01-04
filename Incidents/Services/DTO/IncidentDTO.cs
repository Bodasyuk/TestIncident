using Incidents.DataAccess.Entities;

namespace Incidents.Services.DTO;

public class IncidentDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public  ICollection<Accounts> Accounts { get; set; }
}