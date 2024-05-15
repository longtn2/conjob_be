using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Entities.Utils.JSON
{
    public static class JsonUtils
    {
        public static string GetData(string data, string field)
        {
            var parsedObject = JObject.Parse(data);
            if(parsedObject == null)
            {
                return null;
            }
            if ((bool)parsedObject["success"] == false) return parsedObject["error"].ToString();

            var res = parsedObject[$"{field}"].ToString();
            return res;
        }
    }
}
