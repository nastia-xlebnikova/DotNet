using System;
using System.Linq;
using System.Collections;
using System.Text;

namespace khlebnikova8
{
    public class Student
    {
        private string _name;
        private DateTime _dateOfBirth;
        private DateTime _dateOfAdmission;
        private string _specialty;
        private int _performance;
        public Group _group;
        private string[] _faculties = { "СГТ", "ХТ", "БЭМ", "КН", "КИТ", "Э", "МИТ", "И" };

        public delegate bool Compare(Student stud, string line);

        public static bool CompareGroup(Student stud, string line)
        {
            if (stud._group.FullName == line) return true;
            else return false;
        }

        public static bool CompareSpecialty(Student stud, string line)
        {
            if (stud.Specialty == line) return true;
            else return false;
        }

        public static bool CompareFaculty(Student stud, string line)
        {
            if (stud._group._faculty == line) return true;
            else return false;
        }

        public Student(string name, DateTime dateOfBirth, DateTime dateOfAdmission, string groupIndex, int groupNum, string faculty, string specialty, int performance)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _dateOfBirth = dateOfBirth;
            _dateOfAdmission = dateOfAdmission;
            _group = new Group(groupNum, faculty, groupIndex);
            _specialty = specialty ?? throw new ArgumentNullException(nameof(specialty));
            _performance = performance;
        }

        public string Name { get { return _name; } }
        public DateTime DateOfBirth { get { return _dateOfBirth; } }
        public DateTime DateOfAdmission { get { return _dateOfAdmission; } }

        public int Year
        {
            get
            {
                int year = (int)((DateTime.Now - _dateOfAdmission).TotalDays / 365.2425) + 1;
                if (year > 6) year = 6;
                else if (year < 0)
                {
                    year = 0;
                }
                return year;
            }
        }

        public int Semester
        {
            get
            {
                int day = (int)((DateTime.Now - _dateOfAdmission).TotalDays % 365.2425);
                if (day < 150)
                {
                    return 1;
                }
                else return 2;
            }
        }

        public int Age
        {
            get
            {
                return (int)((DateTime.Now - _dateOfBirth).TotalDays / 365.2425);
            }
        }

        public string Specialty { get { return _specialty; } private set { _specialty = value; } }
        public int Performance
        {
            get { return _performance; }
            set
            {
                if (value <= 100 && value >= 0)
                {
                    _performance = value;
                }
            }
        }
        public override string ToString()
        {
            string output = $"{_name};{_dateOfBirth.ToString()};{_dateOfAdmission};{_group.ToString()};{_specialty};{_performance}";
            return output;
        }
        public static Student ParseString(string line)
        {
            string[] arr = line.Split(";");
            Student stud = new Student(arr[0], DateTime.Parse(arr[1]), DateTime.Parse(arr[2]), arr[5], Int32.Parse(arr[4]), arr[3], arr[6], Int32.Parse(arr[7]));
            return stud;
        }
        public string ToText()
        {
            string output = $"Ф.И.О.: {_name}\nДата рождения: {_dateOfBirth.ToString()}\nДата поступления: {_dateOfAdmission}\nГруппа: {_group.FullName}\nСпециальность: {_specialty}\nУспеваемость: {_performance}%";
            return output;
        }
    }
}
