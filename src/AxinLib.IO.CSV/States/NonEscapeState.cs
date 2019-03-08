using AxinLib.IO.CSV.Exceptions;
using System.Linq;

namespace AxinLib.IO.CSV.States
{
    public class NonEscapeState : IState
    {
        public Field Read(CsvReader context)
        {
            int i = context.Reader.Read();
            if (context.Configurator.FileEndFlag.Equals(i))
            {
                return context.SwitchFileEndState();
            }

            char c = (char)i;
            if (context.Configurator.FieldEndCharacter.Equals(c))
            {
                return context.SwitchFieldEndState();
            }
            if (context.Configurator.RowEndCharacters.Contains(c))
            {
                return context.SwitchRowEndState(c);
            }
            if (context.Configurator.EscapeCharacter.Equals(c))
            {
                throw new CsvReadException(context.RowIndex, context.FieldIndex);
            }
            context.FieldValueBuilder.Append(c);
            return context.ReadField();
        }
    }
}