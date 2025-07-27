namespace ExaminationSystem.Questions
{
    public abstract class Question
    {
        public Question()
        {
        }

        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] Answers { get; set; }
        public int RightAnswer { get; set; }

    }
}
