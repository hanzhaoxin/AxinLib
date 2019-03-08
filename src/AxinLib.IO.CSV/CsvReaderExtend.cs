using AxinLib.IO.CSV.Exceptions;
using AxinLib.IO.CSV.States;
using System.Linq;

namespace AxinLib.IO.CSV
{
    internal static class CsvReaderExtend
    {
        public static void SwitchNewFieldState(this CsvReader context)
        {
            context.State = StateHolder.NewFieldState;
        }

        public static Field SwitchEscapeState(this CsvReader context)
        {
            context.State = StateHolder.EscapeState;
            return context.ReadField();
        }

        public static Field SwitchNonEscapeState(this CsvReader context)
        {
            context.State = StateHolder.NonEscapeState;
            return context.ReadField();
        }

        public static Field SwitchLiteralInferState(this CsvReader context)
        {
            context.State = StateHolder.LiteralInferState;
            return context.ReadField();
        }

        public static Field SwitchFieldEndState(this CsvReader context)
        {
            context.State = StateHolder.FieldEndState;
            return context.ReadField();
        }

        public static Field SwitchRowEndState(this CsvReader context, char charset)
        {
            foreach (var item in context.Configurator.RowEndCharacters.SkipWhile(c => c.Equals(charset)))
            {
                int i = context.Reader.Read();
                if (context.Configurator.FileEndFlag.Equals(i))
                {
                    return context.SwitchFileEndState();
                }
                char c = (char)i;
                if (!item.Equals(c))
                {
                    throw new CsvReadException(context.RowIndex, context.FieldIndex);
                }
            }
            context.State = StateHolder.RowEndState;
            return context.ReadField();
        }

        public static Field SwitchFileEndState(this CsvReader context)
        {
            context.State = StateHolder.FileEndState;
            return context.ReadField();
        }
    }
}