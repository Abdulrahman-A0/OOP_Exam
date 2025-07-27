using ExaminationSystem.Exams;
using ExaminationSystem.Questions;

namespace ExaminationSystem.Subjects
{
    internal class SubjectHelper
    {
        public static Exam BuildExam()
        {
            int examType = ChooseExamType();
            int examTime = ExamTime();
            int numOfQuestions = ExamQuestionsNumber();
            Console.Clear();

            Question[] questions = examType == 1 ? ReadPracticalExamQuestions(numOfQuestions) : ReadFinalExamQuestions(numOfQuestions);

            return examType == 1 ?
                new PracticalExam(examType, numOfQuestions, questions) :
                new FinalExam(examType, numOfQuestions, questions);
        }
        private static int ChooseExamType()
        {
            int examTypeId;
            do
            {
                Console.WriteLine("Please Enter the type of Exam (1 for Practical | 2 for Final)");
            } while (!int.TryParse(Console.ReadLine(), out examTypeId) || examTypeId < 1 || examTypeId > 2);

            return examTypeId;
        }

        private static int ExamTime()
        {
            int time;
            do
            {
                Console.WriteLine("Please Enter the Time For Exam From (30 min to 180 min)");
            } while (!int.TryParse(Console.ReadLine(), out time) || time < 30 || time > 180);

            return time;
        }

        private static int ExamQuestionsNumber()
        {
            int questionsNum;
            do
            {
                Console.WriteLine("Please Enter the Number of Questions");
            } while (!int.TryParse(Console.ReadLine(), out questionsNum));

            return questionsNum;
        }

        private static Question[] ReadFinalExamQuestions(int NumberOfQuestions)
        {
            Question[] questions = new Question[NumberOfQuestions];

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                questions[i] = ChooseQuestionType();
                if (questions[i] is TrueFalse)
                    ReadTrueFalse(questions[i]);
                else
                    ReadMCQQuestion(questions[i]);
            }

            return questions;
        }

        private static Question[] ReadPracticalExamQuestions(int NumberOfQuestions)
        {
            Question[] questions = new Question[NumberOfQuestions];

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                questions[i] = ReadTrueFalse(new TrueFalse());
            }

            return questions;
        }

        private static Question ChooseQuestionType()
        {
            int questionsType;
            do
            {
                Console.WriteLine("Please Enter the Type of Question (1 for MCQ | 2 for True | False)");
            } while (!int.TryParse(Console.ReadLine(), out questionsType) || questionsType < 1 || questionsType > 2);

            Console.Clear();

            return questionsType == 1 ? new MCQ() : new TrueFalse();
        }

        private static void ReadQuestionBodyMark(Question question)
        {
            Console.WriteLine(question.Header);
            string body;
            int mark;
            do
            {
                Console.WriteLine("Please Enter Question Body");
                body = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(body));

            do
            {
                Console.WriteLine("Please Enter Question Mark");
            } while (!int.TryParse(Console.ReadLine(), out mark));
            question.Body = body;
            question.Mark = mark;
        }
        private static Question ReadTrueFalse(Question question)
        {

            ReadQuestionBodyMark(question);

            int rightAnswer;
            do
            {
                Console.WriteLine("Please Enter the right answer id (1 for True | 2 for False)");
            } while (!int.TryParse(Console.ReadLine(), out rightAnswer) || rightAnswer < 1 || rightAnswer > 2);

            question.RightAnswer = rightAnswer;
            Console.Clear();
            return question;
        }

        private static Question ReadMCQQuestion(Question question)
        {

            ReadQuestionBodyMark(question);

            question.Answers = ReadMCQAnswers();


            int rightAnswer;
            do
            {
                Console.WriteLine("Please Enter the right answer id");
            } while (!int.TryParse(Console.ReadLine(), out rightAnswer) || rightAnswer < 1 || rightAnswer > 3);

            question.RightAnswer = rightAnswer;
            Console.Clear();
            return question;
        }

        private static Answer[] ReadMCQAnswers()
        {
            Answer[] answers = new Answer[3];
            Console.WriteLine("Choices of Question");
            for (int i = 0; i < 3; i++)
            {
                string answer;
                do
                {
                    Console.WriteLine($"Please Enter Choice Number{i + 1}");
                    answer = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(answer));
                answers[i] = new Answer(i + 1, answer);
            }

            return answers;
        }
    }
}
