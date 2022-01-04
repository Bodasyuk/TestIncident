using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Incidents.DataAccess.Entities;

public class Contacts
{
    [Key]
    public  int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    
    [ForeignKey("Accounts")]
    public int? AccountsId { get; set; }
    public  Accounts? Accounts { get; set; }
}