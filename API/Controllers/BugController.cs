using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class BugController : BaseApiController
  {
    private readonly DataContext __context;
    public BugController(DataContext _context)
    {
      __context = _context;
    }

    [Authorize]
    [HttpGet("auth")]
    public ActionResult<string> GetSecret() 
    {
        return "secret text";
    }

    [HttpGet("not-found")]
    public ActionResult<AppUser> GetNotFound() 
    {
        var x = __context.Users.Find(-1);

        if(x == null) return NotFound();

        return Ok(x);
        
    }

    [HttpGet("server-error")]
    public ActionResult<string> GetServerError() 
    {
        var x = __context.Users.Find(-1); //returns null in this case
        var xToReturn = x.ToString();

        return xToReturn;
    }

    [HttpGet("bad-request")]
    public ActionResult<string> GetBadRequest() 
    {
        return BadRequest("This was a bad request");
    }
  }
}