namespace TriviaAPI
{
    [Serializable]
    public class Question
    {
        public string QuestionString { get; set; }
        public string Answer_01 { get; set; }
        public string Answer_02 { get; set; }
        public string Answer_03 { get; set; }
        public string Answer_04 { get; set; }
        public int CorrectAnswer { get; set; }

        public Question(string QuestionString, string Answer_01, string Answer_02, string Answer_03, string Answer_04, int CorrectAnswer)
        {
            this.QuestionString = QuestionString;
            this.Answer_01 = Answer_01;
            this.Answer_02 = Answer_02;
            this.Answer_03 = Answer_03;
            this.Answer_04 = Answer_04;
            this.CorrectAnswer = CorrectAnswer;
            
        }
    }
}
