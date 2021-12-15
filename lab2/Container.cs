using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace khlebnikova2
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
            foreach (Student student in list)
            {
                if (!brief)
                {
                    Console.WriteLine(i + "." + student.ToString() + "\n");
                }
                else
                {
                    Console.WriteLine(i + "." + student.Name + "\n");
                    i++;
                }

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
    }
}
