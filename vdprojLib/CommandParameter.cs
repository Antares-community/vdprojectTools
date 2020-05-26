using CommandLine;
using System.ComponentModel.DataAnnotations;

namespace Antares.BuildTools
{
    public class CommandParameter
    {
        [Option('i', "input")]
        [Required(AllowEmptyStrings = false)]
        [FileExists]
        public string InputFilePath { get; set; }

        [Option('o', "output")]
        [Required(AllowEmptyStrings = false)]
        [FilePath]
        public string OutputFilePath { get; set; }

        [Option('v', "overwrite")]
        public bool Overwrite { get; set; }
    }
}

