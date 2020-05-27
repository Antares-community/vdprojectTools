using CommandLine;
using System.ComponentModel.DataAnnotations;

namespace Antares.BuildTools
{
    public class CommandParameter
    {
        [Option('i', "input")]
        [FileExists]
        public string InputFilePath { get; set; }

        [Option('o', "output")]
        public string OutputFilePath { get; set; }

        [Option('v', "overwrite")]
        public bool Overwrite { get; set; }

        [Option('s', "separate")]
        public bool SeparateValue { get; set; }
    }
}

