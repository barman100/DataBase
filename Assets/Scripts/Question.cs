
[System.Serializable]
public class Question
{
    // need to start with lower letter to fit json formatting even tho the og name in Question's class is with capital letter
    public string questionString;
    public string answer_01;
    public string answer_02;
    public string answer_03;
    public string answer_04;
    public int correctAnswer;
}