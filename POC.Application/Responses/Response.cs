using POC.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC.Application.Responses
{
    public class Response<T> : BaseResponse
    {
        public Response() : base() { }

        public int TotalRecordCount { get; set; } = 1;
        public T Data { get; set; }
    }
}
