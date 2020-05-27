using System;

namespace Antares.BuildTools
{
    public class Xml2VdprojConverter
    {
        public CommandParameter Parameter { get; set; }

        public CommandParameterValidator CommandParameterValidator { get; set; } = new CommandParameterValidator();

        public InternalXml2VdprojConverter InternalXml2VdprojConverter { get; set; } = new InternalXml2VdprojConverter();

        public int Convert()
        {
            try
            {
                InternalXml2VdprojConverter.ValidatedParameter = CommandParameterValidator.Validate(Parameter);
                InternalXml2VdprojConverter.Convert();
                return 0;
            }
            catch (CommandlineParseException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return -1;
            }
        }
    }
}

