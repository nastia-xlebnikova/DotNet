using System;
using System.Text.Json;

namespace khlebnikova5
{
    public class Program
    {
        static void Main(string[] args)
        {
            var studList = new Container();
            var studHelper = new ContFile();
            var studCalc = new ContCalc();
            studList.Add(new Student("Lugovoy Alexander Evgenievich", new DateTime(2000, 10, 8), new DateTime(2019, 9, 1), "b", 119, "CIT", "Computer engineering", 94));
            studList.Add(new Student("Babich Dmitry Olegovich", new DateTime(1998, 10, 10), new DateTime(2017, 9, 1), "b", 217, "E", "Power engineering", 68));
            studList.Add(new Student("Orlova Vlada Stanislavovna", new DateTime(2001, 12, 8), new DateTime(2019, 9, 1), "b", 119, "CIT", "Computer engineering", 94));
            studList.Add(new Student("Khlebnikova Anastasia Dmitrievna", new DateTime(2002, 12, 10), new DateTime(2019, 9, 1), "b", 119, "CIT", "Computer engineering", 86));

            studCalc.Container = studList;
            

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(studList, options);

            Console.WriteLine(jsonString);

            Container studList2 = JsonSerializer.Deserialize<Container>(jsonString);
            studList2.PrintAll();
        }
    }
}