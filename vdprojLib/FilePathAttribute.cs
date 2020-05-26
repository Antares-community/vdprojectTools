using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Security;
using System.Security.Authentication;

namespace Antares.BuildTools
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class FilePathAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            switch (value)
            {
                case null:
                    // The validation of the null value is done with the RequiredAttribute, so it is not needed here.
                    return true;

                case string filePath:
                    try
                    {
                        _ = new FileInfo(filePath);
                        return true;
                    }
                    catch (Exception ex)
                    when
                    (
                        ex is SecurityException ||
                        ex is ArgumentException ||
                        ex is UnauthorizedAccessException ||
                        ex is PathTooLongException ||
                        ex is NotSupportedException)
                    {
                        return false;

                        throw;
                    }

                default:
                    throw new InvalidOperationException(value.ToString());
            }
        }
    }
}

