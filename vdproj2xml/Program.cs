using CommandLine;
using System;

namespace Antares.BuildTools
{
    public static class Program
    {
        public static IVdproj2XmlConverter VdprojectBuilder { get; set; } = new Vdproj2XmlConverter();

        public static void Main(string[] args)
        {
            var result = Parser.Default.ParseArguments<CommandParameter>(args);
            VdprojectBuilder.Parameter = ((Parsed<CommandParameter>)result).Value;
            VdprojectBuilder.Convert();
        }
    }
}
