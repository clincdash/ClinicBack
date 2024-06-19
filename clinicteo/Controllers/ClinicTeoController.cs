using clinicteo.Models.User.Dto;
using clinicteo.Services;
using Microsoft.AspNetCore.Mvc;

namespace clinicteo.Controllers;

[ApiController]
[Route("[controller]")]
public class ClinicTeoController : ControllerBase
{
    private readonly ClinicService clinicService;

    public ClinicTeoController(ClinicService clinicService)
    {
        this.clinicService = clinicService ?? throw new ArgumentNullException( nameof( clinicService ) );
    }

    [HttpPost]
    public ActionResult PostUser( UserRequestDTO user )
    {
        return Ok( clinicService.SaveUser( user ) );
    }

    [HttpGet]
    [Route("/all")]
    public ActionResult GetAllUser()
    {
        return Ok( clinicService.GetAllUsers() );
    }

    [HttpDelete]
    public ActionResult DeleteUser( int id )
    {
        clinicService.DeleteUser( id );
        return NoContent();
    }

    [HttpPut( "{id}" )]
    public ActionResult PutUser(int id, UserRequestUpdateDTO user )
    {
        return Ok( clinicService.PutUser(id , user) );
    }

    [HttpPut( "reset-password/{id}" )]
    public ActionResult PutUserPassword( int id, UserRequestUpdatePasswordDTO passwordDTO )
    {
        clinicService.PutPassword( id, passwordDTO );
        return NoContent();
    }
}
