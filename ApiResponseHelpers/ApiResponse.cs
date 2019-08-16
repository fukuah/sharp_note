using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.ApiResponseHelpers
{
    public class ApiResponse { }

    public class ApiResponse<T> : ApiResponse
    {
        public T Body { get; }
        public ApiError Error { get; }

        public ApiResponse(T bdata)
        {
            Body = bdata;
        }

        public ApiResponse(T bdata, ApiError e)
        {
            Body = bdata;
            Error = e;
        }

        public ApiResponse(ApiError e)
        {
            Error = e;
        }
    }
}
