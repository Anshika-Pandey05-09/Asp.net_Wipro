using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;


namespace Day29_E_Commerce_assignment.Constraints
{
    public class ValidCategoryConstraint : IRouteConstraint
    {
        private static readonly HashSet<string> Allowed = new(StringComparer.OrdinalIgnoreCase)
        {
            "electronics","books","clothing"
        };

        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey,
                          RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.TryGetValue(routeKey, out var value) || value == null) return false;
            var category = Convert.ToString(value)!;
            return Allowed.Contains(category);
        }
    }
}
