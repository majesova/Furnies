using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Furnies.WebUI.Services
{
    public class JsonSettings
    {
        
        public static JsonSerializerSettings JsonSerializerSettings {
            get {
                var settings = new JsonSerializerSettings{ContractResolver = new CamelCasePropertyNamesContractResolver()};
               
                return settings;
            }
        }

        public static ContentResult BuildJsonResult(object obj) {

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(obj, JsonSerializerSettings),
                ContentEncoding = Encoding.UTF8
            };
        }

    }
}