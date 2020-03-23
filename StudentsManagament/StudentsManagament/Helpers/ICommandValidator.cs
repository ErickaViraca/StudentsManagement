namespace StudentsManagament.Helpers
{
    public interface ICommandValidator
    {
        bool VerifyParameter(string value);
        bool VerifyCorrectFormat(string parameter);
        string GetCommandParameter(string argument);
        string GetCommandParameterValue(string argument);
    }
}
