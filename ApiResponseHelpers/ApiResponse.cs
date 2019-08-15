using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.ApiResponseHelpers
{
    public class ApiResponse { }

    public class ApiResponse<T> : ApiResponse
    {
        public T body { get; }
        public ApiError error { get; }

        public ApiResponse(T bdata)
        {
            body = bdata;
        }
    }
}
