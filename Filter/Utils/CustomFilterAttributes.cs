using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filter.Utils
{
    public class CustomFilterAttributes : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result;
            if (result is PageResult)
            {
                var page = ((PageResult)result);
                string ip = context.HttpContext.Request.Host.ToString();
                page.ViewData["filterMessage"] = "IP: " + ip;
            }

            await next.Invoke();
        }
    }
}
