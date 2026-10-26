using System.Text;

namespace Portfolio.Web.Helpers;

public static class SlugHelper
{
    // "My First API!" -> "my-first-api"
public static string ToSlug(string text)
    {
        var result = new StringBuilder();

        foreach (char c in text.Trim().ToLowerInvariant())
        {
            if (char.IsAsciiLetterOrDigit(c))
            {
                result.Append(c);
            }
            else if (result.Length > 0 && result[result.Length - 1] != '-')
            {
                result.Append('-');
            }
        }
        return result.ToString().TrimEnd('-');
    }
}