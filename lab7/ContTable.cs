using System;
using System.IO;
using System.Linq;

namespace khlebnikova7
{
    public class ContTable
    {



        public ContTable(Container cont = null, string path = "output.txt")
        {
        }
        public void Write(Container cont = null, string path = null)
        {
            string respath = path;
            if (cont != null)
            {
                File.WriteAllLines(respath, cont.ToList());
            }
        }
        public static Container Read(string path = null)
        {
            string[] lines = File.ReadAllLines(path);
            Container rescont = new Container();
            foreach (var line in lines)
            {
                rescont.Add(Student.ParseString(line));
            }
            return rescont;
        }

        public static string ToTable(Container cont)
        {
            string result = $"|{"Ф.И.О",-35}|{"Группа",-10}|{"Успеваемость",-15}|\n";
            result += "|--------------------------------------------------------------|\n";
            foreach (Student stud in cont)
            {
                result += $"|{stud.Name,-35}|{stud.Group,-10}|{stud.Performance,-15}|\n";
                result += "|--------------------------------------------------------------|\n";
            }
            return result;
        }
        public static string ToTable(Container cont, Student.Compare comp, string line)
        {
            string result = $"|{"Ф.И.О",-35}|{"Группа",-10}|{"Успеваемость",-15}|\n";
            result += "|--------------------------------------------------------------|\n";
            foreach (Student stud in cont)
            {
                if (comp(stud, line))
                {
                    result += $"|{stud.Name,-35}|{stud.Group,-10}|{stud.Performance,-15}|\n";
                    result += "|--------------------------------------------------------------|\n";
                };
            }
            return result;
        }
    }
}
