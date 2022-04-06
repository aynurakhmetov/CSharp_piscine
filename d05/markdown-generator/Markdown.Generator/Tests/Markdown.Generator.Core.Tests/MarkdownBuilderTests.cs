using System;
using Markdown.Generator.Core.Markdown;
using Markdown.Generator.Core.Markdown.Elements;
using Xunit;

namespace Markdown.Generator.Core.Tests
{
    public class MarkdownBuilderTests
    {
        [Fact]
        public void Given_MarkdownBuilder_When_ElementCodeIsAdded_Then_AddedOnceWithTypeCode()
        {
            var expectedCount = 1;
            var actualCount = 0;
            var markdownBuilder = new MarkdownBuilder();
            var code = new Code("csharp", "some code");

            markdownBuilder.Code("csharp", "some code");
            var elements = markdownBuilder.Elements;
            
            foreach (var e in elements)
            {
                actualCount++;
            }
            Assert.Equal(expectedCount, actualCount);
            Assert.Contains(elements, e => e.GetType() == code.GetType());
        }
        
        [Fact]
        public void Given_MarkdownBuilder_When_ElementCodeQuoteIsAdded_Then_AddedOnceWithTypeCodeQuote()
        {
            var expectedCount = 1;
            var actualCount = 0;
            var markdownBuilder = new MarkdownBuilder();
            var codeQoute = new CodeQuote("some code");
        
            markdownBuilder.CodeQuote("some code");
            var elements = markdownBuilder.Elements;
            
            foreach (var e in elements)
            {
                actualCount++;
            }
            Assert.Equal(expectedCount, actualCount);
            Assert.Contains(elements, e => e.GetType() == codeQoute.GetType());
        }
        
        [Fact]
        public void Given_MarkdownBuilder_When_ElementLinkIsAdded_Then_AddedOnceWithTypeLink()
        {
            var expectedCount = 1;
            var actualCount = 0;
            var markdownBuilder = new MarkdownBuilder();
            var link = new Link("some text", "some url");
        
            markdownBuilder.Link("some text", "some url");
            var elements = markdownBuilder.Elements;
            
            foreach (var e in elements)
            {
                actualCount++;
            }
            Assert.Equal(expectedCount, actualCount);
            Assert.Contains(elements, e => e.GetType() == link.GetType());
        }
        
        [Fact]
        public void Given_MarkdownBuilder_When_ElementHeaderIsAdded_Then_AddedOnceWithTypeHeader()
        {
            var expectedCount = 1;
            var actualCount = 0;
            var markdownBuilder = new MarkdownBuilder();
            var header = new Header(2, "header");
        
            markdownBuilder.Header(2, "header");
            var elements = markdownBuilder.Elements;
            
            foreach (var e in elements)
            {
                actualCount++;
            }
            Assert.Equal(expectedCount, actualCount);
            Assert.Contains(elements, e => e.GetType() == header.GetType());
        }
    }
}