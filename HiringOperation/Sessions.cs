
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
namespace HiringOperation
{
    public class Sessions
    {
        public class SetSessionGlobally : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filtercontext)
            {
                var value = filtercontext.HttpContext.Session.GetString("UserName");
                if (value == null)
                {
                    filtercontext.Result =
                        new RedirectToRouteResult(
                            new RouteValueDictionary {
                            {
                           "controller","ATSProject" },
                            { "action","Login" }
                            });
                }
            }
        }
    }
}
