namespace AxinLib.IO.CSV.States
{
    public interface IState
    {
        Field Read(CsvReader context);
    }
}