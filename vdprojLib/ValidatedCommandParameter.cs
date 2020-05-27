using Microsoft.Win32.SafeHandles;
using System.IO;

namespace Antares.BuildTools
{
    public class ValidatedCommandParameter
    {
        public bool Overwrite { get; set; }
        public bool SeparateValue { get; set; }
        public FileInfo OutputFile { get; set; }
        public FileInfo InputFile { get; set; }
    }
}