namespace AxinLib.IO.CSV.Configurators
{
    public class DefaultConfigurator : IConfigurator
    {
        public virtual char EscapeCharacter => '\"';

        public virtual char FieldEndCharacter => ',';

        public virtual char[] RowEndCharacters => new char[2] { '\r', '\n' };

        public int FileEndFlag => -1;
    }
}