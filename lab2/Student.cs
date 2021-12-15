using System;

namespace khlebnikova2
{
	// Класс Студенты
	public class Student
	{
		private string name;
		private DateTime dateOfBirthday;
		private int ageOfAdmission;
		private string groupInfo;
		private int progress;


		//Конструктор без параметров
		public Student() { }
		// Конструктор с параметрами 
		public Student(string n, int date, int month, int age, int admission, string group, int prog)
		{
			name = n;
			dateOfBirthday = new DateTime(age, month, date);

			ageOfAdmission = admission;
			groupInfo = group;
			progress = prog;
		}

		public string Name { get { return name; } set { name = value; } }

		public DateTime DateOfBirthday { get { return dateOfBirthday; } set { dateOfBirthday = value; } }

		public int AgeOfAdmission { get { return ageOfAdmission; } set { ageOfAdmission = value; } }

		public string GroupInfo { get { return groupInfo; } set { groupInfo = value; } }

		public int Progress { get { return progress; } set { progress = value; } }

		// Переопределенный метод ToString()

		public override string ToString()
		{
			return $"ФИО:{ Name }, Дата рождения: " + dateOfBirthday.ToShortDateString() + ", Год поступления: "
					+ ageOfAdmission + ", Группа: " + groupInfo + ", Прогресс: " + progress + "%";
		}
	}
}
