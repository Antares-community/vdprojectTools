using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Antares.VdprojTools.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateEmptyVdprojFile()
        {
            const string nameOfVdprojFile = "NameOfVdproj";
            try
            {
                // create empty vdproj file.
                int exitCode = Program.Main(new string[] { "new", nameOfVdprojFile });

                Assert.AreEqual(0, exitCode);
                Assert.IsTrue(File.Exists(nameOfVdprojFile + ".vdproj"));
            }
            finally
            {
                if (File.Exists(nameOfVdprojFile + ".vdproj"))
                {
                    File.Delete(nameOfVdprojFile + ".vdproj");
                }
            }
        }
    }
}
