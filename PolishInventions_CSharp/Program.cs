using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CsvHelper;

namespace PolishInventions_CSharp
{
    class Program
    {
        private static string csvFileName = "20170531listaWynalazkow.csv";

        static IEnumerable<Invention> GetAllInventions(StreamReader thisStreamReader)
        {
            var csv = new CsvReader(thisStreamReader);
            csv.Configuration.Delimiter = ";";
            csv.Configuration.RegisterClassMap<InventionMap>();
            var records = csv.GetRecords<Invention>();

            //foreach (Invention record in records.Take(5))
            //{
            //    Debug.Print("{0} {1}, {2}", record.ApplicationNumber, record.ApplicationDate, record.Title);
            //}

            return records;
        }

        static void Main(string[] args)
        {
            char inputKey;
            do
            {
                Console.Clear();
                Console.WriteLine("Witamy w programie. Wybierz pozycję menu: ");
                Console.WriteLine("1. Zwróć trzy wynalazki, których tytuł rozpoczyna się od S lub P.");
                Console.WriteLine("2. Zwróć liczbę wynalazków zgłoszonych w styczniu '89.");
                Console.WriteLine("0. Zakończ pracę programu.");
                Console.WriteLine();
                Console.Write("Twój wybór: ");

                inputKey = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (inputKey)
                {
                    case '1':
                        using (StreamReader thisStreamReader = new StreamReader(csvFileName))
                        {
                            var particularInventions = GetAllInventions(thisStreamReader)
                                .Where(i => i.Title.StartsWith("S") || i.Title.StartsWith("P")).Take(3);
                            foreach (var invention in particularInventions)
                            {
                                Console.WriteLine("* {0}: {1}, {2}; twórcy: {3}", invention.ApplicationDate,
                                    invention.ApplicationNumber, invention.Title, invention.Creators);
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine("Naciśnij dowolny klawisz, aby kontynować.");
                        Console.ReadKey();
                        break;
                    case '2':
                        using (StreamReader thisStreamReader = new StreamReader(csvFileName))
                        {
                            var inventionsAmount = GetAllInventions(thisStreamReader)
                                .Where(i => i.ApplicationDate.StartsWith("1989-01")).Count();
                            Console.WriteLine("Ilość zgłoszonych wynalazków w styczniu 1989 roku: " + inventionsAmount);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Naciśnij dowolny klawisz, aby kontynować.");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            } while (inputKey != '0');
           
        }
    }
}
