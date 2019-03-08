using AxinLib.IO.CSV.Configurators;
using AxinLib.IO.CSV.States;
using System.IO;
using System.Text;

namespace AxinLib.IO.CSV
{
    public class CsvReader
    {
        public TextReader Reader { get; private set; }

        public int RowIndex { get; set; } = 0;

        public int FieldIndex { get; set; } = 0;

        public StringBuilder FieldValueBuilder { get; } = new StringBuilder();

        public IState State { get; set; } = StateHolder.NewFieldState;

        public IConfigurator Configurator { get; } = new DefaultConfigurator();

        public CsvReader(TextReader reader)
        {
            Reader = reader;
        }

        public CsvReader(TextReader reader, IConfigurator configurator)
        {
            Reader = reader;
            Configurator = configurator;
        }

        public Field ReadField()
        {
            if (State is FileEndState)
            {
                return null;
            }
            return State.Read(this);
        }
    }
}