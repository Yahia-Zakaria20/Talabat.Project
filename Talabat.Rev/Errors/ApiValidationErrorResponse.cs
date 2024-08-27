using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Talabat.Rev.Errors
{
    public class ApiValidationErrorResponse :ApiResponse
    {
       
        public IEnumerable<string> Errors { get; set; }

        public ApiValidationErrorResponse():base(400)
        {
            Errors = new List<string>();    
        }

    }
}
