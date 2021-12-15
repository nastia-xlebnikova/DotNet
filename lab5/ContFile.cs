using System;
using System.IO;
using System.Linq;

namespace khlebnikova5
{
    public class ContFile
    {
        public string Path { get; set; }
        public Container Container { get; set; }

        public ContFile(Container cont = null, string path = "output.txt")
        {
            Path = path;
            Container = cont;
        }
        public void Write(Container cont = null, string path = null)
        {
            Container rescont = cont ?? Container;
            string respath = path ?? Path;
            if (rescont != null)
            {
                File.WriteAllLines(respath, rescont.ToList());
            }
        }
        public Container Read(string path = null)
        {
            string respath = path ?? Path;
            string[] lines = File.ReadAllLines(respath);
            Container rescont = new Container();
            foreach (var line in lines)
            {
                rescont.Add(Student.ParseString(line));
            }
            return rescont;
        }
        public string ToTable(Container cont)
        {
            string result = $"|{"Ф.И.О",-30}|{"Группа",-10}|{"Успеваемость",-15}|\n";
            result += "|---------------------------------------------------------|\n";
            foreach (Student stud in cont)
            {
                result += $"|{stud.Name,-30}|{stud.Group,-10}|{stud.Performance,-15}|\n";
                result += "|---------------------------------------------------------|\n";
            }
            return result;
        }
        public string ToTable(Container cont, Student.Compare comp, string line)
        {
            string result = $"|{"Ф.И.О",-30}|{"Группа",-10}|{"Успеваемость",-15}|\n";
            result += "|---------------------------------------------------------|\n";
            foreach (Student stud in cont)
            {
                if (comp(stud, line))
                {
                    result += $"|{stud.Name,-30}|{stud.Group,-10}|{stud.Performance,-15}|\n";
                    result += "|---------------------------------------------------------|\n";
                };
            }
            return result;
        }
    }
}