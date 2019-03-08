using System;

namespace AxinLib.IO.CSV.Exceptions
{
    public class CsvReadException : Exception
    {
        public int RowIndex { get; private set; }

        public int FieldIndex { get; private set; }

        public CsvReadException(int rowIndex, int fieldIndex) : base($"csv read exception in row:{rowIndex},field:{fieldIndex}.")
        {
            RowIndex = rowIndex;
            FieldIndex = fieldIndex;
        }
    }
}