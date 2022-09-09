using Xunit;
namespace Assignment1.Tests;

public class RegExprTests
{
    [Fact] 
    public void splitline_test() 
    {
        //Arrange 
        IEnumerable<string> input = new[] { "Hello World BSDA", "Øl bong" };
        //Act
        var output = RegExpr.SplitLine(input);

        //Assert 
        var expected = new[] { "Hello", "World", "BSDA", "Øl", "bong"};
        Assert.Equal(expected, output);
    }

    [Fact] 
    public void resolution_test() 
    {
        //Arrange 
        IEnumerable<string> input = new[] {"1920x1080", "1024x768, 780x230"};

        //Act
        var output = RegExpr.Resolution(input);

        //Assert 
        var expected = new[] { (1920, 1080), (1024, 768), (780, 230)};
        Assert.Equal(expected, output);
    }
    
    [Fact] 
    public void innterText_test() 
    {
        //Arrange
        var html = "<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p> </div>";
        var tag = "a";

        //Act
        var output = RegExpr.InnerText(html, tag);

        //Assert 
        var expected = new[] { "theoretical computer science", "formal language", "characters", "pattern", "string searching algorithms", "strings"};
        Assert.Equal(expected, output);
    }

    [Fact]
    public void innterText_test2() 
    {
        //Arrange
        var html = "<div><p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p></div>";
        var tag = "p";

        //Act
        var output = RegExpr.InnerText(html,tag);

        //Assert 
        var expected = new [] {"The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to."};
        Assert.Equal(expected,output);
    
    }
}