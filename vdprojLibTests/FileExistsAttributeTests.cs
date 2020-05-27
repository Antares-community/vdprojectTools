using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antares.BuildTools;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Antares.BuildTools.Tests
{
    [TestClass()]
    public class FileExistsAttributeTests
    {
        public class Test
        {
            [FileExists]
            public string TestProperty { get; set; }
        }

        [TestMethod()]
        public void FileExistsAttributeTest01()
        {
            var test = new Test
            {
                TestProperty = Guid.NewGuid().ToString(),
            };

            var context = new ValidationContext(test)
            {
                MemberName = nameof(Test.TestProperty),
            };
            var list = new List<ValidationResult>();
            var isValid = Validator.TryValidateProperty(
                test.TestProperty,
                context,
                list);

            Assert.IsFalse(isValid);
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod()]
        public void FileExistsAttributeTest02()
        {
            var test = new Test
            {
                TestProperty = Process.GetCurrentProcess().MainModule.FileName,
            };

            var context = new ValidationContext(test)
            {
                MemberName = nameof(Test.TestProperty),
            };
            var list = new List<ValidationResult>();
            var isValid = Validator.TryValidateProperty(
                test.TestProperty,
                context,
                list);

            Assert.IsTrue(isValid);
            Assert.AreEqual(0, list.Count);
        }
    }
}