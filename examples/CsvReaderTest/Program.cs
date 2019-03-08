using AxinLib.IO.CSV;
using System;
using System.IO;

namespace CsvReaderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var sr = new StreamReader(@"files\test.csv"))
                {
                    CsvReader csvReader = new CsvReader(sr);
                    Field field;
                    while (null != (field = csvReader.ReadField()))
                    {
                        Console.WriteLine($"row:{field.RowIndex},field:{field.RowIndex},value:{field.Value}.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("end.");
        }
    }
}
