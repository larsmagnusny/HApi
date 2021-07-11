using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HApi.Authorization
{
    public class VerifyToken : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            StringValues tokenStrs;
            Guid token;
            Guid? userGuid;
            bool hasToken;

            var request = context.HttpContext.Request;
            
            hasToken = request.Headers.TryGetValue("token", out tokenStrs);

            if (hasToken && tokenStrs.Count == 1)
            {
                token = Guid.Parse(tokenStrs[0]);

                if (!TokenStorage.CheckToken(token))
                    context.Result = new ForbidResult();

                userGuid = TokenStorage.FindUser(token);

                if (userGuid.HasValue)
                {
                    context.HttpContext.Items["UserId"] = userGuid;
                    base.OnActionExecuting(context);
                }
            }
            else
                context.Result = new ForbidResult();
        }
    }
}
