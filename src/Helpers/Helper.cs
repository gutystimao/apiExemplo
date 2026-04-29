using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiExemplo.src.Models;
using apiExemplo.src.Response.Shared;

namespace apiExemplo.src.Helpers
{
    public class Helper
    {
        public static Dictionary<string, string> NormalizeQueryParams(IQueryCollection data)
        {
            Dictionary<string, string> dict = data.ToDictionary(
                item => item.Key,
                item => item.Value.ToString());
            return dict;
        }

        internal static object NormalizeLogResponse(Response<User?> response)
        {
            throw new NotImplementedException();
        }

        internal static dynamic? NormalizeResponse(User usuario)
        {
            throw new NotImplementedException();
        }
    }
}