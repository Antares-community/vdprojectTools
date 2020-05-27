using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Antares.BuildTools
{
    public class CommandParameterValidator : ICommandParameterValidator
    {
        public ValidatedCommandParameter Validate(CommandParameter rawParameter)
        {
            if (rawParameter == null)
            {
                throw new ArgumentNullException(nameof(rawParameter));
            }

            if (string.IsNullOrWhiteSpace(rawParameter.InputFilePath) ||
                string.IsNullOrWhiteSpace(rawParameter.OutputFilePath) ||
                File.Exists(rawParameter.InputFilePath) == false)
            {
                throw new CommandlineParseException(Properties.Resources.CommandlineHelpMessage);
            }

            return new ValidatedCommandParameter
            {
                InputFile = new FileInfo(rawParameter.InputFilePath),
                OutputFile = new FileInfo(rawParameter.OutputFilePath),
                Overwrite = rawParameter.Overwrite,
                SeparateValue = rawParameter.SeparateValue,
            };
        }
    }
}
