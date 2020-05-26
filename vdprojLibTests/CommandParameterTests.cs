using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antares.BuildTools;
using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace Antares.BuildTools.Tests
{
    [TestClass()]
    public class CommandParameterTests
    {
        [TestMethod()]
        public void CommandParameterTest01()
        {
            //[Option('i', "input")]
            //[Option('o', "output")]
            var result = Parser.Default.ParseArguments<CommandParameter>(new string[]
            {
                "-i", "test",
                "-o", "test"
            });

            Assert.IsNotNull(result);
            Assert.AreEqual(ParserResultType.Parsed, result.Tag);
        }

        [TestMethod()]
        public void CommandParameterTest02()
        {
            //[Option('i', "input")]
            //[Option('o', "output")]
            var result = Parser.Default.ParseArguments<CommandParameter>(new string[]
            {
                "--input", "test",
                "--output", "test"
            });

            Assert.IsNotNull(result);
            Assert.AreEqual(ParserResultType.Parsed, result.Tag);
        }
    }
}

