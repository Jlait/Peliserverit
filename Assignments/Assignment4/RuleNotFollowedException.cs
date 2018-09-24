using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment4
{
    public class RuleNotFollowedException : Exception
    {
        public RuleNotFollowedException()
        {

        }
    }

    public class NotImplExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is RuleNotFollowedException)
            {
                context.Result = new BadRequestObjectResult("Player under lvl 3");
            }
        }
    }

}