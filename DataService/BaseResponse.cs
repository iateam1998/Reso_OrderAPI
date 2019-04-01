using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService
{
    public class BaseResponse<T> where T : class
    {
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }
        [JsonProperty("result-code")]
        public int ResultCode { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }

        public static BaseResponse<string> GetInternalServerError(Exception ex, string messagePrefix)
        {
            return new BaseResponse<string>()
            {
                ResultCode = 1,
                Success = false,
                Message = messagePrefix,
                Data = ex.ToString()
            };
        }

    }
}
