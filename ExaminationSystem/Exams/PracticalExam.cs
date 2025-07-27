using ExaminationSystem.Questions;

namespace ExaminationSystem.Exams
{
    public class PracticalExam : Exam
    {
        public PracticalExam(int timeOfExam, int numberOfQuestions, Question[] questions) : base(timeOfExam, numberOfQuestions, questions)
        {
        }

        public override void ShowExam()
        {
            string elapsedTime;

            Answer[] answers = ExamHelper
                .ReadStudentAnswers(Questions, TimeOfExam, out elapsedTime);

            Console.Clear();

            int i = 1;
            foreach (var q in Questions)
            {
                Console.WriteLine($"Q{i++} Right Answer => " +
                    $"{q.Answers.FirstOrDefault(a => a.id == q.RightAnswer).Text}");
            }

            Console.WriteLine($"Time = {elapsedTime}");
            Console.WriteLine("Thank You");
        }
    }
}
