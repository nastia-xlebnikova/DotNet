using System.IO;
using System.Linq;

namespace khlebnikova4
{
    class ContFile
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
    }
}
