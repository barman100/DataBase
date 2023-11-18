namespace TriviaAPI
{
    [Serializable]
    public class Question
    {
        public string question { get; set; }
        public string ans1 { get; set; }
        public string ans2 { get; set; }
        public string ans3 { get; set; }
        public string ans4 { get; set; }
        public int correct { get; set; }

        public Question(string question, string ans1, string ans2, string ans3, string ans4, int correct)
        {
            this.question = question;
            this.ans1 = ans1;
            this.ans2 = ans2;
            this.ans3 = ans3;
            this.ans4 = ans4;
            this.correct = correct;
            
        }
    }
}
