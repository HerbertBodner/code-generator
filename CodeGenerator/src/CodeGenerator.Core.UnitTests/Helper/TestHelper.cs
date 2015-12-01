using System.IO;

namespace CodeGenerator.Core.UnitTests.Helper
{
    public static class TestHelper
    {
        public const string AssemblyName = "CodeGenerator.Core.SampleModel";

        public static string GetTestAssemblyPath()
        {
            var localPath = Path.GetFullPath("./" + AssemblyName + ".dll");
            var absPathDll = Path.GetFullPath(Path.Combine("./", AssemblyName + ".dll"));
            return absPathDll;
        }
    }
}
