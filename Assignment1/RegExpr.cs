using System.Text.RegularExpressions;
namespace Assignment1;

public static class RegExpr
{
    public static void main(String[] args)
    {
        var tag = "a";
        var pattern = @$"<({tag}).*?>(?><(\w+).*?>|<\/\2>|(?<text>[^<]*))*?<\/\1>";
        Console.WriteLine(pattern);
    }
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
        var pattern = @$"<({tag}).*?>(?><(\w+).*?>|<\/\2>|(?<text>[^<]*))*?<\/\1>";
        
        var matches = Regex.Matches(html, pattern);
        foreach (Match m in matches) 
        {
            string innerText = "";
            foreach (Capture t in m.Groups["text"].Captures)
            {
                innerText += t.Value;
            }
            yield return innerText;
        }
    }


    public static IEnumerable<(Uri url, string title)> Urls(string html) 
    {
        
        var urlPattern = @"<(a)(?<attributes>.*?href=""(?<url>.*?)"".*?)>.*?<\/\1>";
        var titlePattern = @"title=""(?<title>.*)""";

        
        var matches = Regex.Matches(html, urlPattern);
        foreach(Match m in matches)
        {
            Uri returnUrl = new Uri(m.Groups["url"].Value);

            var titleMatch = Regex.Match(m.Groups["attributes"].Value, titlePattern);
            if(titleMatch.Success)
            {
                yield return (returnUrl, titleMatch.Groups["title"].Value);
            }
            else
            {
                string innerText = InnerText(m.Value, "a").First();
                innerText = innerText == null ? "" : innerText;
                yield return (returnUrl, innerText);
            }
        }
    }
}