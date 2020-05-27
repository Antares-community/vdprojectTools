using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antares.BuildTools;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Linq;

namespace Antares.BuildTools.Tests
{
    [TestClass()]
    public class Vdproj2XmlConverterTests
    {
        [TestMethod()]
        public void ConvertTest1_Separate()
        {
            var inputFilePath = @"TestData\Setup1.vdproj";
            string outputFilePath = "";
            try
            {
                outputFilePath = Path.GetTempFileName();
                var parameter = new CommandParameter
                {
                    InputFilePath = inputFilePath,
                    OutputFilePath = outputFilePath,
                    SeparateValue = true,
                };

                var converter = new Vdproj2XmlConverter
                {
                    Parameter = parameter,
                };
                converter.Convert();

                Assert.IsTrue(File.Exists(outputFilePath));
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(outputFilePath);

                var documentElement = xmlDocument.DocumentElement;
                Assert.AreEqual("Test1", documentElement.Name);

                CollectionAssert.AreEqual(
                    documentElement.ChildNodes.OfType<XmlNode>().Select(n => n.Attributes["Value"].Value).ToArray(),
                    new string[]
                    {
                        "123", "simpletext", "FALSE", "1"
                    });
                CollectionAssert.AreEqual(
                    documentElement.ChildNodes.OfType<XmlNode>().Select(n => n.Attributes["tYPE"].Value).ToArray(),
                    new string[]
                    {
                        "3", "8", "11", "2"
                    });
            }
            finally
            {
                if (File.Exists(outputFilePath))
                {
                    File.Delete(outputFilePath);
                }
            }
        }

        [TestMethod()]
        public void ConvertTest1_NotSeparate()
        {
            var inputFilePath = @"TestData\Setup1.vdproj";
            string outputFilePath = "";
            try
            {
                outputFilePath = Path.GetTempFileName();
                var parameter = new CommandParameter
                {
                    InputFilePath = inputFilePath,
                    OutputFilePath = outputFilePath,
                    SeparateValue = false,
                };

                var converter = new Vdproj2XmlConverter
                {
                    Parameter = parameter,
                };
                converter.Convert();

                Assert.IsTrue(File.Exists(outputFilePath));
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(outputFilePath);

                var documentElement = xmlDocument.DocumentElement;
                Assert.AreEqual("Test1", documentElement.Name);

                CollectionAssert.AreEqual(
                    documentElement.ChildNodes.OfType<XmlNode>().Select(n => n.Attributes["Value"].Value).ToArray(),
                    new string[]
                    {
                        "3:123", "8:simpletext", "11:FALSE", "2:1"
                    });
            }
            finally
            {
                if (File.Exists(outputFilePath))
                {
                    File.Delete(outputFilePath);
                }
            }
        }

        [TestMethod()]
        public void ConvertTest2_Separate()
        {
            var inputFilePath = @"TestData\Setup2.vdproj";
            string outputFilePath = "";
            try
            {
                outputFilePath = Path.GetTempFileName();
                var parameter = new CommandParameter
                {
                    InputFilePath = inputFilePath,
                    OutputFilePath = outputFilePath,
                    SeparateValue = true,
                };

                var converter = new Vdproj2XmlConverter
                {
                    Parameter = parameter,
                };
                converter.Convert();

                Assert.IsTrue(File.Exists(outputFilePath));
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(outputFilePath);

                XmlNode node = xmlDocument.DocumentElement;
                Assert.AreEqual("Test1", node.Name);
                node = node.FirstChild;
                Assert.AreEqual("Test2", node.Name);

                CollectionAssert.AreEqual(
                    node.ChildNodes.OfType<XmlNode>().Select(n => n.Attributes["Value"].Value).ToArray(),
                    new string[]
                    {
                        "123", "simpletext", "FALSE", "1"
                    });
                CollectionAssert.AreEqual(
                    node.ChildNodes.OfType<XmlNode>().Select(n => n.Attributes["tYPE"].Value).ToArray(),
                    new string[]
                    {
                        "3", "8", "11", "2"
                    });
            }
            finally
            {
                if (File.Exists(outputFilePath))
                {
                    File.Delete(outputFilePath);
                }
            }
        }

        [TestMethod()]
        public void ConvertTest2_NotSeparate()
        {
            var inputFilePath = @"TestData\Setup2.vdproj";
            string outputFilePath = "";
            try
            {
                outputFilePath = Path.GetTempFileName();
                var parameter = new CommandParameter
                {
                    InputFilePath = inputFilePath,
                    OutputFilePath = outputFilePath,
                    SeparateValue = false,
                };

                var converter = new Vdproj2XmlConverter
                {
                    Parameter = parameter,
                };
                converter.Convert();

                Assert.IsTrue(File.Exists(outputFilePath));
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(outputFilePath);

                XmlNode node = xmlDocument.DocumentElement;
                Assert.AreEqual("Test1", node.Name);
                node = node.FirstChild;
                Assert.AreEqual("Test2", node.Name);

                CollectionAssert.AreEqual(
                    node.ChildNodes.OfType<XmlNode>().Select(n => n.Attributes["Value"].Value).ToArray(),
                    new string[]
                    {
                        "3:123", "8:simpletext", "11:FALSE", "2:1"
                    });
            }
            finally
            {
                if (File.Exists(outputFilePath))
                {
                    File.Delete(outputFilePath);
                }
            }
        }
    }
}

