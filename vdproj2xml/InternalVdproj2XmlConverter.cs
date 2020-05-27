using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace Antares.BuildTools
{
    public class InternalVdproj2XmlConverter
    {
        private readonly Regex regex = new Regex("\\\"(?<label>[^\\\"]+)\\\" = \\\"(?<type>\\d+)\\:(?<val>.*)\\\"", RegexOptions.Compiled);
        public ValidatedCommandParameter ValidatedParameter { get; set; }

        public void Convert()
        {
            var outputFileMode = GetOutputFileMode();

            using (var outputStream = ValidatedParameter.OutputFile.Open(outputFileMode, FileAccess.Write))
            {
                using (var xmlWriter = XmlWriter.Create(outputStream, new XmlWriterSettings { Indent = true }))
                {
                    Convert(xmlWriter);
                }
            }
        }


        private void Convert(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartDocument();
            using (var streamReader = ValidatedParameter.InputFile.OpenText())
            {
                Convert(streamReader, xmlWriter);
            }
            xmlWriter.WriteEndDocument();
        }

        private void Convert(StreamReader streamReader, XmlWriter xmlWriter)
        {
            while (streamReader.EndOfStream == false)
            {
                var line = streamReader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                line = line.Trim();
                var match = regex.Match(line);
                if (match.Success)
                {
                    WritLeafNode(match, xmlWriter);
                }
                else if (line == "}")
                {
                    xmlWriter.WriteEndElement();
                }
                else if (line != "{")
                {
                    xmlWriter.WriteStartElement("Node");
                    xmlWriter.WriteAttributeString("Name", line.Trim('"'));
                }
            }
        }

        private void WritLeafNode(Match match, XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement(match.Groups["label"].Value);
            if (ValidatedParameter.SeparateValue)
            {
                xmlWriter.WriteAttributeString("Type", match.Groups["type"].Value);
                xmlWriter.WriteAttributeString("Value", match.Groups["val"].Value);
            }
            else
            {
                xmlWriter.WriteAttributeString(
                    "Value",
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "{0}:{1}",
                        match.Groups["type"].Value,
                        match.Groups["val"].Value));
            }
            xmlWriter.WriteEndElement();
        }

        private FileMode GetOutputFileMode()
        {
            if (ValidatedParameter.Overwrite)
            {
                return FileMode.Create;
            }
            else
            {
                return FileMode.CreateNew;
            }
        }
    }
}

