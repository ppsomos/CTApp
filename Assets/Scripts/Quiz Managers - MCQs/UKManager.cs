using EasyMobile;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UKManager : MonoBehaviour
{

    public CountDown countDown;
    public GameObject explanationPanel;
    public Text explainText;
    public GameObject NextButton;
    public GameObject ExplainClosebutton;
    public GameObject infoBtn;
    public MCQData MCQsData;
    public MCQData MCQsData_Italian;
    public PolishData polishMCQData;
    public PolishData GreekMCQData;
    public GameData GData;

    /// <summary>
    /// Fake News Quizes Data
    /// </summary>
    /// 

    public Button TickButton1;
    public Button TickButton2;
    public Button TickButton3;
    public Button TickButton4;

    public Button ResetButton;
    //public string[] TFQuestions;
    //public int[] TFAns;



    public Text Answerdecision;
    /// <summary>
    /// History Quiz Data
    /// </summary>
    /// 

    public string[] historyQues;
    public int[] historyAns;
    public static string historyFinalAnswer;
    public static int historyQuizIndex;

    private Option[] histOp1 = new Option[16];
    private Option[] histOp2 = new Option[16];
    private Option[] histOp3 = new Option[16];
    private Option[] histOp4 = new Option[16];

    public Text historyQuestonText;
    public Text[] historyOptionTexts;
    public TextMeshProUGUI historyScoreText;
    public GameObject historyCompleteImage;


    /// <summary>
    /// Geography Quiz Data
    /// </summary>
    /// 
    public string[] geographyQues;
    public int[] geographyAns;

    public static string geographyFinalAnswer;
    public static int geographyQuizIndex;

    private Option[] geogOp1 = new Option[16];
    private Option[] geogOp2 = new Option[16];
    private Option[] geogOp3 = new Option[16];
    private Option[] geogOp4 = new Option[16];


    public Text geographyQuestonText;
    public Text[] geographyOptionTexts;
    public TextMeshProUGUI geographyScoreText;
    public GameObject geographyCompleteImage;


    /// <summary>
    /// Food Quiz Data
    /// </summary>
    /// 
    public string[] foodQues;
    public int[] foodAns;

    public static string foodFinalAnswer;
    public static int foodQuizIndex;

    private Option[] foodOp1 = new Option[32];
    private Option[] foodOp2 = new Option[32];
    private Option[] foodOp3 = new Option[32];
    private Option[] foodOp4 = new Option[32];


    public Text foodQuestonText;
    public Text[] foodOptionTexts;
    public TextMeshProUGUI foodScoreText;
    public GameObject foodCompleteImage;



    /// <summary>
    /// Culture Quiz Data
    /// </summary>
    /// 
    public string[] cultureQues;
    public int[] cultureAns;

    public static string cultureFinalAnswer;
    public static int cultureQuizIndex;

    private Option[] culOp1 = new Option[32];
    private Option[] culOp2 = new Option[32];
    private Option[] culOp3 = new Option[32];
    private Option[] culOp4 = new Option[32];


    public Text cultureQuestonText;
    public Text[] cultureOptionTexts;
    public TextMeshProUGUI cultureScoreText;
    public GameObject cultureCompleteImage;


    enum answer { wrong, correct };
    public static int selectedCategory = 0;
    public GameObject quizPanel;
    public GameObject levelCompletePanel;
    [SerializeField] GameObject Background;
    public GameObject levelFailPanel;
    public GameObject cameraobj;

    public BoxCollider door1Col;
    public GameObject congratsPanel;
    public Text congratsPanelScore;
    public GameObject playerController;

    public GameObject controller;
    public LoadManager loadingManager;
    public static int selectedObj;
    private int HighlightIndex;

    public Text ScoreDisplayPanelText;
    public Text ScoreDisplayfailPanelText;
    public Text ScoreDisplayText;
    public GameObject PlayerNamePanel;
    public Text PlayerName_Text;
    public GameObject MulticongratsPanel;
    public GameObject QuizCamera;
    public GameObject QuizCanvas;
    public GameObject mainCavas;
    public GameObject RightAnswerPartical;
    public GameObject LoadingPanel;
    int opt1lenght;
    int opt2lenght;
    int opt3lenght;
    int opt4lenght;
    int QLength;
    int maxtextlenght;
    public Text ScrolQtext;
    public GameObject Scrolquestion;
    public GameObject questiontextobj;
    void Start()
    {
        selectedCategory = 0;

        // RemoveTextStyle.onClick.RemoveAllListeners();
        // RemoveTextStyle.onClick.AddListener(RemoveTextStyleFunc);
        ScoreDisplayText.text = (GData.RightAnswer * 5).ToString();
        if (GameManager.Instance.isMultiplayer)
        {
            PlayerNamePanel.SetActive(true);
            PlayerName_Text.text = GData.Multi_Player[GameManager.Instance.SelectedPlayer].PlayerName;
        }
        
    }

    void Update()
    {
        switch (GData.selectedLanguage)
        {
            case 0:
                historyScoreText.text = GData.ukData.completedHist.ToString() + "/" + 16;
                geographyScoreText.text = GData.ukData.completedGeo.ToString() + "/" + 16;
                break;
            case 1:
                historyScoreText.text = GData.ukData.completedHistItalian.ToString() + "/" + 16;
                geographyScoreText.text = GData.ukData.completedGeoItalian.ToString() + "/" + 16;
                break;
            case 2:
                historyScoreText.text = GData.ukData.completedHistGreek.ToString() + "/" + 16;
                geographyScoreText.text = GData.ukData.completedGeoGreek.ToString() + "/" + 16;
                break;
            case 3:
                historyScoreText.text = GData.ukData.completedHistpolish.ToString() + "/" + 16;
                geographyScoreText.text = GData.ukData.completedGeoPolish.ToString() + "/" + 16;
                break;
        }
    }
    #region History Quiz Data

    public void SetHistoryQuizData(int index)
    {

        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[0]));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[1]));

        TickButton3.onClick.RemoveAllListeners();
        TickButton3.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[2]));

        TickButton4.onClick.RemoveAllListeners();
        TickButton4.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[3]));

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel());

        //        TickButton3.gameObject.SetActive(false);

        selectedCategory = index;
        SetHistoryOptionData();
        //int temp = historyQuizIndex;

        switch (GData.selectedLanguage)
        {
            case 0:
                historyQuizIndex = GData.ukData.completedHist;
                break;
            case 1:
                historyQuizIndex = GData.ukData.completedHistItalian;
                break;
            case 2:
                historyQuizIndex = GData.ukData.completedHistGreek;
                break;
            case 3:
                historyQuizIndex = GData.ukData.completedHistpolish;
                break;
        }

        //historyQuizIndex = MCQsData.CompletedQuestionsindex;

        //if (temp == historyQuizIndex)
        //{
        //    historyQuizIndex = Random.Range(0, historyQues.Length);
        //}

        Debug.Log("Quiz index: " + historyQuizIndex);

        historyQuestonText.text = historyQues[historyQuizIndex];

        QLength = historyQuestonText.text.Length;
        Debug.Log("Question Lenght is==" + QLength.ToString());
        if (QLength > 400)
        {
            questiontextobj.SetActive(false);
            Scrolquestion.SetActive(true);
            ScrolQtext.text = historyQues[historyQuizIndex];
        }
        else
        {
            questiontextobj.SetActive(true);
            Scrolquestion.SetActive(false);
            historyQuestonText.text = historyQues[historyQuizIndex];
        }

        historyOptionTexts[0].text = histOp1[historyQuizIndex].answer;
        historyOptionTexts[1].text = histOp2[historyQuizIndex].answer;
        historyOptionTexts[2].text = histOp3[historyQuizIndex].answer;
        historyOptionTexts[3].text = histOp4[historyQuizIndex].answer;

        opt1lenght = historyOptionTexts[0].text.Length;
        opt2lenght = historyOptionTexts[1].text.Length;
        opt3lenght = historyOptionTexts[2].text.Length;
        opt4lenght = historyOptionTexts[3].text.Length;
        Debug.Log("lenght of op1==" + opt1lenght.ToString());
        Debug.Log("lenght of op2==" + opt2lenght.ToString());
        Debug.Log("lenght of op3==" + opt3lenght.ToString());
        Debug.Log("lenght of op4==" + opt4lenght.ToString());
       
        maxtextlenght = Mathf.Max(opt1lenght,opt2lenght,opt3lenght,opt4lenght);
        Debug.Log("maximum lenght is" + maxtextlenght);

        if(maxtextlenght<=20)
        {
            print("Font Set 40");
            historyOptionTexts[0].fontSize = 40;
            historyOptionTexts[1].fontSize = 40;
            historyOptionTexts[2].fontSize = 40;
            historyOptionTexts[3].fontSize = 40;
        }
        else if(maxtextlenght<= 100 &&maxtextlenght>20)
        {
            print("Font Set 35");
            historyOptionTexts[0].fontSize = 35;
            historyOptionTexts[1].fontSize = 35;
            historyOptionTexts[2].fontSize = 35;
            historyOptionTexts[3].fontSize = 35;
        }
        else if (maxtextlenght <= 150 && maxtextlenght > 100)
        {
            print("Font Set 33");
            historyOptionTexts[0].fontSize = 33;
            historyOptionTexts[1].fontSize = 33;
            historyOptionTexts[2].fontSize = 33;
            historyOptionTexts[3].fontSize = 33;
        }
        else if (maxtextlenght <= 200 && maxtextlenght > 150)
        {
            print("Font Set 27");
            historyOptionTexts[0].fontSize = 27;
            historyOptionTexts[1].fontSize = 27;
            historyOptionTexts[2].fontSize = 27;
            historyOptionTexts[3].fontSize = 27;
        }
        else if (maxtextlenght <= 250 && maxtextlenght > 200)
        {
            print("Font Set 25");
            historyOptionTexts[0].fontSize = 25;
            historyOptionTexts[1].fontSize = 25;
            historyOptionTexts[2].fontSize = 25;
            historyOptionTexts[3].fontSize = 25;
        }
        else if (maxtextlenght > 250)
        {
            print("Font Set 22");
            historyOptionTexts[0].fontSize = 22;
            historyOptionTexts[1].fontSize = 22;
            historyOptionTexts[2].fontSize = 22;
            historyOptionTexts[3].fontSize = 22;
        }

        switch (GData.selectedLanguage)
        {
            case 0:
                explainText.text = MCQsData.Question_Explanation[historyQuizIndex];
                break;

            case 1:
                explainText.text = MCQsData_Italian.Question_Explanation[historyQuizIndex];
                break;
            case 2:
                explainText.text = GreekMCQData.Question_Explanation[historyQuizIndex];
                break;
            case 3:
                explainText.text = polishMCQData.Question_Explanation[historyQuizIndex];
                break;
        }

        //setting style
        // SetTextStyle(historyOptionTexts[0], historyOptionTexts[1], historyOptionTexts[2], historyOptionTexts[3]);

        if (historyAns[historyQuizIndex] == 0)
        {
            historyFinalAnswer = histOp1[historyQuizIndex].answer;
            HighlightIndex = 0;
        }
        else if (historyAns[historyQuizIndex] == 1)
        {
            historyFinalAnswer = histOp2[historyQuizIndex].answer;
            HighlightIndex = 1;
        }
        else if (historyAns[historyQuizIndex] == 2)
        {
            historyFinalAnswer = histOp3[historyQuizIndex].answer;
            HighlightIndex = 2;
        }
        else if (historyAns[historyQuizIndex] == 3)
        {
            historyFinalAnswer = histOp4[historyQuizIndex].answer;
            HighlightIndex = 3;
        }

        Debug.Log(historyFinalAnswer);
    }

    private void SetHistoryOptionData()
    {

        for (int i = 0; i < 16; i++)
        {
            historyQues = new string[16];
            historyQues[i] = "";

            historyAns = new int[16];
            historyAns[i] = 0;
        }



        for (int i = 0; i < histOp1.Length; i++)
        {
            histOp1[i] = new Option();
        }
        for (int i = 0; i < histOp2.Length; i++)
        {
            histOp2[i] = new Option();
        }
        for (int i = 0; i < histOp3.Length; i++)
        {
            histOp3[i] = new Option();
        }
        for (int i = 0; i < histOp4.Length; i++)
        {
            histOp4[i] = new Option();
        }


        switch (GData.selectedLanguage)
        {
            case 0:
                for (int i = 0; i < 16; i++)
                {
                    historyQues[i] = MCQsData.questions[i];
                    historyAns[i] = MCQsData.answersIndex[i];
                    //Debug.Log("Question" + historyQues[i].ToString());
                    histOp1[i].answer = MCQsData.Op1[i];
                    histOp2[i].answer = MCQsData.Op2[i];
                    histOp3[i].answer = MCQsData.Op3[i];
                    histOp4[i].answer = MCQsData.Op4[i];

                    //   explainText.text = MCQsData.Question_Explanation[i];
                }
                break;

            case 1:
                for (int i = 0; i < 16; i++)
                {
                    historyQues[i] = MCQsData_Italian.questions[i];
                    historyAns[i] = MCQsData_Italian.answersIndex[i];
                    //Debug.Log("Question" + historyQues[i].ToString());
                    histOp1[i].answer = MCQsData_Italian.Op1[i];
                    histOp2[i].answer = MCQsData_Italian.Op2[i];
                    histOp3[i].answer = MCQsData_Italian.Op3[i];
                    histOp4[i].answer = MCQsData_Italian.Op4[i];

                    //   explainText.text = MCQsData.Question_Explanation[i];
                }
                break;
            case 2:
                for (int i = 0; i < 16; i++)
                {
                    historyQues[i] = GreekMCQData.questions[i];
                    historyAns[i] = GreekMCQData.answersIndex[i];
                    //Debug.Log("Question" + historyQues[i].ToString());
                    histOp1[i].answer = GreekMCQData.Op1[i];
                    histOp2[i].answer = GreekMCQData.Op2[i];
                    histOp3[i].answer = GreekMCQData.Op3[i];
                    histOp4[i].answer = GreekMCQData.Op4[i];

                    //   explainText.text = MCQsData.Question_Explanation[i];
                }
                break;
            case 3:
                for (int i = 0; i < 16; i++)
                {
                    historyQues[i] = polishMCQData.questions[i];
                    historyAns[i] = polishMCQData.answersIndex[i];
                    //Debug.Log("Question" + historyQues[i].ToString());
                    histOp1[i].answer = polishMCQData.Op1[i];
                    histOp2[i].answer = polishMCQData.Op2[i];
                    histOp3[i].answer = polishMCQData.Op3[i];
                    histOp4[i].answer = polishMCQData.Op4[i];

                    //   explainText.text = MCQsData.Question_Explanation[i];
                }
                break;
        }
    }

    #endregion

    #region Geography Quiz Data

    public void SetGeographyQuizData(int index)
    {
        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[0]));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[1]));

        TickButton3.onClick.RemoveAllListeners();
        TickButton3.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[2]));

        TickButton4.onClick.RemoveAllListeners();
        TickButton4.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[3]));

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel());

        //  TickButton3.gameObject.SetActive(false);

        selectedCategory = index;
        SetGeographyOptionData();

        int temp = geographyQuizIndex;

        //geographyQuizIndex = Random.Range(0, geographyQues.Length);

        //if (temp == geographyQuizIndex)
        //{
        //    geographyQuizIndex = Random.Range(0, geographyQues.Length);
        //}

        switch (GData.selectedLanguage)
        {
            case 0:
                geographyQuizIndex = GData.ukData.completedGeo;
                break;
            case 1:
                geographyQuizIndex = GData.ukData.completedGeoItalian;
                break;
            case 2:
                geographyQuizIndex = GData.ukData.completedGeoGreek;
                break;
            case 3:
                geographyQuizIndex = GData.ukData.completedGeoPolish;
                break;
        }

        Debug.Log("Quiz index: " + geographyQuizIndex);

        geographyQuestonText.text = geographyQues[geographyQuizIndex];

        QLength = geographyQuestonText.text.Length;
        Debug.Log("Question Lenght is==" + QLength.ToString());
        if (QLength > 400)
        {
            questiontextobj.SetActive(false);
            Scrolquestion.SetActive(true);
            ScrolQtext.text = geographyQues[geographyQuizIndex];
        }
        else
        {
            questiontextobj.SetActive(true);
            Scrolquestion.SetActive(false);
            geographyQuestonText.text = geographyQues[geographyQuizIndex];
        }

        geographyOptionTexts[0].text = geogOp1[geographyQuizIndex].answer;
        geographyOptionTexts[1].text = geogOp2[geographyQuizIndex].answer;
        geographyOptionTexts[2].text = geogOp3[geographyQuizIndex].answer;
        geographyOptionTexts[3].text = geogOp4[geographyQuizIndex].answer;

        opt1lenght = geographyOptionTexts[0].text.Length;
        opt2lenght = geographyOptionTexts[1].text.Length;
        opt3lenght = geographyOptionTexts[2].text.Length;
        opt4lenght = geographyOptionTexts[3].text.Length;
        Debug.Log("lenght of op1==" + opt1lenght.ToString());
        Debug.Log("lenght of op2==" + opt2lenght.ToString());
        Debug.Log("lenght of op3==" + opt3lenght.ToString());
        Debug.Log("lenght of op4==" + opt4lenght.ToString());

        maxtextlenght = Mathf.Max(opt1lenght, opt2lenght, opt3lenght, opt4lenght);
        Debug.Log("maximum lenght is" + maxtextlenght);
        if (maxtextlenght <= 20)
        {
            print("Font Set 40");
            historyOptionTexts[0].fontSize = 40;
            historyOptionTexts[1].fontSize = 40;
            historyOptionTexts[2].fontSize = 40;
            historyOptionTexts[3].fontSize = 40;
        }
        else if (maxtextlenght <= 100 && maxtextlenght > 20)
        {
            print("Font Set 35");
            historyOptionTexts[0].fontSize = 35;
            historyOptionTexts[1].fontSize = 35;
            historyOptionTexts[2].fontSize = 35;
            historyOptionTexts[3].fontSize = 35;
        }
        else if (maxtextlenght <= 150 && maxtextlenght > 100)
        {
            print("Font Set 33");
            historyOptionTexts[0].fontSize = 33;
            historyOptionTexts[1].fontSize = 33;
            historyOptionTexts[2].fontSize = 33;
            historyOptionTexts[3].fontSize = 33;
        }
        else if (maxtextlenght <= 200 && maxtextlenght > 150)
        {
            print("Font Set 27");
            historyOptionTexts[0].fontSize = 27;
            historyOptionTexts[1].fontSize = 27;
            historyOptionTexts[2].fontSize = 27;
            historyOptionTexts[3].fontSize = 27;
        }
        else if (maxtextlenght <= 250 && maxtextlenght > 200)
        {
            print("Font Set 25");
            historyOptionTexts[0].fontSize = 25;
            historyOptionTexts[1].fontSize = 25;
            historyOptionTexts[2].fontSize = 25;
            historyOptionTexts[3].fontSize = 25;
        }
        else if (maxtextlenght > 250)
        {
            print("Font Set 22");
            historyOptionTexts[0].fontSize = 22;
            historyOptionTexts[1].fontSize = 22;
            historyOptionTexts[2].fontSize = 22;
            historyOptionTexts[3].fontSize = 22;
        }
        switch (GData.selectedLanguage)
        {
            case 0:
                explainText.text = MCQsData.Question_Explanation[geographyQuizIndex + 16];
                break;

            case 1:
                explainText.text = MCQsData_Italian.Question_Explanation[geographyQuizIndex + 16];
                break;
            case 2:
                explainText.text = GreekMCQData.Question_Explanation[geographyQuizIndex + 16];
                break;
            case 3:
                explainText.text = polishMCQData.Question_Explanation[geographyQuizIndex + 16];
                break;
        }

        //setting style
        // SetTextStyle(geographyOptionTexts[0], geographyOptionTexts[1], geographyOptionTexts[2], geographyOptionTexts[3]);


        if (geographyAns[geographyQuizIndex] == 0)
        {
            HighlightIndex = 0;
            geographyFinalAnswer = geogOp1[geographyQuizIndex].answer;
        }
        else if (geographyAns[geographyQuizIndex] == 1)
        {
            HighlightIndex = 1;
            geographyFinalAnswer = geogOp2[geographyQuizIndex].answer;
        }
        else if (geographyAns[geographyQuizIndex] == 2)
        {
            HighlightIndex = 2;
            geographyFinalAnswer = geogOp3[geographyQuizIndex].answer;
        }
        else if (geographyAns[geographyQuizIndex] == 3)
        {
            HighlightIndex = 3;
            geographyFinalAnswer = geogOp4[geographyQuizIndex].answer;
        }

        Debug.Log(geographyFinalAnswer);
    }

    private void SetGeographyOptionData()
    {
        for (int i = 0; i < 16; i++)
        {
            geographyQues = new string[16];
            geographyQues[i] = "";

            geographyAns = new int[16];
            geographyAns[i] = 0;
        }


        for (int i = 0; i < geogOp1.Length; i++)
        {
            geogOp1[i] = new Option();
        }
        for (int i = 0; i < geogOp2.Length; i++)
        {
            geogOp2[i] = new Option();
        }
        for (int i = 0; i < geogOp3.Length; i++)
        {
            geogOp3[i] = new Option();
        }
        for (int i = 0; i < geogOp4.Length; i++)
        {
            geogOp4[i] = new Option();
        }



        switch (GData.selectedLanguage)
        {
            case 0:
                int index = 0;
                for (int i = 16; i < 32; i++)
                {
                    geographyQues[index] = MCQsData.questions[i];
                    geographyAns[index] = MCQsData.answersIndex[i];

                    geogOp1[index].answer = MCQsData.Op1[i];
                    geogOp2[index].answer = MCQsData.Op2[i];
                    geogOp3[index].answer = MCQsData.Op3[i];
                    geogOp4[index].answer = MCQsData.Op4[i];
                    index++;
                    //explainText.text = MCQsData.Question_Explanation[i+8];

                }
                break;

            case 1:
                int index1 = 0;
                for (int i = 16; i < 32; i++)
                {
                    geographyQues[index1] = MCQsData_Italian.questions[i];
                    geographyAns[index1] = MCQsData_Italian.answersIndex[i];

                    geogOp1[index1].answer = MCQsData_Italian.Op1[i];
                    geogOp2[index1].answer = MCQsData_Italian.Op2[i];
                    geogOp3[index1].answer = MCQsData_Italian.Op3[i];
                    geogOp4[index1].answer = MCQsData_Italian.Op4[i];
                    index1++;
                    //            explainText.text = MCQsData.Question_Explanation[i+8];

                }
                break;
            case 2:
                int index3 = 0;
                for (int i = 16; i < 32; i++)
                {
                    geographyQues[index3] = GreekMCQData.questions[i];
                    geographyAns[index3] = GreekMCQData.answersIndex[i];

                    geogOp1[index3].answer = GreekMCQData.Op1[i];
                    geogOp2[index3].answer = GreekMCQData.Op2[i];
                    geogOp3[index3].answer = GreekMCQData.Op3[i];
                    geogOp4[index3].answer = GreekMCQData.Op4[i];
                    index3++;
                    //            explainText.text = MCQsData.Question_Explanation[i+8];

                }
                break;
            case 3:
                int index2 = 0;
                for (int i = 16; i < 32; i++)
                {
                    geographyQues[index2] = polishMCQData.questions[i];
                    geographyAns[index2] = polishMCQData.answersIndex[i];

                    geogOp1[index2].answer = polishMCQData.Op1[i];
                    geogOp2[index2].answer = polishMCQData.Op2[i];
                    geogOp3[index2].answer = polishMCQData.Op3[i];
                    geogOp4[index2].answer = polishMCQData.Op4[i];
                    index2++;
                    //            explainText.text = MCQsData.Question_Explanation[i+8];

                }
                break;
        }

    }

    #endregion

    #region Food Quiz Data

    //public void SetFoodQuizData(int index)
    //{
    //    //onclicks added or removed
    //    TickButton1.onClick.RemoveAllListeners();
    //    TickButton1.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[0]));

    //    TickButton2.onClick.RemoveAllListeners();
    //    TickButton2.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[1]));

    //    TickButton3.onClick.RemoveAllListeners();
    //    TickButton3.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[2]));

    //    TickButton4.onClick.RemoveAllListeners();
    //    TickButton4.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[3]));

    //    ResetButton.onClick.RemoveAllListeners();
    //    ResetButton.onClick.AddListener(() => ResetQuestionaPanel());

    //    //        TickButton3.gameObject.SetActive(false);

    //    selectedCategory = index;
    //    SetFoodOptionData();

    //    int temp = foodQuizIndex;

    //    foodQuizIndex = Random.Range(0, foodQues.Length);

    //    if (temp == foodQuizIndex)
    //    {
    //        foodQuizIndex = Random.Range(0, foodQues.Length);
    //    }

    //    Debug.Log("Quiz index: " + foodQuizIndex);

    //    foodQuestonText.text = foodQues[foodQuizIndex];

    //    foodOptionTexts[0].text = foodOp1[foodQuizIndex].answer;
    //    foodOptionTexts[1].text = foodOp2[foodQuizIndex].answer;
    //    foodOptionTexts[2].text = foodOp3[foodQuizIndex].answer;
    //    foodOptionTexts[3].text = foodOp4[foodQuizIndex].answer;


    //    switch (GData.selectedLanguage)
    //    {
    //        case 0:
    //            explainText.text = MCQsData.Question_Explanation[foodQuizIndex];
    //            break;

    //        case 1:
    //            explainText.text = MCQsData_Italian.Question_Explanation[foodQuizIndex];
    //            break;
    //    }

    //    //setting style
    //    SetTextStyle(foodOptionTexts[0], foodOptionTexts[1], foodOptionTexts[2], foodOptionTexts[3]);


    //    if (foodAns[foodQuizIndex] == 0)
    //    {
    //        foodFinalAnswer = foodOp1[foodQuizIndex].answer;
    //    }
    //    else if (foodAns[foodQuizIndex] == 1)
    //    {
    //        foodFinalAnswer = foodOp2[foodQuizIndex].answer;
    //    }
    //    else if (foodAns[foodQuizIndex] == 2)
    //    {
    //        foodFinalAnswer = foodOp3[foodQuizIndex].answer;
    //    }
    //    else if (foodAns[foodQuizIndex] == 3)
    //    {
    //        foodFinalAnswer = foodOp4[foodQuizIndex].answer;
    //    }

    //    Debug.Log(foodFinalAnswer);
    //}



    //private void SetFoodOptionData()
    //{
    //    for (int i = 0; i < 8; i++)
    //    {
    //        foodQues = new string[MCQsData.questions.Length];
    //        foodQues[i] = "";

    //        foodAns = new int[MCQsData.questions.Length];
    //        foodAns[i] = 0;
    //    }


    //    for (int i = 0; i < foodOp1.Length; i++)
    //    {
    //        foodOp1[i] = new Option();
    //    }
    //    for (int i = 0; i < foodOp2.Length; i++)
    //    {
    //        foodOp2[i] = new Option();
    //    }
    //    for (int i = 0; i < foodOp3.Length; i++)
    //    {
    //        foodOp3[i] = new Option();
    //    }
    //    for (int i = 0; i < foodOp4.Length; i++)
    //    {
    //        foodOp4[i] = new Option();
    //    }

    //    switch (GData.selectedLanguage)
    //    {
    //        case 0:

    //            for (int i = 0; i < MCQsData.questions.Length; i++)
    //            {
    //                foodQues[i] = MCQsData.questions[i];
    //                foodAns[i] = MCQsData.answersIndex[i];

    //                foodOp1[i].answer = MCQsData.Op1[i];
    //                foodOp2[i].answer = MCQsData.Op2[i];
    //                foodOp3[i].answer = MCQsData.Op3[i];
    //                foodOp4[i].answer = MCQsData.Op4[i];

    //                //     explainText.text = MCQsData.Question_Explanation[i+16];

    //            }
    //            break;

    //        case 1:

    //            for (int i = 0; i < MCQsData.questions.Length; i++)
    //            {
    //                foodQues[i] = MCQsData_Italian.questions[i];
    //                foodAns[i] = MCQsData_Italian.answersIndex[i];

    //                foodOp1[i].answer = MCQsData_Italian.Op1[i];
    //                foodOp2[i].answer = MCQsData_Italian.Op2[i];
    //                foodOp3[i].answer = MCQsData_Italian.Op3[i];
    //                foodOp4[i].answer = MCQsData_Italian.Op4[i];

    //                //     explainText.text = MCQsData.Question_Explanation[i+16];

    //            }
    //            break;
    //    }
    //}




    #endregion

    #region Culture Quiz Data

    //public void SetCultureQuizData(int index)
    //{
    //    //onclicks added or removed
    //    TickButton1.onClick.RemoveAllListeners();
    //    TickButton1.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[0]));

    //    TickButton2.onClick.RemoveAllListeners();
    //    TickButton2.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[1]));

    //    TickButton3.onClick.RemoveAllListeners();
    //    TickButton3.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[2]));

    //    TickButton4.onClick.RemoveAllListeners();
    //    TickButton4.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[3]));

    //    ResetButton.onClick.RemoveAllListeners();
    //    ResetButton.onClick.AddListener(() => ResetQuestionaPanel());

    //    //   TickButton3.gameObject.SetActive(false);

    //    selectedCategory = index;
    //    SetCultureOptionData();
    //    int temp = cultureQuizIndex;

    //    cultureQuizIndex = Random.Range(0, cultureQues.Length);

    //    if (temp == cultureQuizIndex)
    //    {
    //        cultureQuizIndex = Random.Range(0, cultureQues.Length);
    //    }

    //    Debug.Log("Quiz index: " + cultureQuizIndex);

    //    cultureQuestonText.text = cultureQues[cultureQuizIndex];

    //    cultureOptionTexts[0].text = culOp1[cultureQuizIndex].answer;
    //    cultureOptionTexts[1].text = culOp2[cultureQuizIndex].answer;
    //    cultureOptionTexts[2].text = culOp3[cultureQuizIndex].answer;
    //    cultureOptionTexts[3].text = culOp4[cultureQuizIndex].answer;

    //    // explainText.text = MCQsData.Question_Explanation[cultureQuizIndex + 24];
    //    switch (GData.selectedLanguage)
    //    {
    //        case 0:
    //            explainText.text = MCQsData.Question_Explanation[cultureQuizIndex];
    //            break;

    //        case 1:
    //            explainText.text = MCQsData_Italian.Question_Explanation[cultureQuizIndex];
    //            break;
    //    }

    //    //setting style
    //    SetTextStyle(cultureOptionTexts[0], cultureOptionTexts[1], cultureOptionTexts[2], cultureOptionTexts[3]);



    //    if (cultureAns[cultureQuizIndex] == 0)
    //    {
    //        cultureFinalAnswer = culOp1[cultureQuizIndex].answer;
    //    }
    //    else if (cultureAns[cultureQuizIndex] == 1)
    //    {
    //        cultureFinalAnswer = culOp2[cultureQuizIndex].answer;
    //    }
    //    else if (cultureAns[cultureQuizIndex] == 2)
    //    {
    //        cultureFinalAnswer = culOp3[cultureQuizIndex].answer;
    //    }
    //    else if (cultureAns[cultureQuizIndex] == 3)
    //    {
    //        cultureFinalAnswer = culOp4[cultureQuizIndex].answer;
    //    }


    //    Debug.Log(cultureFinalAnswer);
    //}


    //private void SetCultureOptionData()
    //{
    //    for (int i = 0; i < 8; i++)
    //    {
    //        cultureQues = new string[MCQsData.questions.Length];
    //        cultureQues[i] = "";

    //        cultureAns = new int[MCQsData.questions.Length];
    //        cultureAns[i] = 0;
    //    }


    //    for (int i = 0; i < culOp1.Length; i++)
    //    {
    //        culOp1[i] = new Option();
    //    }
    //    for (int i = 0; i < culOp2.Length; i++)
    //    {
    //        culOp2[i] = new Option();
    //    }
    //    for (int i = 0; i < culOp3.Length; i++)
    //    {
    //        culOp3[i] = new Option();
    //    }
    //    for (int i = 0; i < culOp4.Length; i++)
    //    {
    //        culOp4[i] = new Option();
    //    }


    //    switch (GData.selectedLanguage)
    //    {
    //        case 0:

    //            for (int i = 0; i < MCQsData.questions.Length; i++)
    //            {
    //                cultureQues[i] = MCQsData.questions[i];
    //                cultureAns[i] = MCQsData.answersIndex[i];

    //                culOp1[i].answer = MCQsData.Op1[i];
    //                culOp2[i].answer = MCQsData.Op2[i];
    //                culOp3[i].answer = MCQsData.Op3[i];
    //                culOp4[i].answer = MCQsData.Op4[i];

    //                //    explainText.text = MCQsData.Question_Explanation[i+24];


    //            }
    //            break;

    //        case 1:

    //            for (int i = 0; i < MCQsData.questions.Length; i++)
    //            {
    //                cultureQues[i] = MCQsData_Italian.questions[i];
    //                cultureAns[i] = MCQsData_Italian.answersIndex[i];

    //                culOp1[i].answer = MCQsData_Italian.Op1[i];
    //                culOp2[i].answer = MCQsData_Italian.Op2[i];
    //                culOp3[i].answer = MCQsData_Italian.Op3[i];
    //                culOp4[i].answer = MCQsData_Italian.Op4[i];

    //                //    explainText.text = MCQsData.Question_Explanation[i+24];


    //            }
    //            break;
    //    }
    //}

    #endregion



    #region Common Functions


    public class Option
    {
        public string answer;
        public string tag;
    }

    

    public void ResetQuestionaPanel()
    {

        explanationPanel.SetActive(false);

        if (PlayerPrefs.GetInt("levelcurrent") == 1)
        {
            if (selectedCategory == 1)
            {
                switch (GData.selectedLanguage)
                {
                    case 0:
                        if (GData.ukData.completedHist < MCQsData.questions.Length)
                        {
                            SetHistoryQuizData(1);
                            levelFailPanel.SetActive(false);
                            quizPanel.SetActive(true);
                        }
                        else
                        {
                            levelFailPanel.SetActive(false);
                            cameraobj.SetActive(false);
                            Background.SetActive(false);
                            Debug.Log("Came here5");
                            controller.SetActive(true);
                            countDown.timeRemaining = 900f;
                            countDown.timerIsRunning = true;
                            PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                            PlayerPrefs.Save();
                        }

                        break;
                    case 1:
                        if (GData.ukData.completedHistItalian < MCQsData_Italian.questions.Length)
                        {
                            SetHistoryQuizData(1);
                            levelFailPanel.SetActive(false);
                            quizPanel.SetActive(true);
                        }
                        else
                        {
                            levelFailPanel.SetActive(false);
                            cameraobj.SetActive(false);
                            Background.SetActive(false);
                            Debug.Log("Came here5");
                            controller.SetActive(true);
                            countDown.timeRemaining = 900f;
                            countDown.timerIsRunning = true;
                            PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                            PlayerPrefs.Save();
                        }
                        break;
                    case 2:
                        if (GData.ukData.completedHistGreek < GreekMCQData.questions.Length)
                        {
                            SetHistoryQuizData(1);
                            levelFailPanel.SetActive(false);
                            quizPanel.SetActive(true);
                        }
                        else
                        {
                            levelFailPanel.SetActive(false);
                            cameraobj.SetActive(false);
                            Background.SetActive(false);
                            Debug.Log("Came here5");
                            controller.SetActive(true);
                            countDown.timeRemaining = 900f;
                            countDown.timerIsRunning = true;
                            PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                            PlayerPrefs.Save();
                        }
                        break;
                    case 3:
                        if (GData.ukData.completedHistpolish < polishMCQData.questions.Length)
                        {
                            SetHistoryQuizData(1);
                            levelFailPanel.SetActive(false);
                            quizPanel.SetActive(true);
                        }
                        else
                        {
                            levelFailPanel.SetActive(false);
                            cameraobj.SetActive(false);
                            Background.SetActive(false);
                            Debug.Log("Came here5");
                            controller.SetActive(true);
                            countDown.timeRemaining = 900f;
                            countDown.timerIsRunning = true;
                            PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                            PlayerPrefs.Save();
                        }
                        break;
                }

            }
            else if (selectedCategory == 2)
            {
                switch (GData.selectedLanguage)
                {
                    case 0:
                        if (GData.ukData.completedGeo < MCQsData.questions.Length)
                        {
                            SetGeographyQuizData(2);
                            levelFailPanel.SetActive(false);
                            quizPanel.SetActive(true);
                        }
                        else
                        {
                            levelFailPanel.SetActive(false);
                            cameraobj.SetActive(false);
                            Background.SetActive(false);
                            Debug.Log("Came here5");
                            controller.SetActive(true);
                            countDown.timeRemaining = 900f;
                            countDown.timerIsRunning = true;
                            PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                            PlayerPrefs.Save();
                        }

                        break;
                    case 1:
                        if (GData.ukData.completedGeoItalian < MCQsData_Italian.questions.Length)
                        {
                            SetGeographyQuizData(2);
                            levelFailPanel.SetActive(false);
                            quizPanel.SetActive(true);
                        }
                        else
                        {
                            levelFailPanel.SetActive(false);
                            cameraobj.SetActive(false);
                            Background.SetActive(false);
                            Debug.Log("Came here5");
                            controller.SetActive(true);
                            countDown.timeRemaining = 900f;
                            countDown.timerIsRunning = true;
                            PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                            PlayerPrefs.Save();
                        }
                        break;

                    case 2:
                        if (GData.ukData.completedGeoGreek < GreekMCQData.questions.Length)
                        {
                            SetGeographyQuizData(2);
                            levelFailPanel.SetActive(false);
                            quizPanel.SetActive(true);
                        }
                        else
                        {
                            levelFailPanel.SetActive(false);
                            cameraobj.SetActive(false);
                            Background.SetActive(false);
                            Debug.Log("Came here5");
                            controller.SetActive(true);
                            countDown.timeRemaining = 900f;
                            countDown.timerIsRunning = true;
                            PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                            PlayerPrefs.Save();
                        }
                        break;
                    case 3:
                        if (GData.ukData.completedGeoPolish < polishMCQData.questions.Length)
                        {
                            SetGeographyQuizData(2);
                            levelFailPanel.SetActive(false);
                            quizPanel.SetActive(true);
                        }
                        else
                        {
                            levelFailPanel.SetActive(false);
                            cameraobj.SetActive(false);
                            Background.SetActive(false);
                            Debug.Log("Came here5");
                            controller.SetActive(true);
                            countDown.timeRemaining = 900f;
                            countDown.timerIsRunning = true;
                            PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                            PlayerPrefs.Save();
                        }
                        break;
                }
            }
        }
    }

    public void AnswerBtnClick(Text text)
    {
        TickButton1.interactable = false;
        TickButton2.interactable = false;
        TickButton3.interactable = false;
        TickButton4.interactable = false;
        if (PlayerPrefs.GetInt("levelcurrent") == 1)
        {
            if (selectedCategory == 1)
            {
                if (text.text.Equals(historyFinalAnswer) == true)
                {
                    int value = PlayerPrefs.GetInt("language");


                      switch (value)
                    {
                        case 0:
                            Answerdecision.text = "CorrectAnswer";
                            break;
                        case 1:
                            Answerdecision.text = "Risposta corretta";
                            break;
                        case 2:
                            Answerdecision.text = "Σωστή απάντηση";
                            break;
                        case 3:
                            Answerdecision.text = "Prawidłowa odpowiedź";
                            break;
                      }

                            // Answerdecision.text = "CorrectAnswer";
                            RightAnswerPartical.SetActive(true);

                    NextButton.GetComponent<Button>().onClick.RemoveAllListeners();
                    NextButton.GetComponent<Button>().onClick.AddListener(() => ExplainFunc(0));

                }

                else
                {
                    historyOptionTexts[HighlightIndex].color = Color.green;
                    int value = PlayerPrefs.GetInt("language");


                    switch (value)
                    {
                        case 0:
                            Answerdecision.text = "WrongAnswer";
                            break;
                        case 1:
                            Answerdecision.text = "Risposta sbagliata";
                            break;
                        case 2:
                            Answerdecision.text = "Λάθος απάντηση";
                            break;
                        case 3:
                            Answerdecision.text = "Zła odpowiedź";
                            break;
                    }

                   // Answerdecision.text = "WrongAnswer";
                    NextButton.GetComponent<Button>().onClick.RemoveAllListeners();
                    NextButton.GetComponent<Button>().onClick.AddListener(() => ExplainFunc(1));
                }
            }
            
            else if (selectedCategory == 2)
            {
                if (text.text.Equals(geographyFinalAnswer) == true)
                {
                    int value = PlayerPrefs.GetInt("language");


                    switch (value)
                    {
                        case 0:
                            Answerdecision.text = "CorrectAnswer";
                            break;
                        case 1:
                            Answerdecision.text = "Risposta corretta";
                            break;
                        case 2:
                            Answerdecision.text = "Σωστή απάντηση";
                            break;
                        case 3:
                            Answerdecision.text = "Prawidłowa odpowiedź";
                            break;
                    }
                    //Answerdecision.text = "CorrectAnswer";
                    RightAnswerPartical.SetActive(true);

                    NextButton.GetComponent<Button>().onClick.RemoveAllListeners();
                    NextButton.GetComponent<Button>().onClick.AddListener(() => ExplainFunc(0));

                }
                else
                {
                    historyOptionTexts[HighlightIndex].color = Color.green;
                    int value = PlayerPrefs.GetInt("language");


                    switch (value)
                    {
                        case 0:
                            Answerdecision.text = "WrongAnswer";
                            break;
                        case 1:
                            Answerdecision.text = "Risposta sbagliata";
                            break;
                        case 2:
                            Answerdecision.text = "Λάθος απάντηση";
                            break;
                        case 3:
                            Answerdecision.text = "Zła odpowiedź";
                            break;
                    }
                    //Answerdecision.text = "WrongAnswer";
                    NextButton.GetComponent<Button>().onClick.RemoveAllListeners();
                    NextButton.GetComponent<Button>().onClick.AddListener(() => ExplainFunc(1));
                }
            }
            
            StartCoroutine(ActiveExplanationPanal());
        }
      

    }

    IEnumerator ActiveExplanationPanal()
    {
        yield return new WaitForSeconds(0.8f);
        explanationPanel.SetActive(true);
        NextButton.SetActive(true);
        ExplainClosebutton.SetActive(true);
    }
    public void ExplainFunc(int index)
    {
        NextButton.GetComponent<Button>().onClick.RemoveAllListeners();
        explanationPanel.SetActive(false);
        LoadingPanel.SetActive(true);
        infoBtn.SetActive(false);
        TickButton1.interactable = true;
        TickButton2.interactable = true;
        TickButton3.interactable = true;
        TickButton4.interactable = true;

        if (index == 0)
        {
            historyOptionTexts[HighlightIndex].color = Color.white;
            Debug.Log("Correct culture Answer Selected");
            StartCoroutine(CorrectAnswerWait());
        }
        else if (index == 1)
        {
            historyOptionTexts[HighlightIndex].color = Color.white;
            StartCoroutine(WrongAnswerwait());
            Debug.Log("Wrong culture Answer Selected");
        }
        for(int i=0; i< historyOptionTexts.Length;i++)
        {
            historyOptionTexts[i].color = Color.white;
        }
        Invoke("DisActiveLoadingScreen", 1.25f);
    }

    public void DisActiveLoadingScreen()
    {
        LoadingPanel.SetActive(false);
    }

    IEnumerator CorrectAnswerWait()
    {
        
        GData.RightAnswer = GData.RightAnswer + 1;
        ScoreDisplayText.text = (GData.RightAnswer * 5).ToString();
        if (GameManager.Instance.isMultiplayer)
        {
            GData.Multi_Player[GameManager.Instance.SelectedPlayer].RightAnswer++;
        }
        yield return new WaitForSeconds(0.5f);
        Answerdecision.text = "";
        RightAnswerPartical.SetActive(false);
        if (selectedCategory == 1)
        {
            switch (GData.selectedLanguage)
            {
                case 0:
                    if (GData.ukData.completedHist < 16)
                    {
                        GData.ukData.score++;
                        GData.ukData.completedHist++;
                        if (GData.ukData.completedHist < 16)
                        {
                            SetHistoryQuizData(1);
                        }
                        else if (GData.ukData.completedHist == 16 && GData.ukData.score != 32)
                        {
                            //GData.ukData.completedHist = 0;
                            quizPanel.SetActive(false);
                            controller.SetActive(false);
                            quizobjecthandle();
                            Debug.Log("111");
                            ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                            Debug.Log("2222");
                            levelCompletePanel.SetActive(true);
                        }
                        else if (GData.ukData.score == 32)
                        {
                            if (GameManager.Instance.isMultiplayer)
                            {
                                if (GameManager.Instance.SelectedPlayer == 0)
                                {
                                    print("hist=0");
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    MulticongratsPanel.SetActive(true);
                                    cleanMultiplayerData();
                                    GData.ukData.completedHist = 0;
                                    GData.ukData.score = 0;
                                     GData.RightAnswer = 0;
                                }
                                else
                                {
                                    quizobjecthandle();
                                    GameUIManager.Instance.OnCompetitionComplete();
                                    GData.RightAnswer = 0;
                                }
                            }
                            else
                            {
                                Debug.Log("333");
                                if (GData.RightAnswer >= 16)
                                {
                                    Debug.Log("4444");
                                    Debug.Log("LevelCompleted");
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    congratsPanel.SetActive(true);
                                    congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                    GData.FirstLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                    Background.SetActive(true);
                                    GData.roomLockedIndex++;
                                    GData.RightAnswer = 0;
                                    GData.ukData.completedHist = 0;
                                    GData.ukData.score = 0;
                                }
                                else
                                {
                                    Debug.Log("555");
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    GData.ukData.completedHist = 0;
                                    GData.ukData.score = 0;
                                    ScoreDisplayfailPanelText.text = (GData.RightAnswer * 5).ToString();
                                    levelFailPanel.SetActive(true);
                                    GData.RightAnswer = 0;
                                }
                            }
                            
                        }
                    }

                    break;
                case 1:
                    if (GData.ukData.completedHistItalian < 16)
                    {
                        GData.ukData.scoreItalian++;
                        GData.ukData.completedHistItalian++;
                        if (GData.ukData.completedHistItalian < 16)
                        {
                            SetHistoryQuizData(1);
                        }
                        else if (GData.ukData.completedHistItalian == 16 && GData.ukData.scoreItalian != 32)
                        {
                            //GData.ukData.completedHistItalian = 0;
                            quizPanel.SetActive(false);
                            controller.SetActive(false);
                            quizobjecthandle();
                            ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                            levelCompletePanel.SetActive(true);
                        }
                        else if (GData.ukData.scoreItalian == 32)
                        {
                            if (GameManager.Instance.isMultiplayer)
                            {
                                if (GameManager.Instance.SelectedPlayer == 0)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    MulticongratsPanel.SetActive(true);
                                    cleanMultiplayerData();
                                    GData.ukData.completedHistItalian = 0;
                                    GData.ukData.scoreItalian = 0;
                                    GData.RightAnswer = 0;
                                }
                                else
                                {
                                    quizobjecthandle();
                                    GameUIManager.Instance.OnCompetitionComplete();
                                    GData.RightAnswer = 0;
                                }
                            }
                            else
                            {
                                if (GData.RightAnswer >= 16)
                                {
                                    Debug.Log("LevelCompleted");
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    congratsPanel.SetActive(true);
                                    congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                    GData.FirstLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                    Background.SetActive(true);
                                    GData.RightAnswer = 0;
                                    GData.ukData.completedHistItalian = 0;
                                    GData.roomLockedIndex++;
                                    GData.ukData.scoreItalian = 0;
                                }
                                else
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    GData.ukData.completedHistItalian = 0;
                                    GData.ukData.scoreItalian = 0;
                                    ScoreDisplayfailPanelText.text = (GData.RightAnswer * 5).ToString();
                                    levelFailPanel.SetActive(true);
                                    GData.RightAnswer = 0;
                                }
                            }

                        }
                    }
                    break;
                case 2:
                    if (GData.ukData.completedHistGreek < 16)
                    {
                        GData.ukData.scoreGreek++;
                        GData.ukData.completedHistGreek++;
                        if (GData.ukData.completedHistGreek < 16)
                        {
                            SetHistoryQuizData(1);
                        }
                        else if (GData.ukData.completedHistGreek == 16 && GData.ukData.scoreGreek != 32)
                        {
                            quizPanel.SetActive(false);
                            controller.SetActive(false);
                            quizobjecthandle();
                            ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                            levelCompletePanel.SetActive(true);
                        }
                        else if (GData.ukData.scoreGreek == 32)
                        {
                            if (GameManager.Instance.isMultiplayer)
                            {
                                if (GameManager.Instance.SelectedPlayer == 0)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    MulticongratsPanel.SetActive(true);
                                    cleanMultiplayerData();
                                    GData.ukData.completedHistGreek = 0;
                                    GData.ukData.scoreGreek = 0;
                                    GData.RightAnswer = 0;
                                }
                                else
                                {
                                    quizobjecthandle();
                                    GameUIManager.Instance.OnCompetitionComplete();
                                    GData.RightAnswer = 0;
                                }
                            }
                            else
                            {
                                if (GData.RightAnswer >= 16)
                                {
                                    Debug.Log("LevelCompleted");
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    congratsPanel.SetActive(true);
                                    congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                    GData.FirstLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                    Background.SetActive(true);
                                    GData.RightAnswer = 0;
                                    GData.ukData.completedHistGreek = 0;
                                    GData.roomLockedIndex++;
                                    GData.ukData.scoreGreek = 0;
                                }
                                else
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    GData.ukData.completedHistGreek = 0;
                                    GData.ukData.scoreGreek = 0;
                                    ScoreDisplayfailPanelText.text = (GData.RightAnswer * 5).ToString();
                                    levelFailPanel.SetActive(true);
                                    GData.RightAnswer = 0;
                                }
                            }

                        }
                    }
                    break;
                case 3:
                    if (GData.ukData.completedHistpolish < 16)
                    {
                        GData.ukData.scorepolish++;
                        GData.ukData.completedHistpolish++;
                        if (GData.ukData.completedHistpolish < 16)
                        {
                            SetHistoryQuizData(1);
                        }
                        else if (GData.ukData.completedHistpolish == 16 && GData.ukData.scorepolish != 32)
                        {
                            //GData.ukData.completedHistItalian = 0;
                            quizPanel.SetActive(false);
                            controller.SetActive(false);
                            quizobjecthandle();
                            ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                            levelCompletePanel.SetActive(true);
                        }
                        else if (GData.ukData.scorepolish == 32)
                        {
                            if (GameManager.Instance.isMultiplayer)
                            {
                                if (GameManager.Instance.SelectedPlayer == 0)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    MulticongratsPanel.SetActive(true);
                                    cleanMultiplayerData();
                                    GData.ukData.completedHistpolish = 0;
                                    GData.ukData.scorepolish = 0;
                                    GData.RightAnswer = 0;
                                }
                                else
                                {
                                    quizobjecthandle();
                                    GameUIManager.Instance.OnCompetitionComplete();
                                    GData.RightAnswer = 0;
                                }
                            }
                            else
                            {
                                if (GData.RightAnswer >= 16)
                                {
                                    Debug.Log("LevelCompleted");
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    congratsPanel.SetActive(true);
                                    congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                    GData.FirstLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                    Background.SetActive(true);
                                    GData.RightAnswer = 0;
                                    GData.ukData.completedHistpolish = 0;
                                    GData.roomLockedIndex++;
                                    GData.ukData.scorepolish = 0;
                                }
                                else
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    GData.ukData.completedHistpolish = 0;
                                    GData.ukData.scorepolish = 0;
                                    ScoreDisplayfailPanelText.text = (GData.RightAnswer * 5).ToString();
                                    levelFailPanel.SetActive(true);
                                    GData.RightAnswer = 0;
                                }
                            }

                        }
                    }
                    break;
            }
        }
        else if (selectedCategory == 2)
        {
            
            switch (GData.selectedLanguage)
            {
                case 0:
                    if (GData.ukData.completedGeo < 16)
                    {
                        ScoreDisplayText.text = (GData.RightAnswer * 5).ToString();
                        GData.ukData.score++;
                        GData.ukData.completedGeo++;
                        if (GData.ukData.completedGeo < 16)
                        {
                            SetGeographyQuizData(2);
                        }
                        else if (GData.ukData.completedGeo == 16 && GData.ukData.score != 32)
                        {
                            GameManagers.instance.FakeNewsQuestionBtn[0].interactable = false;
                            GameManagers.instance.FakeNewsQuestionBtn[0].transform.GetChild(1).gameObject.SetActive(true);
                            //GData.ukData.completedGeo = 0;
                            quizPanel.SetActive(false);
                            controller.SetActive(false);
                            quizobjecthandle();
                            ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                            levelCompletePanel.SetActive(true);

                        }
                        else if (GData.ukData.score == 32)
                        {
                            if (GameManager.Instance.isMultiplayer)
                            {
                                if (GameManager.Instance.SelectedPlayer == 0)
                                {
                                    print("hist=0");
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    MulticongratsPanel.SetActive(true);
                                    cleanMultiplayerData();
                                    GData.ukData.completedGeo = 0;
                                    GData.ukData.score = 0;
                                    GData.ukData.completedHist = 0;
                                    GData.RightAnswer = 0;
                                }
                                else
                                {
                                    quizobjecthandle();
                                    GameUIManager.Instance.OnCompetitionComplete();
                                    GData.RightAnswer = 0;
                                }
                            }
                            else
                            {
                                if (GData.RightAnswer >= 16)
                                {
                                    Debug.Log("LevelCompleted");
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    congratsPanel.SetActive(true);
                                    congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                    GData.FirstLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                    Background.SetActive(true);
                                    GData.roomLockedIndex++;
                                    GData.RightAnswer = 0;
                                    GData.ukData.completedGeo = 0;
                                    GData.ukData.score = 0;
                                }
                                else
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    GData.ukData.completedHist = 0;
                                    GData.ukData.completedGeo = 0;
                                    GData.ukData.score = 0;
                                    GData.ukData.completedGeoItalian = 0;
                                    GData.ukData.scoreItalian = 0;
                                    ScoreDisplayfailPanelText.text = (GData.RightAnswer * 5).ToString();
                                    levelFailPanel.SetActive(true);
                                    GData.RightAnswer = 0;
                                }
                            }
                        }
                    }

                    break;
                case 1:
                    if (GData.ukData.completedGeoItalian < 16)
                    {
                        GData.ukData.scoreItalian++;
                        GData.ukData.completedGeoItalian++;
                        if (GData.ukData.completedGeoItalian < 16)
                        {
                            SetGeographyQuizData(2);
                        }
                        else if (GData.ukData.completedGeoItalian == 16 && GData.ukData.scoreItalian != 32)
                        {
                            GameManagers.instance.FakeNewsQuestionBtn[0].interactable = false;
                            GameManagers.instance.FakeNewsQuestionBtn[0].transform.GetChild(1).gameObject.SetActive(true);
                            // GData.ukData.completedGeoItalian = 0;
                            quizPanel.SetActive(false);
                            controller.SetActive(false);
                            quizobjecthandle();
                            ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                            levelCompletePanel.SetActive(true);
                        }
                        else if (GData.ukData.scoreItalian == 32)
                        {
                            if (GameManager.Instance.isMultiplayer)
                            {
                                if (GameManager.Instance.SelectedPlayer == 0)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    MulticongratsPanel.SetActive(true);
                                    cleanMultiplayerData();
                                    GData.ukData.scoreItalian = 0;
                                    GData.ukData.completedGeoItalian = 0;
                                    GData.RightAnswer = 0;
                                }
                                else
                                {
                                    quizobjecthandle();
                                    GameUIManager.Instance.OnCompetitionComplete();
                                    GData.RightAnswer = 0;
                                }
                            }
                            else
                            {

                                if (GData.RightAnswer >= 16)
                                {

                                    Debug.Log("LevelCompleted");
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    congratsPanel.SetActive(true);
                                    congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                    GData.FirstLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                    Background.SetActive(true);
                                    GData.ukData.completedGeoItalian = 0;
                                    GData.roomLockedIndex++;
                                    GData.RightAnswer = 0;
                                    GData.ukData.scoreItalian = 0;
                                }
                                else
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    GData.ukData.completedHist = 0;
                                    GData.ukData.completedGeo = 0;
                                    GData.ukData.score = 0;
                                    GData.ukData.completedGeoItalian = 0;
                                    GData.ukData.scoreItalian = 0;
                                    ScoreDisplayfailPanelText.text = (GData.RightAnswer * 5).ToString();
                                    levelFailPanel.SetActive(true);
                                    GData.RightAnswer = 0;
                                }
                            }
                        }
                    }
                    break;
                case 2:
                    if (GData.ukData.completedGeoGreek < 16)
                    {
                        GData.ukData.scoreGreek++;
                        GData.ukData.completedGeoGreek++;
                        if (GData.ukData.completedGeoGreek < 16)
                        {
                            SetGeographyQuizData(2);
                        }
                        else if (GData.ukData.completedGeoGreek == 16 && GData.ukData.scoreGreek != 32)
                        {
                            GameManagers.instance.FakeNewsQuestionBtn[0].interactable = false;
                            GameManagers.instance.FakeNewsQuestionBtn[0].transform.GetChild(1).gameObject.SetActive(true);
                            // GData.ukData.completedGeoItalian = 0;
                            quizPanel.SetActive(false);
                            controller.SetActive(false);
                            quizobjecthandle();
                            ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                            levelCompletePanel.SetActive(true);
                        }
                        else if (GData.ukData.scoreGreek == 32)
                        {
                            if (GameManager.Instance.isMultiplayer)
                            {
                                if (GameManager.Instance.SelectedPlayer == 0)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    MulticongratsPanel.SetActive(true);
                                    cleanMultiplayerData();
                                    GData.ukData.scoreGreek = 0;
                                    GData.ukData.completedGeoGreek = 0;
                                    GData.RightAnswer = 0;
                                }
                                else
                                {
                                    quizobjecthandle();
                                    GameUIManager.Instance.OnCompetitionComplete();
                                    GData.RightAnswer = 0;
                                }
                            }
                            else
                            {

                                if (GData.RightAnswer >= 16)
                                {

                                    Debug.Log("LevelCompleted");
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    congratsPanel.SetActive(true);
                                    congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                    GData.FirstLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                    Background.SetActive(true);
                                    GData.ukData.completedGeoGreek = 0;
                                    GData.roomLockedIndex++;
                                    GData.RightAnswer = 0;
                                    GData.ukData.scoreGreek = 0;
                                }
                                else
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    GData.ukData.completedHist = 0;
                                    GData.ukData.completedGeo = 0;
                                    GData.ukData.score = 0;
                                    GData.ukData.completedGeoGreek = 0;
                                    GData.ukData.scoreGreek = 0;
                                    ScoreDisplayfailPanelText.text = (GData.RightAnswer * 5).ToString();
                                    levelFailPanel.SetActive(true);
                                    GData.RightAnswer = 0;
                                }
                            }
                        }
                    }
                    break;
                case 3:
                    if (GData.ukData.completedGeoPolish < 16)
                    {
                        GData.ukData.scorepolish++;
                        GData.ukData.completedGeoPolish++;
                        if (GData.ukData.completedGeoPolish < 16)
                        {
                            SetGeographyQuizData(2);
                        }
                        else if (GData.ukData.completedGeoPolish == 16 && GData.ukData.scorepolish != 32)
                        {
                            GameManagers.instance.FakeNewsQuestionBtn[0].interactable = false;
                            GameManagers.instance.FakeNewsQuestionBtn[0].transform.GetChild(1).gameObject.SetActive(true);
                            // GData.ukData.completedGeoItalian = 0;
                            quizPanel.SetActive(false);
                            controller.SetActive(false);
                            quizobjecthandle();
                            ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                            levelCompletePanel.SetActive(true);
                        }
                        else if (GData.ukData.scorepolish == 32)
                        {
                            if (GameManager.Instance.isMultiplayer)
                            {
                                if (GameManager.Instance.SelectedPlayer == 0)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    MulticongratsPanel.SetActive(true);
                                    cleanMultiplayerData();
                                    GData.ukData.scorepolish = 0;
                                    GData.ukData.completedGeoPolish = 0;
                                    GData.RightAnswer = 0;
                                }
                                else
                                {
                                    quizobjecthandle();
                                    GameUIManager.Instance.OnCompetitionComplete();
                                    GData.RightAnswer = 0;
                                }
                            }
                            else
                            {

                                if (GData.RightAnswer >= 16)
                                {

                                    Debug.Log("LevelCompleted");
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    congratsPanel.SetActive(true);
                                    congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                    GData.FirstLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                    Background.SetActive(true);
                                    GData.ukData.completedGeoPolish = 0;
                                    GData.roomLockedIndex++;
                                    GData.RightAnswer = 0;
                                    GData.ukData.scorepolish = 0;
                                }
                                else
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    GData.ukData.completedHist = 0;
                                    GData.ukData.completedGeo = 0;
                                    GData.ukData.score = 0;
                                    GData.ukData.completedGeoPolish = 0;
                                    GData.ukData.scorepolish = 0;
                                    ScoreDisplayfailPanelText.text = (GData.RightAnswer * 5).ToString();
                                    levelFailPanel.SetActive(true);
                                    GData.RightAnswer = 0;
                                }
                            }
                        }
                    }
                    break;
            }
        }

    }

    IEnumerator WrongAnswerwait()
    {

        yield return new WaitForSeconds(1f);
        if (GameManager.Instance.isMultiplayer)
        {
            GData.Multi_Player[GameManager.Instance.SelectedPlayer].WrongAnswer++;
        }
        Answerdecision.text = "";
        if (selectedCategory <= 5)
        {
            if (selectedCategory == 1)
            {
                switch (GData.selectedLanguage)
                {
                    case 0:
                        if (GData.ukData.completedHist < 16)
                        {
                            GData.ukData.score++;
                            GData.ukData.completedHist++;
                            if (GData.ukData.completedHist < 16)
                            {
                                SetHistoryQuizData(1);
                            }
                            else if (GData.ukData.completedHist == 16 && GData.ukData.score != 32)
                            {
                                GameManagers.instance.FakeNewsQuestionBtn[0].interactable = false;
                                GameManagers.instance.FakeNewsQuestionBtn[0].transform.GetChild(1).gameObject.SetActive(true);
                                //GData.ukData.completedHist = 0;
                                quizPanel.SetActive(false);
                                controller.SetActive(false);
                                quizobjecthandle();
                                ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                                levelCompletePanel.SetActive(true);
                            }
                            else if (GData.ukData.score == 32)
                            {
                                if (GameManager.Instance.isMultiplayer)
                                {
                                    if (GameManager.Instance.SelectedPlayer == 0)
                                    {
                                        print("hist=0");
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        MulticongratsPanel.SetActive(true);
                                        cleanMultiplayerData();
                                        GData.ukData.completedHist = 0;
                                        GData.ukData.score = 0;
                                        GData.RightAnswer = 0;
                                    }
                                    else
                                    {
                                        GameUIManager.Instance.OnCompetitionComplete();
                                        quizobjecthandle();
                                        GData.RightAnswer = 0;
                                    }
                                }
                                else
                                {
                                    if (GData.RightAnswer >= 16)
                                    {

                                        Debug.Log("LevelCompleted");
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        congratsPanel.SetActive(true);
                                        congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                        GData.FirstLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                        Background.SetActive(true);
                                        GData.roomLockedIndex++;
                                        GData.RightAnswer = 0;
                                        GData.ukData.completedHist = 0;
                                        GData.ukData.score = 0;
                                    }
                                    else
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        GData.ukData.completedHist = 0;
                                        GData.ukData.score = 0;
                                        GData.ukData.completedHistItalian = 0;
                                        GData.ukData.scoreItalian = 0;
                                        ScoreDisplayfailPanelText.text = (GData.RightAnswer * 5).ToString();

                                        levelFailPanel.SetActive(true);
                                        GData.RightAnswer = 0;
                                    }
                                }
                            }
                        }

                        break;

                    case 1:
                        if (GData.ukData.completedHistItalian < 16)
                        {
                            GData.ukData.scoreItalian++;
                            GData.ukData.completedHistItalian++;
                            if (GData.ukData.completedHistItalian < 16)
                            {
                                SetHistoryQuizData(1);
                            }
                            else if (GData.ukData.completedHistItalian == 16 && GData.ukData.scoreItalian != 32)
                            {
                               // GData.ukData.completedHistItalian = 0;
                                quizPanel.SetActive(false);
                                controller.SetActive(false);
                                quizobjecthandle();
                                ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                                levelCompletePanel.SetActive(true);
                            }
                            else if (GData.ukData.scoreItalian == 32)
                            {
                                if (GameManager.Instance.isMultiplayer)
                                {
                                    if (GameManager.Instance.SelectedPlayer == 0)
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        MulticongratsPanel.SetActive(true);
                                        cleanMultiplayerData();
                                        GData.ukData.completedHistItalian = 0;
                                        GData.ukData.scoreItalian = 0;
                                        GData.RightAnswer = 0;
                                    }
                                    else
                                    {
                                        GameUIManager.Instance.OnCompetitionComplete();
                                        quizobjecthandle();
                                        GData.RightAnswer = 0;
                                    }
                                }
                                else
                                {
                                    if (GData.RightAnswer >= 16)
                                    {
                                        Debug.Log("LevelCompleted");
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        congratsPanel.SetActive(true);
                                        congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                        GData.FirstLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                        Background.SetActive(true);
                                        GData.ukData.completedHistItalian = 0;
                                        GData.roomLockedIndex++;
                                        GData.RightAnswer = 0;
                                        GData.ukData.scoreItalian = 0;
                                    }
                                    else

                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();

                                        GData.ukData.completedHist = 0;
                                        GData.ukData.score = 0;
                                        GData.ukData.completedHistItalian = 0;
                                        GData.ukData.scoreItalian = 0;
                                        ScoreDisplayfailPanelText.text = (GData.RightAnswer * 5).ToString();
                                        levelFailPanel.SetActive(true);
                                        GData.RightAnswer = 0;
                                    }
                                }
                            }
                        }
                        break;
                    case 2:
                        if (GData.ukData.completedHistGreek < 16)
                        {
                            GData.ukData.scoreGreek++;
                            GData.ukData.completedHistGreek++;
                            if (GData.ukData.completedHistGreek < 16)
                            {
                                SetHistoryQuizData(1);
                            }
                            else if (GData.ukData.completedHistGreek == 16 && GData.ukData.scoreGreek != 32)
                            {
                                // GData.ukData.completedHistItalian = 0;
                                quizPanel.SetActive(false);
                                controller.SetActive(false);
                                quizobjecthandle();
                                ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                                levelCompletePanel.SetActive(true);
                            }
                            else if (GData.ukData.scoreGreek == 32)
                            {
                                if (GameManager.Instance.isMultiplayer)
                                {
                                    if (GameManager.Instance.SelectedPlayer == 0)
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        MulticongratsPanel.SetActive(true);
                                        cleanMultiplayerData();
                                        GData.ukData.completedHistGreek = 0;
                                        GData.ukData.scoreGreek = 0;
                                        GData.RightAnswer = 0;
                                    }
                                    else
                                    {
                                        GameUIManager.Instance.OnCompetitionComplete();
                                        quizobjecthandle();
                                        GData.RightAnswer = 0;
                                    }
                                }
                                else
                                {
                                    if (GData.RightAnswer >= 16)
                                    {
                                        Debug.Log("LevelCompleted");
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        congratsPanel.SetActive(true);
                                        congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                        GData.FirstLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                        Background.SetActive(true);
                                        GData.ukData.completedHistGreek = 0;
                                        GData.roomLockedIndex++;
                                        GData.RightAnswer = 0;
                                        GData.ukData.scoreGreek = 0;
                                    }
                                    else

                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();

                                        GData.ukData.completedHist = 0;
                                        GData.ukData.score = 0;
                                        GData.ukData.completedHistGreek = 0;
                                        GData.ukData.scoreGreek = 0;
                                        ScoreDisplayfailPanelText.text = (GData.RightAnswer * 5).ToString();
                                        levelFailPanel.SetActive(true);
                                        GData.RightAnswer = 0;
                                    }
                                }
                            }
                        }
                        break;
                    case 3:
                        if (GData.ukData.completedHistpolish < 16)
                        {
                            GData.ukData.scorepolish++;
                            GData.ukData.completedHistpolish++;
                            if (GData.ukData.completedHistpolish < 16)
                            {
                                SetHistoryQuizData(1);
                            }
                            else if (GData.ukData.completedHistpolish == 16 && GData.ukData.scorepolish != 32)
                            {
                                // GData.ukData.completedHistItalian = 0;
                                quizPanel.SetActive(false);
                                controller.SetActive(false);
                                quizobjecthandle();
                                ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                                levelCompletePanel.SetActive(true);
                            }
                            else if (GData.ukData.scorepolish == 32)
                            {
                                if (GameManager.Instance.isMultiplayer)
                                {
                                    if (GameManager.Instance.SelectedPlayer == 0)
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        MulticongratsPanel.SetActive(true);
                                        cleanMultiplayerData();
                                        GData.ukData.completedHistpolish = 0;
                                        GData.ukData.scorepolish = 0;
                                        GData.RightAnswer = 0;
                                    }
                                    else
                                    {
                                        GameUIManager.Instance.OnCompetitionComplete();
                                        quizobjecthandle();
                                        GData.RightAnswer = 0;
                                    }
                                }
                                else
                                {
                                    if (GData.RightAnswer >= 16)
                                    {
                                        Debug.Log("LevelCompleted");
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        congratsPanel.SetActive(true);
                                        congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                        GData.FirstLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                        Background.SetActive(true);
                                        GData.ukData.completedHistpolish = 0;
                                        GData.roomLockedIndex++;
                                        GData.RightAnswer = 0;
                                        GData.ukData.scorepolish = 0;
                                    }
                                    else

                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();

                                        GData.ukData.completedHist = 0;
                                        GData.ukData.score = 0;
                                        GData.ukData.completedHistpolish = 0;
                                        GData.ukData.scorepolish = 0;
                                        ScoreDisplayfailPanelText.text = (GData.RightAnswer * 5).ToString();
                                        levelFailPanel.SetActive(true);
                                        GData.RightAnswer = 0;
                                    }
                                }
                            }
                        }
                        break;
                }
            }
            else if (selectedCategory == 2)
            {
                switch (GData.selectedLanguage)
                {
                    case 0:
                        if (GData.ukData.completedGeo < 16)
                        {
                            GData.ukData.score++;
                            GData.ukData.completedGeo++;
                            if (GData.ukData.completedGeo < 16)
                            {
                                SetGeographyQuizData(2);
                            }
                            else if (GData.ukData.completedGeo == 16 && GData.ukData.score != 32)
                            {
                                GameManagers.instance.FakeNewsQuestionBtn[0].interactable = false;
                                GameManagers.instance.FakeNewsQuestionBtn[0].transform.GetChild(1).gameObject.SetActive(true);
                                // GData.ukData.completedGeo = 0;
                                quizPanel.SetActive(false);
                                controller.SetActive(false);
                                quizobjecthandle();
                                ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                                levelCompletePanel.SetActive(true);

                            }
                            else if (GData.ukData.score == 32)
                            {
                                if (GameManager.Instance.isMultiplayer)
                                {
                                    if (GameManager.Instance.SelectedPlayer == 0)
                                    {
                                        print("hist=0");
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        MulticongratsPanel.SetActive(true);
                                        cleanMultiplayerData();
                                        GData.ukData.completedGeo = 0;
                                        GData.ukData.score = 0;
                                        GData.RightAnswer = 0;
                                    }
                                    else
                                    {
                                        GameUIManager.Instance.OnCompetitionComplete();
                                        quizobjecthandle();
                                        GData.RightAnswer = 0;
                                    }
                                }
                                else 
                                { 

                                if (GData.RightAnswer >= 16)
                                {
                                    Debug.Log("LevelCompleted");
                                    quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        congratsPanel.SetActive(true);
                                        congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                        GData.FirstLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                        Background.SetActive(true);
                                    GData.roomLockedIndex++;
                                    GData.RightAnswer = 0;
                                    GData.ukData.completedGeo = 0;
                                    GData.ukData.score = 0;
                                }
                                else
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    GData.ukData.completedHist = 0;
                                    GData.ukData.completedGeo = 0;
                                    GData.ukData.score = 0;
                                    GData.ukData.completedGeoItalian = 0;
                                    GData.ukData.scoreItalian = 0;
                                    ScoreDisplayfailPanelText.text = (GData.RightAnswer * 5).ToString();
                                    levelFailPanel.SetActive(true);
                                    GData.RightAnswer = 0;
                                }
                                }
                            }
                        }

                        break;

                    case 1:
                        if (GData.ukData.completedGeoItalian < 16)
                        {
                            GData.ukData.scoreItalian++;
                            GData.ukData.completedGeoItalian++;
                            if (GData.ukData.completedGeoItalian < 16)
                            {
                                SetGeographyQuizData(2);
                            }
                            else if (GData.ukData.completedGeoItalian == 16 && GData.ukData.scoreItalian != 32)
                            {
                                GData.ukData.completedGeoItalian = 0;
                                quizPanel.SetActive(false);
                                quizobjecthandle();
                                controller.SetActive(false);
                                ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                                levelCompletePanel.SetActive(true);
                            }
                            else if (GData.ukData.scoreItalian == 32)
                            {
                                if (GameManager.Instance.isMultiplayer)
                                {
                                    if (GameManager.Instance.SelectedPlayer == 0)
                                    {
                                        print("hist=0");
                                        quizPanel.SetActive(false);
                                        MulticongratsPanel.SetActive(true);
                                        cleanMultiplayerData();
                                        GData.ukData.completedGeoItalian = 0;
                                        GData.ukData.scoreItalian = 0;
                                        GData.RightAnswer = 0;
                                    }
                                    else
                                    {
                                        GameUIManager.Instance.OnCompetitionComplete();
                                        quizobjecthandle();
                                        GData.RightAnswer = 0;
                                    }
                                }
                                else
                                {

                                    if (GData.RightAnswer >= 16)
                                    {

                                        Debug.Log("LevelCompleted");
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        congratsPanel.SetActive(true);
                                        congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                        GData.FirstLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                        Background.SetActive(true);
                                        GData.ukData.completedGeoItalian = 0;
                                        GData.roomLockedIndex++;
                                        GData.RightAnswer = 0;
                                        GData.ukData.scoreItalian = 0;
                                    }
                                    else
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        GData.ukData.completedGeo = 0;
                                        GData.ukData.score = 0;
                                        GData.ukData.completedGeoItalian = 0;
                                        GData.ukData.scoreItalian = 0;
                                        ScoreDisplayfailPanelText.text = (GData.RightAnswer * 5).ToString();
                                        levelFailPanel.SetActive(true);
                                        GData.RightAnswer = 0;
                                    }
                                }
                            }
                        }
                        break;
                    case 2:
                        if (GData.ukData.completedGeoGreek < 16)
                        {
                            GData.ukData.scoreGreek++;
                            GData.ukData.completedGeoGreek++;
                            if (GData.ukData.completedGeoGreek < 16)
                            {
                                SetGeographyQuizData(2);
                            }
                            else if (GData.ukData.completedGeoGreek == 16 && GData.ukData.scoreGreek != 32)
                            {
                                GData.ukData.completedGeoGreek = 0;
                                quizPanel.SetActive(false);
                                quizobjecthandle();
                                controller.SetActive(false);
                                ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                                levelCompletePanel.SetActive(true);
                            }
                            else if (GData.ukData.scoreGreek == 32)
                            {
                                if (GameManager.Instance.isMultiplayer)
                                {
                                    if (GameManager.Instance.SelectedPlayer == 0)
                                    {
                                        quizPanel.SetActive(false);
                                        MulticongratsPanel.SetActive(true);
                                        cleanMultiplayerData();
                                        GData.ukData.completedGeoGreek = 0;
                                        GData.ukData.scoreGreek = 0;
                                        GData.RightAnswer = 0;
                                    }
                                    else
                                    {
                                        GameUIManager.Instance.OnCompetitionComplete();
                                        quizobjecthandle();
                                        GData.RightAnswer = 0;
                                    }
                                }
                                else
                                {

                                    if (GData.RightAnswer >= 16)
                                    {

                                        Debug.Log("LevelCompleted");
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        congratsPanel.SetActive(true);
                                        congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                        GData.FirstLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                        GData.ukData.completedGeoGreek = 0;
                                        GData.roomLockedIndex++;
                                        GData.RightAnswer = 0;
                                        GData.ukData.scoreGreek = 0;
                                    }
                                    else
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        GData.ukData.completedGeo = 0;
                                        GData.ukData.score = 0;
                                        GData.ukData.completedGeoGreek = 0;
                                        GData.ukData.scoreGreek = 0;
                                        ScoreDisplayfailPanelText.text = (GData.RightAnswer * 5).ToString();
                                        levelFailPanel.SetActive(true);
                                        GData.RightAnswer = 0;
                                    }
                                }
                            }
                        }
                        break;
                    case 3:
                        if (GData.ukData.completedGeoPolish < 16)
                        {
                            GData.ukData.scorepolish++;
                            GData.ukData.completedGeoPolish++;
                            if (GData.ukData.completedGeoPolish < 16)
                            {
                                SetGeographyQuizData(2);
                            }
                            else if (GData.ukData.completedGeoPolish == 16 && GData.ukData.scorepolish != 32)
                            {
                                GData.ukData.completedGeoPolish = 0;
                                quizPanel.SetActive(false);
                                quizobjecthandle();
                                controller.SetActive(false);
                                ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                                levelCompletePanel.SetActive(true);
                            }
                            else if (GData.ukData.scorepolish == 32)
                            {
                                if (GameManager.Instance.isMultiplayer)
                                {
                                    if (GameManager.Instance.SelectedPlayer == 0)
                                    {
                                        quizPanel.SetActive(false);
                                        MulticongratsPanel.SetActive(true);
                                        cleanMultiplayerData();
                                        GData.ukData.completedGeoPolish = 0;
                                        GData.ukData.scorepolish = 0;
                                        GData.RightAnswer = 0;
                                    }
                                    else
                                    {
                                        GameUIManager.Instance.OnCompetitionComplete();
                                        quizobjecthandle();
                                        GData.RightAnswer = 0;
                                    }
                                }
                                else
                                {

                                    if (GData.RightAnswer >= 16)
                                    {

                                        Debug.Log("LevelCompleted");
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        congratsPanel.SetActive(true);
                                        congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                        GData.FirstLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                        GData.ukData.completedGeoPolish = 0;
                                        GData.roomLockedIndex++;
                                        GData.RightAnswer = 0;
                                        GData.ukData.scorepolish = 0;
                                    }
                                    else
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        GData.ukData.completedGeo = 0;
                                        GData.ukData.score = 0;
                                        GData.ukData.completedGeoPolish = 0;
                                        GData.ukData.scorepolish = 0;
                                        ScoreDisplayfailPanelText.text = (GData.RightAnswer * 5).ToString();
                                        levelFailPanel.SetActive(true);
                                        GData.RightAnswer = 0;
                                    }
                                }
                            }
                        }
                        break;
                }
            }
        }
    }

    public void cleanMultiplayerData()
    {
        GData.ukData.completedHist = 0;
        GData.ukData.completedHistItalian = 0;
        GData.ukData.completedHistpolish = 0;
        GData.ukData.completedHistGreek = 0;
    }
    
    public void quizobjecthandle()
    {
        QuizCamera.SetActive(false);
       // QuizCanvas.SetActive(false);
        mainCavas.SetActive(true);
    }

    public void BackToMenu()
    {
        //fader.SetActive(true);
        //FadeAnimation obj = fader.GetComponent<FadeAnimation>();
        //obj.FadeInAnim();
        //StartCoroutine(LoadScene(1));


        ////        SceneManager.LoadSceneAsync(0);
        //MainMenuManager.backFromGame = true;
    }
    #endregion

}
