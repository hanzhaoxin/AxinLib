namespace AxinLib.IO.CSV.States
{
    public class FileEndState : IState
    {
        public Field Read(CsvReader context)
        {
            var field = Field.Build(context.RowIndex, context.FieldIndex, context.FieldValueBuilder.ToString());
            context.FieldValueBuilder.Clear();
            return field;
        }
    }
}