
namespace Talabat.Rev.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }

        public string? Message { get; set; }

        public ApiResponse(int code , string? massage = null )
        {
            StatusCode = code ;
            Message = massage ?? GetDefultMassageForStatusCode(StatusCode) ;
        }

        private string? GetDefultMassageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, You Have Made",
                401 => "Authorized, you are not",
                404 => "Resource Was Not Found",
                500 => "Internal Server Error",
                _ => null
            };
        }
    }
}
