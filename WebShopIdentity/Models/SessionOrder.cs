using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIdentity.Models
{
    public static class SessionOrder
    {
        
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJason<T>(this ISession session,string key)
        {
            var value = session.GetString(key);
            return value==null?default(T): JsonConvert.DeserializeObject<T>(value);

        }
    }
}
