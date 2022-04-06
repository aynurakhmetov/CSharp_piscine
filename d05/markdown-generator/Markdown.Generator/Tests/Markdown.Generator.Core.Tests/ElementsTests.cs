using System;
using Xunit;
using Markdown.Generator.Core.Markdown.Elements;

namespace Markdown.Generator.Core.Tests
{
    public class ElementsTests
    {
        [Fact]
        public void Given_Code_When_LanguageAndCodeAsParameter_Then_ReturnMarkdownCodeMarkup()
        {
            string expected = "```csharp\nsome code\n```\n";
            var code = new Code("csharp", "some code");

            string actual = code.Create();
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Given_CodeQuote_When_CodeAsParameter_Then_ReturnMarkdownCodeQuoteMarkup()
        {
            string expected = "```some code```";
            var codeQuote = new CodeQuote("some code");

            string actual = codeQuote.Create();
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Given_Header_When_Level2AndTextAsParameter_Then_ReturnMarkdownHeaderMarkup()
        {
            string expected = "# header\n";
            var header = new Header(2, "header");

            string actual = header.Create();
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Given_List_When_TextAsParameter_Then_ReturnMarkdownListMarkup()
        {
            string expected = "- some text\n";
            var list = new List("some text");

            string actual = list.Create();
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Given_Link_When_TextAndUrlAsParameter_Then_ReturnMarkdownLinkMarkup()
        {
            string expected = "[some text](some url)";
            var link = new Link("some text", "some url");

            string actual = link.Create();
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Given_Image_When_AllTextAndImageUrlAsParameter_Then_ReturnMarkdownImageMarkup()
        {
            string expected = "![some text](some url)";
            var image = new Image("some text", "some url");

            string actual = image.Create();
            Assert.Equal(expected, actual);
        }
    }
}