using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Rev.Errors;
using Talabat.Rev.RepositoryLayer.Data;

namespace Talabat.Rev.Controllers
{
    
    public class BuggyController : BaseApiController
    {
        private readonly StoreDbcontext _dbcontext;

        public BuggyController(StoreDbcontext dbcontext) 
        {
            _dbcontext = dbcontext;
        }



        [HttpGet("Notfound")] // Get : api/Byggy/Notfound
        public ActionResult GetNotFound() 
        {
            var product = _dbcontext.Products.Find(100);
            if (product == null)
                return NotFound(new ApiResponse(404));

            return Ok(product);
        }

        [HttpGet("Badrequest")] // Get : api/Byggy/badrequest
        public ActionResult GetBadRequest() 
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("Badrequest/{id}")] // Get : api/Byggy/badrequest/five
        public ActionResult GetBadRequest(int id)
        {
            return BadRequest(new ApiValidationErrorResponse());
        }


        [HttpGet("ServerError")]
        public ActionResult GetServerError() 
        {
            var product = _dbcontext.Products.Find(100);

            var productToreturn = product.ToString(); //Trow Exception in runtime (Server Error)
            return Ok(product);
        }

        [HttpGet("Unauthorized")] // Get : api/Byggy/Unauthorized
        public ActionResult GetUnauthorized(int id)
        {
            return Unauthorized(new ApiResponse(401));
        }
    }
}
