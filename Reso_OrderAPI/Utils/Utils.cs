using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Reso_OrderAPI.Controllers
{
    public interface IUtils
    {
        bool CheckToken(string token);
    }
    public class Utils : IUtils
    {
        private IConfiguration _iConfig;
        public Utils(IConfiguration iconfig)
        {
            _iConfig = iconfig;
        }

        private static string _enableToken = "";
        public bool CheckToken(string token)
        {
            string _accessToken = _iConfig.GetSection("AppSetting").GetSection("config.order.token").Value;
            if (token != _accessToken)
            {
                //throw new Exception("Invalid token!!1");
                return false;
            }
            return true;
        }
    }

    public class JsonContent : HttpContent
    {
        private readonly MemoryStream _Stream = new MemoryStream();
        public JsonContent(object value)
        {

            Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var jw = new JsonTextWriter(new StreamWriter(_Stream));
            jw.Formatting = Formatting.Indented;
            var serializer = new JsonSerializer();
            serializer.Serialize(jw, value);
            jw.Flush();
            _Stream.Position = 0;

        }
        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            return _Stream.CopyToAsync(stream);
        }

        protected override bool TryComputeLength(out long length)
        {
            length = _Stream.Length;
            return true;
        }
    }
}
