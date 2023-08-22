namespace MessengerApp.Core.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Web.Mvc;

    using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;

    [Authorize]
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
