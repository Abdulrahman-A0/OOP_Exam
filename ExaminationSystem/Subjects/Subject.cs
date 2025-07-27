using ExaminationSystem.Exams;
using ExaminationSystem.Questions;

namespace ExaminationSystem.Subjects
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Exam Exam { get; set; }

        public Subject(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Exam CreateExam()
        {
            return SubjectHelper.BuildExam();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }



    }
}
