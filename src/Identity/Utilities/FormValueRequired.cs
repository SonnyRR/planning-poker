namespace PlanningPoker.Identity.Utilities
{
    using Microsoft.AspNetCore.Mvc.Abstractions;
    using Microsoft.AspNetCore.Mvc.ActionConstraints;
    using Microsoft.AspNetCore.Routing;

    using System;

    [AttributeUsage(AttributeTargets.Method)]
    public sealed class FormValueRequiredAttribute : ActionMethodSelectorAttribute
    {
        private readonly string name;

        public FormValueRequiredAttribute(string name)
        {
            this.name = name;
        }

        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            if (string.Equals(routeContext.HttpContext.Request.Method, "GET", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(routeContext.HttpContext.Request.Method, "HEAD", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(routeContext.HttpContext.Request.Method, "DELETE", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(routeContext.HttpContext.Request.Method, "TRACE", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (string.IsNullOrEmpty(routeContext.HttpContext.Request.ContentType))
            {
                return false;
            }

            if (!routeContext.HttpContext.Request.ContentType.StartsWith("application/x-www-form-urlencoded", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return !string.IsNullOrEmpty(routeContext.HttpContext.Request.Form[this.name]);
        }
    }
}
