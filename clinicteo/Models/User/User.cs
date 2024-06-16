
using clinicteo.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clinicteo.Models.User;


[Table(name: "user-doctor")]
public class User : BaseEntity
{
    [Column(name: "first-name")]
    public string FirstName { get; set; }
    [Column(name: "last-name")]
    public string LastName { get; set; }
    [Column(name: "email")]
    public string Email { get; set; }
    [Column(name: "password")]
    public string Password { get; set; }
    [Column( name: "crm" )]
    public string CRM { get; set; }
    [Column(name: "roles")]
    public List<string> Roles { get; set; }
}
