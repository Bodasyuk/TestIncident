using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Incidents.DataAccess.Entities;

public class Incidents
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid IncidentName { get; set; }
    public string Description { get; set; }
    public  ICollection<Accounts> Accounts { get; set; }
}