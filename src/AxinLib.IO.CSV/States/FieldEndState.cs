namespace AxinLib.IO.CSV.States
{
    public class FieldEndState : IState
    {
        public Field Read(CsvReader context)
        {
            var field = Field.Build(context.RowIndex, context.FieldIndex, context.FieldValueBuilder.ToString());
            context.FieldValueBuilder.Clear();
            context.FieldIndex++;
            context.SwitchNewFieldState();
            return field;
        }
    }
}