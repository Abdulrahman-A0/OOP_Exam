using ExaminationSystem.Exams;
using ExaminationSystem.Questions;
using ExaminationSystem.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public static class Helper
    {
        static List<Subject> subjects = new List<Subject>
        {
                new Subject(1,"OOP"),
                new Subject(2,"C#"),
                new Subject(3,"MVC"),
        };

        public static void ShowSubjects()
        {
            foreach (var subj in subjects)
            {
                Console.WriteLine(subj.ToString());
            }
        }

        public static Subject ChooseSubject()
        {
            int subjectId;
            do
            {
                Console.Write("Enter Subject id to create exam for: ");
            } while (!int.TryParse(Console.ReadLine(), out subjectId) || subjectId <= 0 || subjectId > subjects.Count);

            return subjects.FirstOrDefault(s => s.Id == subjectId);
        }


    }
}
