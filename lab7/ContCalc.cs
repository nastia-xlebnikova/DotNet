using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khlebnikova7
{
    class ContCalc
    {
        public Container Container { get; set; }
        public ContCalc(Container cont = null)
        {
            Container = cont;
        }

        public float AverageAge(Student.Compare comp, string line)
        {
            float total = 0;
            int count = 0;
            IEnumerable<int> query =
                from Student stud in Container
                where comp(stud, line)
                select stud.Age;

            foreach (var age in query)
            {
                total += age;
                count++;
            }
            return total / count;
        }

        public float AveragePerformance(Student.Compare comp, string line)
        {
            float total = 0;
            int count = 0;
           
            IEnumerable<int> query =
                from Student stud in Container
                where comp(stud, line)
                select stud.Performance;

            foreach (var age in query)
            {
                total += age;
                count++;
            }
            return total / count;
        }

        public int CountByComp(Student.Compare comp, string line)
        {
            int result =
                (from Student stud in Container
                 where comp(stud, line)
                 select stud).Count();
            return result;
        }

        public static int CountByComp(Container Container, Student.Compare comp, string line)
        {
            int result =
                (from Student stud in Container
                 where comp(stud, line)
                 select stud).Count();
            return result;
        }

        public static float AveragePerformance(Container Container, Student.Compare comp, string line)
        {
            float total = 0;
            int count = 0;
           
            IEnumerable<int> query =
                from Student stud in Container
                where comp(stud, line)
                select stud.Performance;

            foreach (var age in query)
            {
                total += age;
                count++;
            }
            return total / count;
        }

        public static float AverageAge(Container Container, Student.Compare comp, string line)
        {
            float total = 0;
            int count = 0;
          
            IEnumerable<int> query =
                from Student stud in Container
                where comp(stud, line)
                select stud.Age;

            foreach (var age in query)
            {
                total += age;
                count++;
            }
            return total / count;
        }


    }
}
