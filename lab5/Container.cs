using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace khlebnikova5
{
    public class Container : IEnumerator, IEnumerable
    {
        private List<Student> list;
        private int position = -1;
        public Container()
        {
            list = new List<Student>();
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
            foreach (Student stud in list)
            {
                if (!brief) Console.WriteLine(i + "." + stud.ToText() + "\n");
                else Console.WriteLine(i + "." + stud.Name + "\n");
                i++;
            }
        }
        public Student GetStudent(int index)
        {
            if (index < list.Count && index >= 0)
            {
                return list.ElementAt<Student>(index);
            }
            else throw new IndexOutOfRangeException();
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

        public Student GetStudent(string name)
        {
            foreach (Student stud in list)
            {
                if (stud.Name == name)
                {
                    return stud;
                }
            }
            return null;
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
            foreach (Student stud in list)
            {
                if (comp(stud, line))
                {
                    list.Remove(stud);
                }
            }
        }
    }
}
