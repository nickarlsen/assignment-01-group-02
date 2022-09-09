using System.Text.RegularExpressions;
namespace Assignment1;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines) 
    {
        var pattern = @"\w+";



        foreach (string s in lines)
        {
             foreach (Match m in Regex.Matches(s, pattern))
            {
                yield return m.Value;
            } 
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions) 
    {
        var pattern = @"((?<width>\d{1,4})x(?<height>\d{1,4}))+";

        foreach (string s in resolutions)
        {
            var matches = Regex.Matches(s, pattern);
            foreach (Match m in matches)
            {
                yield return (int.Parse(m.Groups["width"].Value), int.Parse(m.Groups["height"].Value));
            }
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag)
    {
        throw new NotImplementedException();
    }

    public static IEnumerable<(Uri url, string title)> Urls(string html) => throw new NotImplementedException();
}