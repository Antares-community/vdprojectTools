namespace Antares.BuildTools
{
    public interface ICommandParameterValidator
    {
        ValidatedCommandParameter Validate(CommandParameter rawParameter);
    }
}