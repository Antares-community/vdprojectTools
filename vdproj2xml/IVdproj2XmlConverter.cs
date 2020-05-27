namespace Antares.BuildTools
{
    public interface IVdproj2XmlConverter
    {
        CommandParameter Parameter { get; set; }

        int Convert();
    }
}
