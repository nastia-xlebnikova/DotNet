using System;
using System.Collections.Generic;
using System.IO;

namespace khlebnikova
{
    public class DataStudents
    {
        public static ArrayStudents<Student> students = ReadFile();

        public static ArrayStudents<Student> ReadFile()
        {
            ArrayStudents<Student> temp = new ArrayStudents<Student>();
            string name, lastname, patronym, faculty, text;
            DateTime birthday, date;
            int progress, specialty;
            char index;
            string path = @"F:\unik\3 course\DOT.NET\Students\Students\Students\InfoStudents.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    text = sr.ReadToEnd();

                    string[] separatingStrings = { " ", "\r", "\n", ":", "00:00:00", "\t", "Студенты", "Имя", "Фамилия", "Отчество", "День рождения",
                                    "Дата поступления", "Индекс группы", "Факультет", "Специальность", "Успеваемость"};
                    string[] words = text.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < words.Length / 9; i++)
                    {
                        name = words[9 * i];
                        lastname = words[9 * i + 1];
                        patronym = words[9 * i + 2];
                        birthday = DateTime.Parse(words[9 * i + 3]);
                        date = DateTime.Parse(words[9 * i + 4]);
                        index = char.Parse(words[9 * i + 5]);
                        faculty = words[9 * i + 6];
                        specialty = int.Parse(words[9 * i + 7]);
                        progress = int.Parse(words[9 * i + 8]);
                        var stud = new Student(name, lastname, patronym, birthday, date, index, faculty, specialty, progress);
                        temp.Add(stud);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return temp;
        }


    }
}