namespace AxinLib.IO.CSV
{
    public class Field
    {
        public int RowIndex { get; set; }

        public int FieldIndex { get; set; }

        public string Value { get; set; }

        private Field()
        {
        }

        public static Field Build(int rowIndex, int fieldIndex, string value)
        {
            var field = new Field();
            field.RowIndex = rowIndex;
            field.FieldIndex = fieldIndex;
            field.Value = value;
            return field;
        }
    }
}