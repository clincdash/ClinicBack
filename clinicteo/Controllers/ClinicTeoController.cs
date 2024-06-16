using clinicteo.Models.User.dto;
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
        return Ok( clinicService.Save( user ) );
    }
    [HttpGet]
    [Route("/all")]
    public ActionResult GetAllUser()
    {
        return Ok( clinicService.GetAll() );
    }
    [HttpDelete]
    public ActionResult DeleteUser( int id )
    {
        clinicService.Delete( id );
        return NoContent();
    }

    [HttpPut( "{id}" )]
    public ActionResult PutUser(int id, UserRequestUpdateDTO user )
    {
        return Ok( clinicService.Put(id , user) );
    }

    [HttpPut( "reset-password/{id}" )]
    public ActionResult PutUserPassword( int id, UserRequestUpdatePasswordDTO passwordDTO )
    {
        clinicService.PutPassword( id, passwordDTO );
        return NoContent();
    }
}
