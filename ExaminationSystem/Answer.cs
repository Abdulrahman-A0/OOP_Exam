namespace ExaminationSystem
{
    public class Answer
    {
        public int id { get; set; }
        public string Text { get; set; }

        public Answer(int id, string text)
        {
            this.id = id;
            Text = text;
        }
    }
}
