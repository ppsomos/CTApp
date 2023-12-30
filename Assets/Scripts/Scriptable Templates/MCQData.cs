using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/MCQs")]
public class MCQData : ScriptableObject
{
    public enum type { MCQ, TrueFalse };
    enum answer { wrong, correct };

    public type quizType;

    public int questionIndex;
    public string[] questions;
    // public int CompletedQuestionsindexHist;
    // public int CompletedQuestionsindexGeo;
    public string[] Question_Explanation;

    public string[] Op1;
    public string[] Op2;
    public string[] Op3;
    public string[] Op4;

    public int[] answersIndex;

    // public int TotalScore;

}
