using System;
using System.Linq;
using System.Collections;
using System.Text;

namespace khlebnikova5
{
    public class Student
    {
        private readonly string _name;
        private readonly DateTime _birthDate;
        private readonly DateTime _admissionDate;
        private string _groupInd;
        private int _groupNum;
        private string _faculty;
        private string _specialty;
        private int _performance;
        private string[] _faculties = { "СГТ", "ХТ", "БЭМ", "КН", "КИТ", "Э", "МИТ", "И" };

        public delegate bool Compare(Student stud, string line);

        public static bool CompareGroup(Student stud, string line)
        {
            if (stud.Group == line) return true;
            else return false;
        }

        public static bool CompareSpecialty(Student stud, string line)
        {
            if (stud.Specialty == line) return true;
            else return false;
        }

        public static bool CompareFaculty(Student stud, string line)
        {
            if (stud.Faculty == line) return true;
            else return false;
        }
        public Student(string studName, DateTime birthDate, DateTime admissionDate, string groupInd, int groupNum, string faculty, string specialty, int perf)
        {
            _name = studName ?? throw new ArgumentNullException(nameof(studName));
            _birthDate = birthDate;
            _admissionDate = admissionDate;
            _groupInd = groupInd ?? throw new ArgumentNullException(nameof(groupInd));
            _groupNum = groupNum;
            _faculty = faculty ?? throw new ArgumentNullException(nameof(faculty));
            _specialty = specialty ?? throw new ArgumentNullException(nameof(specialty));
            _performance = perf;
        }

        public string Name { get { return _name; } }
        public DateTime BirthDate { get { return _birthDate; } }
        public DateTime AdmissionDate { get { return _admissionDate; } }
        public string GroupInd
        {
            get { return _groupInd; }
            private set
            {
                if (value.Length <= 2 && value.Length != 0)
                {
                    _groupInd = value;
                }
            }
        }
        public string Group
        {
            get
            {
                return $"{_faculty}-{_groupNum}{GroupInd}";
            }
        }

        public int Year
        {
            get
            {
                int year = (int)((DateTime.Now - _admissionDate).TotalDays / 365.2425) + 1;
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
                int day = (int)((DateTime.Now - _admissionDate).TotalDays % 365.2425);
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
                return (int)((DateTime.Now - _birthDate).TotalDays / 365.2425);
            }
        }

        public int GroupNum { get { return _groupNum; } private set { _groupNum = value; } }
        public string Faculty
        {
            get { return _faculty; }
            private set
            {
                if (_faculties.Contains(value.ToUpper()))
                {
                    _faculty = value.ToUpper();
                }
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
            string output = $"{_name};{_birthDate.ToString()};{_admissionDate};{_faculty};{_groupNum};{_groupInd};{_specialty};{_performance}";
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
            string output = $"Ф.И.О.: {_name}\nДата рождения: {_birthDate.ToString()}\nДата поступления: {_admissionDate}\nГруппа: {_faculty}-{_groupNum}{_groupInd}\nСпециальность: {_specialty}\nУспеваемость: {_performance}%";
            return output;
        }
    }
}
