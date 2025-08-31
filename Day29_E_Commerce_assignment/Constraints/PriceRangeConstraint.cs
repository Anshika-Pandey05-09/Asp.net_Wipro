using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;

namespace Day29_E_Commerce_assignment.Constraints
{
    public class PriceRangeConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey,
                          RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.TryGetValue(routeKey, out var value) || value == null) return false;
            var s = Convert.ToString(value)!;
            var parts = s.Split('-', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) return false;
            return int.TryParse(parts[0], out var min) &&
                   int.TryParse(parts[1], out var max) &&
                   min <= max;
        }
    }
}
