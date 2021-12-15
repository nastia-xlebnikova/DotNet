using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace khlebnikova6
{
    public class Container: IEnumerator, IEnumerable
    {
        private List<Student> list;
        private int position = -1;
        public Container()
        {
            list = new List<Student>();
        }
        public Container(List<Student> studList)
        {
            list = studList;
        }

        public void Add(Student stud)
        {
            list.Add(stud);
        }
        public bool Delete(int index)
        {
            if (index < list.Count && index >= 0)
            {
                list.RemoveAt(index);
                return true;
            }
            return false;
        }
        public void PrintAll(bool brief = true)
        {
            int i = 1;
            IEnumerable<string> query =
                from Student stud in list
                select brief ? stud.Name : stud.ToText();

            foreach (string line in query)
            {
                //if (!brief) Console.WriteLine(i + "." + stud.ToText() + "\n");
                //else Console.WriteLine(i + "." + stud.Name + "\n");
                Console.WriteLine(i + "." + line + "\n");
                i++;
            }
        }
        public Student GetStudent(int index)
        {
  

            IEnumerable<Student> query =
                from Student stud in list
                where list.IndexOf(stud) == index
                select stud;

            return query.First();
        }

        public Student GetStudent(string name)
        {
            IEnumerable<Student> query =
                from Student stud in list
                where stud.Name == name
                select stud;

            return query.First();
        }

        public bool ChangeStudent(int index, Student stud)
        {
            if (index < list.Count && index >= 0)
            {
                list[index] = stud;
                return true;
            }
            else return false;
        }

        public bool ChangeStudent(string name, Student stud)
        {
            int i = 0;
            foreach (Student stu in list)
            {
                if (stu.Name == name)
                {
                    list[i] = stud;
                    return true;
                }
                i++;
            }
            return false;
        }

        public int Count()
        {
            return list.Count;
        }
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
        //IEnumerator
        public bool MoveNext()
        {
            position++;
            return (position < list.Count());
        }
        //IEnumerable
        public void Reset()
        {
            position = 0;
        }
        //IEnumerable
        public object Current
        {
            get { return list.ElementAt<Student>(position); }
        }
        public string[] ToList()
        {
            string[] lines = new string[Count()];
            var i = 0;
            foreach (Student stud in list)
            {
                lines[i] = stud.ToString();
                i++;
            }
            return lines;
        }
        public void RemoveByComp(Student.Compare comp, string line)
        {

            IEnumerable<Student> query =
                from Student stud in list
                where comp(stud, line)
                select stud;

            foreach (Student stud in query)
            {
                list.Remove(stud);
            }
        }
    }
}
