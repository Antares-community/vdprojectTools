using CommandLine;
using System;

namespace Antares.BuildTools
{
    public static class Program
    {
        public static IXml2VdprojConverter Xml2VdprojConverter { get; set; } = new Xml2VdprojConverter();

        public static void Main(string[] args)
        {
            var result = Parser.Default.ParseArguments<CommandParameter>(args);
            Xml2VdprojConverter.Parameter = ((Parsed<CommandParameter>)result).Value;
            Xml2VdprojConverter.Convert();
        }
    }
}
