namespace Antares.BuildTools
{
    public interface IInternalVdproj2XmlConverter
    {
        ValidatedCommandParameter ValidatedParameter { get; set; }

        void Convert();
    }
}

