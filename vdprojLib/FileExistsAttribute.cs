using System;
using System.ComponentModel.DataAnnotations;

namespace Antares.BuildTools
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class FileExistsAttribute : ValidationAttribute
    {
    }
}

