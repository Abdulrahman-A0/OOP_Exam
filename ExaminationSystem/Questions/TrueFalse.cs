namespace ExaminationSystem.Questions
{
    public class TrueFalse : Question
    {
        public TrueFalse()
        {
            Header = "True | False Question";
            Answers = new Answer[]
            {
                new Answer(1,"True"),
                new Answer(2,"False"),
            };
        }
    }
}
