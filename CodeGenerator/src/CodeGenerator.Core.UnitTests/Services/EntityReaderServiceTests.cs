using CodeGenerator.Core.Services;
using CodeGenerator.Core.UnitTests.Helper;
using System.IO;
using System.Linq;
using Xunit;

namespace CodeGenerator.Core.UnitTests.Services
{
    public class EntityReaderServiceTests
    {
        private EntityReaderService GetEntityReaderService()
        {
            return new EntityReaderService();
        }

        [Fact]
        public void GetAllClasses_AssemblyNotExists_ThrowsFileNotFoundException()
        {
            var absPathDll = Path.GetFullPath(Path.Combine(@"..\..\", "nonExistingDll", @"bin\Debug", "nonExistingDll.dll"));

            var entityReader = GetEntityReaderService();

            Assert.Throws< FileNotFoundException>(() => entityReader.GetAllClasses(absPathDll));
        }


        [Fact]
        public void GetAllClasses_OfSampleModel_ReturnsClassesFromSampleModel()
        {
            string absPathDll = TestHelper.GetTestAssemblyPath();

            var entityReader = GetEntityReaderService();

            var classTypes = entityReader.GetAllClasses(absPathDll, new[] { TestHelper.AssemblyName + ".Entities" }).ToList();

            Assert.Equal(4, classTypes.Count);

            Assert.NotNull(classTypes.FirstOrDefault(x => x.ClassName == "Person"));
            Assert.NotNull(classTypes.FirstOrDefault(x => x.ClassName == "Course"));
            Assert.NotNull(classTypes.FirstOrDefault(x => x.ClassName == "Student"));
            Assert.NotNull(classTypes.FirstOrDefault(x => x.ClassName == "Teacher"));
        }

        
    }
}
