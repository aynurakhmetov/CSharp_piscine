using System;
using System.Reflection;
using System.Reflection.Emit;
using Markdown.Generator.Core.Documents;
using Markdown.Generator.Core.Markdown;
using Moq;
using Xunit;

namespace Markdown.Generator.Core.Tests
{
    
    public class GithubWikiDocumentBuilderTests
    {
        [Fact]
        public void Given_LoadMethod_When_TypesAsParameter_CallCorrectAndOnce()
        {
            Mock<IMarkdownGenerator> mock = new Mock<IMarkdownGenerator>();
            mock.Setup(mg => mg.Load(It.IsAny<Type[]>()));
            
            var documentBuilder = new GithubWikiDocumentBuilder<IMarkdownGenerator>(mock.Object);
            documentBuilder.Generate(null, "some_string");
            
            mock.Verify(mg => mg.Load(It.IsAny<Type[]>()), Times.Once());
        }
        
        [Fact]
        public void Given_LoadMethod_When_TwoStringAsParameters_CallCorrectAndOnce()
        {
            Mock<IMarkdownGenerator> mock = new Mock<IMarkdownGenerator>();
            mock.Setup(mg => mg.Load(It.IsAny<string>(), It.IsAny<string>()));
            
            var documentBuilder = new GithubWikiDocumentBuilder<IMarkdownGenerator>(mock.Object);
            documentBuilder.Generate("some_string", "some_string", "some_string");
            
            mock.Verify(mg => mg.Load(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }
        
        [Fact]
        public void Given_LoadMethod_When_AssemblyAndTwoStringAsParameters_CallCorrectAndOnce()
        {
            Mock<IMarkdownGenerator> mock = new Mock<IMarkdownGenerator>();
            mock.Setup(mg => mg.Load(It.IsAny<Assembly[]>(), It.IsAny<string>()));
            
            var documentBuilder = new GithubWikiDocumentBuilder<IMarkdownGenerator>(mock.Object);

            var assembly = typeof(int).Assembly;
            Assembly[] assemblyArray = {assembly};
            documentBuilder.Generate(assemblyArray, "some_string", "some_string");
            
            mock.Verify(mg => mg.Load(It.IsAny<Assembly[]>(), It.IsAny<string>()), Times.Once());
        }
    }
}