using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clinicteo.Models;


[Table(name: "user-doctor")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column(name: "first-name")]
    public string FirstName { get; set; }
    [Column(name: "last-name")]
    public string LastName { get; set; }
    [Column(name: "email")]
    public string Email { get; set; }
    [Column(name: "crm")]
    public string CRM {  get; set; }
    [Column(name: "password")]
    public string Password { get; set; }
    [Column(name: "create-at")]
    public DateTime CreateAt { get; set; }
    [Column(name: "update-at")]
    public DateTime UpdateAt { get; set; }
    [Column( name: "roles" )]
    public List<string> Roles { get; set; }
    public User(string FirstName, string LastName, string Email, string CRM, string Password, List<string> Roles )
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Email = Email;
        this.CRM = CRM;
        this.Password = Password;
        this.Roles = Roles;
    }
}
