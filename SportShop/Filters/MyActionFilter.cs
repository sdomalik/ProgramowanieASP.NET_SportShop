using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SportShop.Filters
{
    public class MyActionFilter : IActionFilter
    {
        private Stopwatch stopwatch = new Stopwatch();
        public void OnActionExecuted(ActionExecutedContext context)
        {
            stopwatch.Stop();
            var executionTime = stopwatch.ElapsedMilliseconds;
            if (executionTime > 500)
            {
                Debug.WriteLine("Action took to much time");
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            stopwatch.Reset();
            stopwatch.Start();
        }
    }
}
