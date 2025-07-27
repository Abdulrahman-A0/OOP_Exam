using ExaminationSystem.Exams;
using ExaminationSystem.Questions;
using ExaminationSystem.Subjects;

namespace ExaminationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Helper.ShowSubjects();

            Subject subject = Helper.ChooseSubject();

            subject.Exam = subject.CreateExam();

            char choice;
            do
            {
                Console.WriteLine("Do You Want to start Exam (Y|N)");
            } while (!char.TryParse(Console.ReadLine().ToLower(), out choice) || (choice != 'y' && choice != 'n'));

            Console.Clear();

            if (choice == 'y')
                subject.Exam.ShowExam();
            else
                return;
        }
    }
}
