namespace Talabat.Rev.Errors
{
    public class ApiExceptionResponse:ApiResponse
    {

        public string? Details { get; set; }


        public ApiExceptionResponse(int code ,  string? details = null, string? massage = null) :base(code , massage)
        {
            Details = details;
        }


    }
}
