using ExaminationSystem.Questions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Exams
{
    internal static class ExamHelper
    {
        public static Answer[] ReadStudentAnswers(Question[] questions, int examTime, out string elapsedTime)
        {
            Answer[] answers = new Answer[questions.Length];
            int answerId;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int counter = 0;
            foreach (var q in questions)
            {
                Console.WriteLine($"{q.Header}\t Mark:{q.Mark}\n");
                Console.WriteLine($"{q.Body}\n");
                foreach (var ans in q.Answers)
                {
                    Console.WriteLine($"{ans.id}-{ans.Text}");
                }

                do
                {
                    if (stopwatch.Elapsed.TotalMinutes >= examTime)
                    {
                        Console.WriteLine("Time's up while waiting for answer input!");
                        stopwatch.Stop();
                        elapsedTime = stopwatch.ToString();
                        return answers;
                    }
                    Console.WriteLine("Please Enter the answer Id");
                } while (!int.TryParse(Console.ReadLine(), out answerId) ||
                q is MCQ ? CheckMCQAnswer(answerId) : CheckTrueFalseAnswer(answerId)
                );

                answers[counter++] = q.Answers.FirstOrDefault(a => a.id == answerId);
            }
            stopwatch.Stop();
            elapsedTime = stopwatch.ToString();
            return answers;
        }

        public static void CalculateStudentGrade(ref int grade, ref int totalMark, Question[] questions, Answer[] answers)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"Question {i + 1} : {questions[i].Body}");
                Console.WriteLine($"Your Answer => {answers[i]?.Text}");
                Console.WriteLine($"Right Answer => {questions[i].Answers.FirstOrDefault(a => a.id == questions[i].RightAnswer).Text}");

                if (answers[i]?.id == questions[i].Answers[questions[i].RightAnswer - 1].id)
                {
                    grade += questions[i].Mark;
                }
                totalMark += questions[i].Mark;
            }
        }

        private static bool CheckTrueFalseAnswer(int answerId)
        {
            return answerId < 1 || answerId > 2;
        }

        private static bool CheckMCQAnswer(int answerId)
        {
            return answerId < 1 || answerId > 3;
        }
    }
}
