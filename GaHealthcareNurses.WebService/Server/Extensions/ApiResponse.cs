using Newtonsoft.Json;

namespace GaHealthcareNurses.WebService.Extensions
{
    public class ApiResponse
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 302:
                    return "Already exists!";
                case 400:
                    return "Bad request!";
                case 404:
                    return "Resource not found!";
                case 500:
                    return "An unhandled error has occurred.";
                default:
                    return null;
            }
        }

    }
    public class ApiOkResponse : ApiResponse
    {
        public object Result { get; }

        public ApiOkResponse(string message) : base(ResponseStatusCode.OK, message)
        {
        }

        public ApiOkResponse(object result) : base(ResponseStatusCode.OK)
        {
            Result = result;
        }
        public ApiOkResponse(object result, string message) : base(ResponseStatusCode.OK, message)
        {
            Result = result;
        }
    }
   
    public class ApiErrorResponse : ApiResponse
    {
        public string DeveloperError { get; }

        public ApiErrorResponse(string error) : base(ResponseStatusCode.InternalServerError)
        {
            DeveloperError = error;
        }
        public ApiErrorResponse(string error, string message) : base(ResponseStatusCode.InternalServerError, message)
        {
            DeveloperError = error;
        }
    }

    public class ResponseStatusCode
    {
        public const int BadRequest = 400;
        public const int OK = 200;
        public const int Unauthorized = 401;
        public const int NotFound = 404;
        public const int InternalServerError = 500;
        public const int AlreadyExists = 302;
        public const int DataNotFound = 204;

    }
}
