namespace Antares.BuildTools
{
    public interface IXml2VdprojConverter
    {
        CommandParameter Parameter { get; set; }

        void Convert();
    }
}
