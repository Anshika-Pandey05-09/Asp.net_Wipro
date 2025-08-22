using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace Day28_Assignment1.TagHelpers
{
    [HtmlTargetElement("star-rating")]
    public class StarRatingTagHelper : TagHelper
    {
        // Attribute passed from Razor
        public int Value { get; set; } = 0;
        public int Max { get; set; } = 5; // default 5 stars

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div"; // replaces <star-rating> with <div>
            output.Attributes.SetAttribute("class", "star-rating");

            var sb = new StringBuilder();

            for (int i = 1; i <= Max; i++)
            {
                if (i <= Value)
                {
                    sb.Append("⭐ "); // filled star
                }
                else
                {
                    sb.Append("☆ "); // empty star
                }
            }

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}