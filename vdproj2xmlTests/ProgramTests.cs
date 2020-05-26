using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antares.BuildTools;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using Moq;

namespace Antares.BuildTools.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest_NoCommandlineArgument()
        {
            var builderMock = new Mock<IVdproj2XmlConverter>();
            builderMock.Setup(builder => builder.Convert());
            Program.VdprojectBuilder = builderMock.Object;
            Program.Main(new string[] { });
            builderMock.Verify(builder => builder.Convert(), Times.Once());
        }
    }
}

