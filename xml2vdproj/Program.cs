using CommandLine;
using System;

namespace Antares.BuildTools
{
    public static class Program
    {
        public static Xml2VdprojConverter Xml2VdprojConverter { get; set; } = new Xml2VdprojConverter();

        public static int Main(string[] args)
        {
            var result = Parser.Default.ParseArguments<CommandParameter>(args);
            Xml2VdprojConverter.Parameter = ((Parsed<CommandParameter>)result).Value;
            return Xml2VdprojConverter.Convert();
        }
    }
}
