using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Rev.Errors;

namespace Talabat.Rev.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {

        public ActionResult geterror(int code) 
        {
            return NotFound(new ApiResponse(code));
        }
    }
}
