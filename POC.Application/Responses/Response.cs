using POC.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC.Application.Responses
{
    public class Response<T> : BaseResponse
    {
        public Response() : base() { }

        private int _totalRecordCount = 1;
        public int TotalRecordCount
        {
            get
            {
                if (Data == null)
                {
                    _totalRecordCount = 0;
                }

                return _totalRecordCount;
            }

            set
            {
                _totalRecordCount = value;
            }
        }
        public T Data { get; set; }
    }
}
