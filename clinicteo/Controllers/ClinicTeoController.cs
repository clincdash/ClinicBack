using clinicteo.Models.User.Dto;
using clinicteo.Services;
using Microsoft.AspNetCore.Mvc;

namespace clinicteo.Controllers;

[ApiController]
[Route("[controller]")]
public class ClinicTeoController : ControllerBase
{
    private readonly ClinicService clinicService;

    public ClinicTeoController( ClinicService clinicService )
    {
        this.clinicService = clinicService ?? throw new ArgumentNullException( nameof( clinicService ) );
    }

    [HttpPost]
    public async Task<ActionResult> PostUser( UserRequestDTO user )
    {
        return  Ok( await clinicService.SaveUser( user ) );
    }

    [HttpGet("/all")]
    public async Task<ActionResult> GetAllUser()
    {
        return Ok( await clinicService.GetAllUsers() );
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteUser( int id )
    {
        await clinicService.DeleteUser( id );
        return NoContent();
    }

    [HttpPut( "{id}" )]
    public async Task<ActionResult> PutUser( int id, UserRequestUpdateDTO user )
    {
        return Ok( await clinicService.PutUser( id, user ) );
    }

    [HttpPut( "reset-password/{id}" )]
    public async Task<ActionResult> PutUserPassword( int id, UserRequestUpdatePasswordDTO passwordDTO )
    {
        await clinicService.PutPassword( id, passwordDTO );
        return NoContent();
    }
}
