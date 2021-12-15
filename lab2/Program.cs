using System;

namespace khlebnikova2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Container studList = new Container();
            studList.Add(new Student("Луговой Александр Евгениевич", 2, 7, 2000, 2017, "KIT-117b", 85));
            studList.Add(new Student("Бабич Дмитрий Олегович", 4, 8, 1998, 2017, "KIT-217b", 68));
            studList.Add(new Student("Орлова Влада Станиславовна", 11, 2, 2001, 2019, "KIT-119b", 90));
            studList.Add(new Student("Хлебникова Анастасия Дмитриевна", 10, 12, 2001, 2019, "KIT-119b", 80));
            Console.WriteLine("\nВывод в полном формате\n");
            studList.PrintAll(false);
            studList.PrintAll(true);
            Console.WriteLine("\nПолучение информации о конкретном студенте по имени Хлебникова Анастасия Дмитриевна: \n");
            Console.WriteLine(studList.GetStudent("Хлебникова Анастасия Дмитриевна").ToString());
            int i = 1;
            Console.WriteLine("\nВывод студентов с их успеваемостью: \n");
            foreach (Student stud in studList)
            {
                Console.WriteLine(i + "." + stud.Name + ": " + stud.Progress + "\n");
                i++;
            }
            Console.ReadLine();
        }
    }
}