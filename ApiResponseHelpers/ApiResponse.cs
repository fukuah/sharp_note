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
        public string Error { get; }

        public ApiResponse(T bdata)
        {
            Body = bdata;
        }

        public ApiResponse(T bdata, string e)
        {
            Body = bdata;
            Error = e;
        }
    }
}
