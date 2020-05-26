using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antares.BuildTools;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Antares.BuildTools.Tests
{
    [TestClass()]
    public class FilePathAttributeTests
    {
        public class Test
        {
            [FilePath]
            public string File { get; set; }
        }

        [TestMethod()]
        public void FilePathAttribute01()
        {
            var test = new Test
            {
                File = "<><><>",
            };

            var context = new ValidationContext(test)
            {
                MemberName = nameof(Test.File),
            };
            var list = new List<ValidationResult>();
            var isValid = Validator.TryValidateProperty(
                test,
                context,
                list);

            Assert.IsFalse(isValid);
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod()]
        public void FilePathAttribute02()
        {
            var test = new Test
            {
                File = Guid.NewGuid().ToString(),
            };

            var context = new ValidationContext(test)
            {
                MemberName = nameof(Test.File),
            };
            var list = new List<ValidationResult>();
            var isValid = Validator.TryValidateProperty(
                test,
                context,
                list);

            Assert.IsTrue(isValid);
            Assert.AreEqual(0, list.Count);
        }
    }
}
