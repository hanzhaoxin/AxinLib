namespace AxinLib.IO.CSV.Configurators
{
    public interface IConfigurator
    {
        char EscapeCharacter { get; }

        char FieldEndCharacter { get; }

        char[] RowEndCharacters { get; }

        int FileEndFlag { get; }
    }
}