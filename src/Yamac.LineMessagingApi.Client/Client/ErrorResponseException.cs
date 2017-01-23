using System;

namespace Yamac.LineMessagingApi.Client
{
    public class ErrorResponseException : Exception
    {
        private ErrorResponse ErrorResponse;

        public ErrorResponseException(ErrorResponse errorResponse) : base(errorResponse.Message)
        {
            ErrorResponse = errorResponse;
        }

        public ErrorResponseException(ErrorResponse errorResponse, Exception innerException) : base(errorResponse.Message, innerException)
        {
            ErrorResponse = errorResponse;
        }
    }
}
