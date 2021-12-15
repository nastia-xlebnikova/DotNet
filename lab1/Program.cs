using System;
namespace khlebnikova01
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stud1 = new Student("Бабич Дмитрий Олегович", new DateTime(1998, 10, 10), new DateTime(2017, 9, 1), "Б", 217, "Э", "Энергетическое машиностроение", 68);
            Student stud2 = new Student("Хлебникова Анастасия Дмитриевна", new DateTime(2001, 12, 10), new DateTime(2019, 9, 1), "Б", 119, "КИТ", "Компьютерная инженерия", 86);

            Console.WriteLine(stud1.ToText());
            Console.WriteLine("\n");
            Console.WriteLine(stud2.ToText());
        }
    }
}
