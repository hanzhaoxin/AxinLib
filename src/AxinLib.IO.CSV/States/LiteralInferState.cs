using AxinLib.IO.CSV.Exceptions;
using System.Linq;

namespace AxinLib.IO.CSV.States
{
    public class LiteralInferState : IState
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
                return context.SwitchEscapeState();
            }
            if (context.Configurator.FieldEndCharacter.Equals(c))
            {
                return context.SwitchFieldEndState();
            }
            if (context.Configurator.RowEndCharacters.Contains(c))
            {
                return context.SwitchRowEndState(c);
            }
            throw new CsvReadException(context.RowIndex, context.FieldIndex);
        }
    }
}