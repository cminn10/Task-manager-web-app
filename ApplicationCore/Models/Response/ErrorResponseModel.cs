using System;
using System.Text.Json;

namespace ApplicationCore.Models.Response
{
    public class ErrorResponseModel
    {
        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }
        public string InnerExceptionMessage { get; set; }
        public DateTime ExceptionDateTime { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}