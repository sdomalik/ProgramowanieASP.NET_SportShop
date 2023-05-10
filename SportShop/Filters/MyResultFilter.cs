using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportShop.Filters
{
    public class MyResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
        }
        // tutaj moge dodac comment
        // kolejny test
    }
}
