using System.Reflection;
using Markdown.Generator.Core.Markdown;
using Xunit;

namespace Markdown.Generator.Core.Tests
{
    public class MarkdownableTypeTests
    {
        [Fact]
        public void Given_MethodOfGetMethods_When_Get_Then_MethodsAreNotPrivate()
        {
            var sut = new Sut();
            var typeOfSut = sut.GetType();
            var markdownableType = new MarkdownableType(typeOfSut, null);
            
            var methodsOfSutActual = markdownableType.GetMethods();

            foreach (var m in methodsOfSutActual)
            {
                Assert.False(m.IsPrivate);
            }
        }
        
        [Fact]
        public void Given_MethodOfGetFields_When_Get_Then_FieldsAreNotPrivate()
        {
            var sut = new Sut();
            var typeOfSut = sut.GetType();
            var markdownableType = new MarkdownableType(typeOfSut, null);
            
            var fieldsOfSutActual = markdownableType.GetFields();

            foreach (var f in fieldsOfSutActual)
            {
                Assert.False(f.IsPrivate);
            }
        }
        
        [Fact]
        public void Given_MethodOfGetProperties_When_Get_Then_PropertiesAreNotPrivate()
        {
            var sut = new Sut();
            var typeOfSut = sut.GetType();
            var markdownableType = new MarkdownableType(typeOfSut, null);
            var expectedName = "PublicProperty";
            
            var propertyOfSutActual = markdownableType.GetProperties();

            foreach (var p in propertyOfSutActual)
            {
                Assert.Equal(expectedName, p.Name);
            }
        }
    }
    
    public class Sut
    {
        public string publicField;
        private string _privateField;

        public string PublicProperty { get; set; }
        private string PrivateProperty { get; set; }

        public void PublicMethod(){ }
        private void PrivateMethod(){ }
    }
}