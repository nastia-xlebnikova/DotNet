using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khlebnikova8
{
    public class Group
    {
        public readonly int _groupNum;
        public readonly string _faculty;
        public readonly string _groupIndex;


        public readonly string[] faculties = { "Э", "МИТ", "И", "ХТ", "БЭМ", "МО", "СГТ", "КН", "КИТ", "CIT" };

        public string FullName
        {
            get
            {
                return $"{_faculty}-{_groupNum}{_groupIndex}";
            }
        }

        public Group(int groupNum, string faculty, string groupIndex)
        {
            if (faculties.Contains(faculty.ToUpper()))
            {
                _groupIndex = groupIndex;
                _faculty = faculty;
                _groupNum = groupNum;
            }
            else throw new Exception("faculty value is not in facultie names list");

        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                Group other = (Group)obj;
                return other.FullName == FullName;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{_faculty};{_groupNum};{_groupIndex}";
        }
    }
}