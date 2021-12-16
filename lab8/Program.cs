using System;
using System.Collections.Generic;
using System.Text.Json;

namespace khlebnikova8
{
    public class Program
    {
        static void Main(string[] args)
        {
            var studList = new Container();
            studList.Add(new Student("Lugovoy Alexander Evgenievich", new DateTime(2000, 10, 8), new DateTime(2019, 9, 1), "b", 119, "CIT", "Computer engineering", 96));
            studList.Add(new Student("Orlova Vlada Stanislavovna", new DateTime(2001, 12, 8), new DateTime(2019, 9, 1), "b", 119, "CIT", "Computer engineering", 94));
            studList.Add(new Student("Khlebnikova Anastasia Dmitrievna", new DateTime(2002, 12, 10), new DateTime(2019, 9, 1), "b", 119, "CIT", "Computer engineering", 86));

            Console.WriteLine(ContFile.ToTable(studList));

            studList.Reset();
            studList.Sort(Container.SortType.Performance);

            Console.WriteLine("Сортировка по успеваемости.\n");

            studList.Reset();
            Console.WriteLine(ContFile.ToTable(studList));
        }
    }
}