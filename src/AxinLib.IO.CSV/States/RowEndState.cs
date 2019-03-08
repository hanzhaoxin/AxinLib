namespace AxinLib.IO.CSV.States
{
    public class RowEndState : IState
    {
        public Field Read(CsvReader context)
        {
            var field = Field.Build(context.RowIndex, context.FieldIndex, context.FieldValueBuilder.ToString());
            context.FieldValueBuilder.Clear();
            context.FieldIndex = 0;
            context.RowIndex++;
            context.SwitchNewFieldState();
            return field;
        }
    }
}