using FluentAssertions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace CompulsoryCow.AssemblyAbstractions.Unit.Tests
{
    /// <summary>This class contains tests of the (static) constructors
    /// in <see cref="System.Reflection.Assembly"/>
    /// which in AssemblyAbstractions is moved 
    /// from Assembly to AssemblyFactory
    /// as static constructors are impossible(?) to mock.
    /// </summary>
    public class AssemblyLoadContextTests
    {
        [Fact]
        public void AllMethodsShouldBeMockable()
        {
            // These methods are out of our control.
            var objectMethods = new[]
            {
                    nameof(AssemblyFactory.Equals),
                    nameof(AssemblyFactory.GetHashCode),
                    nameof(AssemblyFactory.GetType),
                    nameof(AssemblyFactory.ToString),
            };

            var methods = typeof(AssemblyLoadContext)
                .GetMethods()
                .Where(m => m.IsConstructor == false)
                .Where(m => objectMethods.Contains(m.Name) == false
                );

            var res = methods
                .Select(m => m.IsVirtual);

            //  Act.
            res.Count().Should().Be(1, "Sanity check we know how many methods we have.");

            res.Should().AllBeEquivalentTo(
                true,
                $"all methods {string.Join(",", methods.Select(m => m.Name))} should be virtual"
            );
        }

        [Fact]
        public void LoadFromStream_Stream_ShouldMimicSystem()
        {
            var alc = new System.Runtime.Loader.AssemblyLoadContext("any");
            var sut = new AssemblyLoadContext(alc);

            var compiledAssembly = Compile(SourceCode);
            using (var asm = new MemoryStream(compiledAssembly))
            {
                //  Act.
                var res = sut.LoadFromStream(asm);

                //  Assert.
                res.FullName.Should().Be("Any.dll, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");
            }
        }

        private static byte[] Compile(string sourceCode)
        {
            using (var peStream = new MemoryStream())
            {
                var result = GenerateCode(sourceCode).Emit(peStream);
                if (result.Success == false)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Diagnostics.Select(d => d.ToString())));
                }
                peStream.Seek(0, SeekOrigin.Begin);
                return peStream.ToArray();
            }
        }

        private static CSharpCompilation GenerateCode(string sourceCode)
        {
            var codeString = SourceText.From(sourceCode);
            var options = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp8);

            var parsedSyntaxTree = SyntaxFactory.ParseSyntaxTree(codeString, options);

            return CSharpCompilation.Create("Any.dll",
                new[] { parsedSyntaxTree },
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary,
                    optimizationLevel: OptimizationLevel.Debug,
                    assemblyIdentityComparer: DesktopAssemblyIdentityComparer.Default));
        }

        private const string SourceCode = @"
namespace AnyNameSpace
{
}";
    }
}
