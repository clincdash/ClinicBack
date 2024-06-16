using System.Diagnostics.CodeAnalysis;

namespace clinicteo.Models.User.dto;

public class UserResponseDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; } 
    public string CRM { get; set; }
}
