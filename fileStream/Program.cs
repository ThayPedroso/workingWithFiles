using System;
using System.IO;
using System.Globalization;

namespace fileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\temp\test\source.txt";

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path) + "\\out");

                string[] lines = File.ReadAllLines(path);

                using (StreamWriter sw = File.AppendText(Path.GetDirectoryName(path) + "\\out\\summary.txt"))
                {
                    foreach (string line in lines)
                    {
                        string[] dadosProduto = line.Split(',');
                        sw.WriteLine(dadosProduto[0] + "," + (double.Parse(dadosProduto[1], CultureInfo.InvariantCulture) * int.Parse(dadosProduto[2])).ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
