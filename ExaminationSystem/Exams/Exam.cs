using ExaminationSystem.Questions;

namespace ExaminationSystem.Exams
{
    public abstract class Exam
    {
        protected Exam(int timeOfExam, int numberOfQuestions, Question[] questions)
        {
            TimeOfExam = timeOfExam;
            NumberOfQuestions = numberOfQuestions;
            Questions = questions;
        }

        public int TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        public Question[] Questions { get; set; }

        public abstract void ShowExam();
    }
}
