using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antares.BuildTools;
using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace Antares.BuildTools.Tests
{
    [TestClass()]
    public class CommandParameterTests
    {
        [TestMethod()]
        public void Parse_Commandline_Parameter_Test01()
        {
            var i = Guid.NewGuid().ToString();
            var o = Guid.NewGuid().ToString();

            var result = Parser.Default.ParseArguments<CommandParameter>(new string[]
            {
                "-i", i,
                "-o", o
            });

            Assert.IsNotNull(result);
            Assert.AreEqual(ParserResultType.Parsed, result.Tag);

            var parameter = ((Parsed<CommandParameter>)result).Value;
            Assert.IsNotNull(parameter);
            Assert.AreEqual(i, parameter.InputFilePath);
            Assert.AreEqual(o, parameter.OutputFilePath);
            Assert.AreEqual(false, parameter.Overwrite);
        }

        [TestMethod()]
        public void Parse_Commandline_Parameter_Test02()
        {
            var i = Guid.NewGuid().ToString();
            var o = Guid.NewGuid().ToString();

            var result = Parser.Default.ParseArguments<CommandParameter>(new string[]
            {
                "-i", i,
                "--overwrite",
                "-o", o,
            });

            Assert.IsNotNull(result);
            Assert.AreEqual(ParserResultType.Parsed, result.Tag);

            var parameter = ((Parsed<CommandParameter>)result).Value;
            Assert.IsNotNull(parameter);
            Assert.AreEqual(i, parameter.InputFilePath);
            Assert.AreEqual(o, parameter.OutputFilePath);
            Assert.AreEqual(true, parameter.Overwrite);
        }

        [TestMethod()]
        public void Validate_Commandline_Parameter_Test01()
        {
            string i = "";
            try
            {
                i = Path.GetTempFileName();
                var parameter = new CommandParameter
                {
                    InputFilePath = i,
                    OutputFilePath = "",
                };

                var errors = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(
                    parameter,
                    new ValidationContext(parameter),
                    errors);
                Assert.IsFalse(isValid);
                Assert.AreEqual(1, errors.Count);
            }
            finally
            {
                if (File.Exists(i))
                {
                    File.Delete(i);
                }
            }
        }
    }
}

