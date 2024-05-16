using Applications.Commons;
using Microsoft.AspNetCore.Mvc;

namespace Applications.Utils
{
    public static class HttpUtils
    {
        public static ActionResult<Response> MakeResponse(this Response result)
        {
            return new ObjectResult(result)
            {
                StatusCode = (int?)result.StatusCode
            };
        }
    }
}
