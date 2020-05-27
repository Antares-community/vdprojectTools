using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antares.BuildTools;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Linq;
using System.Diagnostics;

namespace Antares.BuildTools.Tests
{
    [TestClass()]
    public class Vdproj2XmlConverterTests
    {
        [TestMethod()]
        public void ConvertTest1_Separate()
        {
            var inputFilePath = @"TestDatas\Setup1.vdproj";
            string outputFilePath = "";
            try
            {
                outputFilePath = Path.GetTempFileName();
                var parameter = new CommandParameter
                {
                    InputFilePath = inputFilePath,
                    OutputFilePath = outputFilePath,
                    SeparateValue = true,
                    Overwrite = true,
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
                Assert.AreEqual("Node", documentElement.Name);
                Assert.AreEqual("Test1", documentElement.Attributes["Name"].Value);

                CollectionAssert.AreEqual(
                    documentElement.ChildNodes.OfType<XmlNode>().Select(n => n.Attributes["Value"].Value).ToArray(),
                    new string[]
                    {
                        "123", "sampletext", "FALSE", "1"
                    });
                CollectionAssert.AreEqual(
                    documentElement.ChildNodes.OfType<XmlNode>().Select(n => n.Attributes["Type"].Value).ToArray(),
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
            var inputFilePath = @"TestDatas\Setup1.vdproj";
            Assert.IsTrue(File.Exists(inputFilePath));
            string outputFilePath = "";
            try
            {
                outputFilePath = Path.GetTempFileName();
                File.Delete(outputFilePath);
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
                var ret = converter.Convert();
                Assert.AreEqual(0, ret);

                Assert.IsTrue(File.Exists(outputFilePath));
                Assert.AreNotEqual(0, new FileInfo(outputFilePath).Length);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(outputFilePath);

                var documentElement = xmlDocument.DocumentElement;
                Assert.AreEqual("Node", documentElement.Name);
                Assert.AreEqual("Test1", documentElement.Attributes["Name"].Value);

                CollectionAssert.AreEqual(
                    documentElement.ChildNodes.OfType<XmlNode>().Select(n => n.Attributes["Value"].Value).ToArray(),
                    new string[]
                    {
                        "3:123", "8:sampletext", "11:FALSE", "2:1"
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
            var inputFilePath = @"TestDatas\Setup2.vdproj";
            string outputFilePath = "";
            try
            {
                outputFilePath = Path.GetTempFileName();
                File.Delete(outputFilePath);
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
                Assert.AreEqual("Node", node.Name);
                Assert.AreEqual("Test1", node.Attributes["Name"].Value);
                node = node.FirstChild;
                Assert.AreEqual("Node", node.Name);
                Assert.AreEqual("Test2", node.Attributes["Name"].Value);

                CollectionAssert.AreEqual(
                    node.ChildNodes.OfType<XmlNode>().Select(n => n.Attributes["Value"].Value).ToArray(),
                    new string[]
                    {
                        "123", "sampletext", "FALSE", "1"
                    });
                CollectionAssert.AreEqual(
                    node.ChildNodes.OfType<XmlNode>().Select(n => n.Attributes["Type"].Value).ToArray(),
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
            var inputFilePath = @"TestDatas\Setup2.vdproj";
            string outputFilePath = "";
            try
            {
                outputFilePath = Path.GetTempFileName();
                var parameter = new CommandParameter
                {
                    InputFilePath = inputFilePath,
                    OutputFilePath = outputFilePath,
                    SeparateValue = false,
                    Overwrite = true,
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
                Assert.AreEqual("Node", node.Name);
                Assert.AreEqual("Test1", node.Attributes["Name"].Value);
                node = node.FirstChild;
                Assert.AreEqual("Node", node.Name);
                Assert.AreEqual("Test2", node.Attributes["Name"].Value);

                CollectionAssert.AreEqual(
                    node.ChildNodes.OfType<XmlNode>().Select(n => n.Attributes["Value"].Value).ToArray(),
                    new string[]
                    {
                        "3:123", "8:sampletext", "11:FALSE", "2:1"
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
        public void ConvertTest3_NotSeparate()
        {
            var inputFilePath = @"TestDatas\Setup3.vdproj";
            Assert.IsTrue(File.Exists(inputFilePath));
            string outputFilePath = "";
            try
            {
                outputFilePath = Path.GetTempFileName();
                File.Delete(outputFilePath);
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
                var ret = converter.Convert();
                Assert.AreEqual(0, ret);

                Assert.IsTrue(File.Exists(outputFilePath));
                Assert.AreNotEqual(0, new FileInfo(outputFilePath).Length);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(outputFilePath);

                var debugNode = xmlDocument.SelectSingleNode("descendant::Node[@Name='Configurations']/Node[@Name='Debug']");
                Assert.IsNotNull(debugNode);
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
        public void ConvertTest3_Separate()
        {
            var inputFilePath = @"TestDatas\Setup3.vdproj";
            Assert.IsTrue(File.Exists(inputFilePath));
            string outputFilePath = "";
            try
            {
                outputFilePath = Path.GetTempFileName();
                File.Delete(outputFilePath);
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
                var ret = converter.Convert();
                Assert.AreEqual(0, ret);

                Assert.IsTrue(File.Exists(outputFilePath));
                Assert.AreNotEqual(0, new FileInfo(outputFilePath).Length);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(outputFilePath);

                var folderNode = xmlDocument.SelectSingleNode("descendant::Node[@Name='Folder']/Node[@Name='{3C67513D-01DD-4637-8A68-80971EB9504F}:_E5E341FC067C4CAE9F7D45816FB168D3']");
                Assert.IsNotNull(folderNode);
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

