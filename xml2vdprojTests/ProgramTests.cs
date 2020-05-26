using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antares.BuildTools;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace Antares.BuildTools.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest_NoCommandlineArgument()
        {
            var builderMock = new Mock<IXml2VdprojConverter>();
            builderMock.Setup(builder => builder.Convert());
            Program.Xml2VdprojConverter = builderMock.Object;
            Program.Main(new string[] { });
            builderMock.Verify(builder => builder.Convert(), Times.Once());
        }
    }
}

