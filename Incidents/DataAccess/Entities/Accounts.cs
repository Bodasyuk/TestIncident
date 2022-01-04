using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Incidents.DataAccess.Entities;

public class Accounts
{
    [Key]
    public int AccountId { get; set; }
    public string Name { get; set; }
    
    [ForeignKey("Incidents")]
    public Guid? IncidentName { get; set; }
    public Incidents? Incidents { get; set; }
    public ICollection<Contacts>? Contacts { get; set; }
}