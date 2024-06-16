using System.Diagnostics.CodeAnalysis;

namespace clinicteo.Models.User.dto;

public class UserRequestUpdateDTO
{
    [NotNull]
    public string FirstName { get; set; }
    [NotNull]
    public string LastName { get; set; }
    [NotNull]
    public string Email { get; set; }
}
