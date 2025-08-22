using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day28_Assignment1.Helpers
{
    public static class CustomHtmlHelpers
    {
        // Extension method for IHtmlHelper
        public static IHtmlContent StyledTextBox(this IHtmlHelper htmlHelper, string name, string placeholder, string cssClass)
        {
            TagBuilder input = new TagBuilder("input");
            input.Attributes["type"] = "text";
            input.Attributes["name"] = name;
            input.Attributes["placeholder"] = placeholder;
            input.AddCssClass(cssClass);

            return input;
        }
    }
}