using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SharpNote.ApiResponseHelpers
{
    public enum ApiErrorCode{
        UNKNOWN_ERROR = 0,
        DATA_WAS_MODIFIED_OR_DELETED = 1,
    }

    public class ApiError
    {
        public ApiErrorCode Code { get; set; }
        public string Message { get; set; }

        public ApiError(Exception e)
        {
            switch (e.GetType().ToString())
            {
                case "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException":
                    Message = e.Message;
                    Code = ApiErrorCode.DATA_WAS_MODIFIED_OR_DELETED;
                    break;
                default:
                    Message = e.Message;
                    Code = ApiErrorCode.UNKNOWN_ERROR;
                    break;
            }
        }
    }
}
