using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace clinicteo.Models.User.dto;

public class UserRequestDTO
{
    [NotNull]
    public string FirstName { get; set; }
    [NotNull]
    public string LastName { get; set; }
    [NotNull]
    public string Email { get; set; }
    [NotNull]
    public string CRM { get; set; }
    [NotNull]
    public string Password { get; set; }
    [NotNull]
    public List<string> Roles { get; set; }
}
