using CodeGenerator.Core.Services;
using System.IO;
using System.Linq;
using Xunit;

namespace CodeGenerator.Core.UnitTests.Services
{
    public class EntityReaderServiceTests
    {
        const string AssemblyName = "CodeGenerator.Core.SampleModel";

        private EntityReaderService GetEntityReaderService()
        {
            return new EntityReaderService();
        }

        [Fact]
        public void GetAllClasses_AssemblyNotExists_ThrowsFileNotFoundException()
        {
            var absPathDll = Path.GetFullPath(Path.Combine(@"..\..\", AssemblyName, @"bin\Debug", AssemblyName + ".dll"));

            var entityReader = GetEntityReaderService();

            Assert.Throws< FileNotFoundException>(() => entityReader.GetAllClasses(absPathDll));
        }


        [Fact]
        public void GetAllClasses_OfSampleMovel_ReturnsClassesFromSampleModel()
        {
            var localPath = Path.GetFullPath("./" + AssemblyName + ".dll");
            var absPathDll = Path.GetFullPath(Path.Combine("./", AssemblyName + ".dll"));

            var entityReader = GetEntityReaderService();

            var classTypes = entityReader.GetAllClasses(absPathDll, new[] { AssemblyName + ".Entities" }).ToList();

            Assert.Equal(4, classTypes.Count);

            Assert.NotNull(classTypes.FirstOrDefault(x => x.ClassName == "Person"));
            Assert.NotNull(classTypes.FirstOrDefault(x => x.ClassName == "Course"));
            Assert.NotNull(classTypes.FirstOrDefault(x => x.ClassName == "Student"));
            Assert.NotNull(classTypes.FirstOrDefault(x => x.ClassName == "Teacher"));
        }
    }
}
