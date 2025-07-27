using ExaminationSystem.Questions;
using System.Diagnostics;

namespace ExaminationSystem.Exams
{
    public class FinalExam : Exam
    {
        public FinalExam(int timeOfExam, int numberOfQuestions, Question[] questions) : base(timeOfExam, numberOfQuestions, questions)
        {
        }

        public override void ShowExam()
        {

            string elapsedTime;
            Answer[] answers = ExamHelper.ReadStudentAnswers(Questions, TimeOfExam, out elapsedTime);
            Console.Clear();

            int grade = 0;
            int totalMark = 0;

            ExamHelper.CalculateStudentGrade(ref grade, ref totalMark, Questions, answers);
            Console.WriteLine($"Your Grade is {grade} from {totalMark}");
            Console.WriteLine($"Time = {elapsedTime}");
            Console.WriteLine("Thank You");
        }
    }
}
