using CommandLine;
using System.ComponentModel.DataAnnotations;

namespace Antares.BuildTools
{
    public class CommandParameter
    {
        [Option('i', "input")]
        [Required(AllowEmptyStrings = false)]
        [FileExists]
        public string SourceFilePath { get; set; }

        [Option('o', "output")]
        [Required(AllowEmptyStrings = false)]
        [FilePath]
        public string OutputFilePath { get; set; }
    }
}

