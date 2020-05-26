using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Antares.BuildTools
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class FileExistsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            switch (value)
            {
                case null:
                    // The validation of the null value is done with the RequiredAttribute, so it is not needed here.
                    return true;

                case string filePath:
                    if (string.IsNullOrWhiteSpace(filePath))
                    {
                        // The validation of the null value is done with the RequiredAttribute, so it is not needed here.
                        return true;
                    }
                    return File.Exists(filePath);

                default:
                    throw new InvalidOperationException(value.ToString());
            }
        }
    }
}

