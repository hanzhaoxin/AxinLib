namespace AxinLib.IO.CSV.States
{
    public class EscapeState : IState
    {
        public Field Read(CsvReader context)
        {
            int i = context.Reader.Read();
            if (context.Configurator.FileEndFlag.Equals(i))
            {
                return context.SwitchFileEndState();
            }

            char c = (char)i;
            if (context.Configurator.EscapeCharacter.Equals(c))
            {
                return context.SwitchLiteralInferState();
            }

            context.FieldValueBuilder.Append(c);
            return context.ReadField();
        }
    }
}