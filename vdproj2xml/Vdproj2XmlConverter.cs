using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace Antares.BuildTools
{
    public class Vdproj2XmlConverter 
    {
        public CommandParameter Parameter { get; set; }

        public CommandParameterValidator CommandParameterValidator { get; set; } = new CommandParameterValidator();

        public InternalVdproj2XmlConverter InternalVdproj2XmlConverter { get; set; } = new InternalVdproj2XmlConverter();

        public int Convert()
        {
            try
            {
                InternalVdproj2XmlConverter.ValidatedParameter = CommandParameterValidator.Validate(Parameter);
                InternalVdproj2XmlConverter.Convert();
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

