using EasyMobile;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BelgiumManager : MonoBehaviour
{


    public CountDown countDown;
    public GameObject explanationPanel;
    public Text explainText;
    public GameObject NextButton;
    public GameObject ExplainClosebutton;

    public GameObject scrollImages;
    public List<GameObject> quizImages;
    public GameObject infoBtn;
    public GameObject closeScrollBtn;

    // public TrueFalseData TFData;
    public MCQData MCQSData;
    public MCQData MCQSData_Italian;
    public MCQData MCQSData_Greek;
    public MCQData MCQSData_Polish;

    public GameData GData;
    /// <summary>
    /// Fake News Quizes Data
    /// </summary>
    /// 

    //public string[] TFQuestions;
    //public int[] TFAns;
    private const string TF_KEY = "TF";
    private const string MCQS_KEY = "MCQS";

    public Button TickButton1;
    public Button TickButton2;
    public Button TickButton3;
    public Button TickButton4;

    public Button ResetButton;

    public Text Answerdecision;
    /// <summary>
    /// History Quiz Data
    /// </summary>
    /// 

    public string[] historyQues;
    public int[] historyAns;
    public FindIndex[] HistoryAnsMcqs = new FindIndex[7];
    public static string historyFinalAnswer;
    public static int historyQuizIndex;

    private Option[] histOp1 = new Option[28];
    private Option[] histOp2 = new Option[28];
    private Option[] histOp3 = new Option[28];
    private Option[] histOp4 = new Option[28];



    public Text historyQuestonText;
    public Text[] historyOptionTexts;
    public TextMeshProUGUI historyScoreText;
    public GameObject historyCompleteImage;

    /// <summary>
    /// Geography Quiz Data
    /// </summary>
    /// 
    public int[] geographyAns;
    public FindIndex[] geographyAnsMcqs = new FindIndex[7];
    public string[] geographyQues;
    public static string geographyFinalAnswer;
    public static int geographyQuizIndex;

    private Option[] geogOp1 = new Option[7];
    private Option[] geogOp2 = new Option[7];
    private Option[] geogOp3 = new Option[7];
    private Option[] geogOp4 = new Option[7];



    public Text geographyQuestonText;
    public Text[] geographyOptionTexts;
    public TextMeshProUGUI geographyScoreText;
    public GameObject geographyCompleteImage;


    /// <summary>
    /// Food Quiz Data
    /// </summary>
    /// 
    public int[] foodAns;
    public FindIndex[] foodAnsMcqs = new FindIndex[7];
    public string[] foodQues;
    public static string foodFinalAnswer;
    public static int foodQuizIndex;

    private Option[] foodOp1 = new Option[7];
    private Option[] foodOp2 = new Option[7];
    private Option[] foodOp3 = new Option[7];
    private Option[] foodOp4 = new Option[7];


    public Text foodQuestonText;
    public Text[] foodOptionTexts;
    public TextMeshProUGUI foodScoreText;
    public GameObject foodCompleteImage;

    /// <summary>
    /// Culture Quiz Data
    /// </summary>
    /// 
    public int[] cultureAns;
    public FindIndex[] cultureAnsMcqs = new FindIndex[7];
    public string[] cultureQues;
    public static string cultureFinalAnswer;
    public static int cultureQuizIndex;

    private Option[] culOp1 = new Option[7];
    private Option[] culOp2 = new Option[7];
    private Option[] culOp3 = new Option[7];
    private Option[] culOp4 = new Option[7];


    public Text cultureQuestonText;
    public Text[] cultureOptionTexts;
    public TextMeshProUGUI cultureScoreText;
    public GameObject cultureCompleteImage;

    ///// <summary>
    ///// Language Quiz Data
    ///// </summary>
    ///// 
    //public string[] languageQues;
    //public static string languageFinalAnswer;
    //public static int languageyQuizIndex;

    //private Option[] langOp1 = new Option[5];
    //private Option[] langOp2 = new Option[5];
    //private Option[] langOp3 = new Option[5];
    //private Option[] langOp4 = new Option[5];

    //public Text languageQuestonText;
    //public Text[] languageOptionTexts;
    //public TextMeshProUGUI languageScoreText;
    //public GameObject languageCompleteImage;


    /// <summary>
    /// General Variables
    /// </summary>
    /// 
    enum answer { wrong, correct };
    public static int selectedCategory = 0;
    public GameObject quizPanel;
    public GameObject levelCompletePanel;
    [SerializeField] GameObject Background;
    public GameObject levelFailPanel;
    public GameObject cameraobj;

    public GameObject congratsPanel;
    public Text congratsPanelScore;
    public GameObject playerController;

    public BoxCollider door2Col;
    public GameObject controller;

    public LoadManager loadingManager;
    // public Button RemoveTextStyle;


    //public Button quizHist;
    //public Button quizGeo;
    //public Button quizFood;
    //public Button quizCult;
    //public Button quizLang;
    private int HighlightIndex;
    public Text ScoreDisplayPanelText;
    public Text ScoreDisplayText;
    public GameObject MulticongratsPanel;
    public GameObject QuizCamera;
    public GameObject QuizCanvas;
    public GameObject mainCavas;
    public GameObject RightAnswerPartical;
    public GameObject LoadingPanel;
    public GameObject PlayerNamePanel;
    public Text PlayerName_Text;

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
        PlayerPrefs.SetString("SelectedManager", "BL");
        if (GameManager.Instance.isMultiplayer)
        {
            PlayerNamePanel.SetActive(true);
            PlayerName_Text.text = GData.Multi_Player[GameManager.Instance.SelectedPlayer].PlayerName;
        }
        // RemoveTextStyle.onClick.RemoveAllListeners();
        // RemoveTextStyle.onClick.AddListener(RemoveTextStyleFunc);
    }

    void Update()
    {
        switch (GData.selectedLanguage)
        {
            case 0:
                historyScoreText.text = GData.belgiumData.completedHist + "/" + MCQSData.questions.Length;
                geographyScoreText.text = GData.belgiumData.completedHist + "/" + MCQSData.questions.Length;
                cultureScoreText.text = GData.belgiumData.completedHist + "/" + MCQSData.questions.Length;
                foodScoreText.text = GData.belgiumData.completedHist + "/" + MCQSData.questions.Length;
                
                break;
            case 1:
                historyScoreText.text = GData.belgiumData.completedHistItalian + "/" + MCQSData_Italian.questions.Length;
                geographyScoreText.text = GData.belgiumData.completedHistItalian + "/" + MCQSData_Italian.questions.Length;
                cultureScoreText.text = GData.belgiumData.completedHistItalian + "/" + MCQSData_Italian.questions.Length;
                foodScoreText.text = GData.belgiumData.completedHistItalian + "/" + MCQSData_Italian.questions.Length;
                break;
            case 2:
                historyScoreText.text = GData.belgiumData.completedGeoGreek + "/" + MCQSData_Greek.questions.Length;
                geographyScoreText.text = GData.belgiumData.completedGeoGreek + "/" + MCQSData_Greek.questions.Length;
                cultureScoreText.text = GData.belgiumData.completedGeoGreek + "/" + MCQSData_Greek.questions.Length;
                foodScoreText.text = GData.belgiumData.completedGeoGreek + "/" + MCQSData_Greek.questions.Length;
                break;
            case 3:
                historyScoreText.text = GData.belgiumData.completedGeoPolish + "/" + MCQSData_Polish.questions.Length;
                geographyScoreText.text = GData.belgiumData.completedGeoPolish + "/" + MCQSData_Polish.questions.Length;
                cultureScoreText.text = GData.belgiumData.completedGeoPolish + "/" + MCQSData_Polish.questions.Length;
                foodScoreText.text = GData.belgiumData.completedGeoPolish + "/" + MCQSData_Polish.questions.Length;
                break;
        }

        //historyScoreText.text = PlayerPrefs.GetInt("BelgiumHist") + "/3";
        //geographyScoreText.text = PlayerPrefs.GetInt("BelgiumGeo") + "/3";
        //foodScoreText.text = PlayerPrefs.GetInt("BelgiumFood") + "/3";
        //cultureScoreText.text = PlayerPrefs.GetInt("BelgiumCult") + "/3";
        //   languageScoreText.text = PlayerPrefs.GetInt("BelgiumLang") + "/3";



        //if (PlayerPrefs.GetInt("BelgiumHist") >= 3)
        //{
        //    //quizHist.interactable = false;

        //    historyCompleteImage.SetActive(true);
        //}
        //if (PlayerPrefs.GetInt("BelgiumGeo") >= 3)
        //{
        //    //quizGeo.interactable = false;

        //    geographyCompleteImage.SetActive(true);
        //}
        //if (PlayerPrefs.GetInt("BelgiumFood") >= 3)
        //{
        //    //quizFood.interactable = false;
        //    foodCompleteImage.SetActive(true);
        //}
        //if (PlayerPrefs.GetInt("BelgiumCult") >= 3)
        //{
        //    //quizCult.interactable = false;
        //    cultureCompleteImage.SetActive(true);
        //}

        if (PlayerPrefs.GetInt("Level2") >= 4)
        {
            PlayerPrefs.SetInt("levelunlocked", 0);
            door2Col.isTrigger = true;
            congratsPanel.SetActive(true);
            playerController.SetActive(false);

            GameManagers.score = PlayerPrefs.GetInt("Score") + 12;


            PlayerPrefs.SetInt("Score", GameManagers.score);
            PlayerPrefs.Save();

            // Report a score of 100
            // EM_GameServicesConstants.Sample_Leaderboard is the generated name constant
            // of a leaderboard named "Sample Leaderboard"
            //    GameServices.ReportScore(PlayerPrefs.GetInt("Score"), EM_GameServicesConstants.Leaderboard_Escape_Hero);

            countDown.timeRemaining = 900f;
            countDown.timerIsRunning = true;
            PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
            PlayerPrefs.Save();


            PlayerPrefs.SetInt("Level2", 0);
            PlayerPrefs.SetInt("LevelM2", 1);
            PlayerPrefs.Save();

        }
        if (PlayerPrefs.GetInt("LevelM2") == 1)
        {
            //    door2Col.isTrigger = true;

        }

    }


    #region History Quiz Data

    //****************** True False *************// 
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


        selectedCategory = index;
        SetHistoryOptionData();
        //int temp = historyQuizIndex;

        switch (GData.selectedLanguage)
        {
            case 0:
                historyQuizIndex = GData.belgiumData.completedHist;
                break;
            case 1:
                historyQuizIndex = GData.belgiumData.completedHistItalian;
                break;
            case 2:
                historyQuizIndex = GData.belgiumData.completedHistGreek;
                break;
            case 3:
                historyQuizIndex = GData.belgiumData.completedHistpolish;
                break;
        }

        //if (temp == historyQuizIndex)
        //{
        //    historyQuizIndex = Random.Range(0, historyQues.Length);
        //}

        Debug.Log("Quiz index: " + historyQuizIndex);
        if (historyQuizIndex == 11)
        {
            EnableImage(11, 0);
        }
           

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
                explainText.text = MCQSData.Question_Explanation[historyQuizIndex];
                break;

            case 1:
                explainText.text = MCQSData_Italian.Question_Explanation[historyQuizIndex];
                break;
            case 2:
                explainText.text = MCQSData_Greek.Question_Explanation[historyQuizIndex];
                break;
            case 3:
                explainText.text = MCQSData_Polish.Question_Explanation[historyQuizIndex];
                break;
        }

        //setting style
        // SetTextStyle(historyOptionTexts[0], historyOptionTexts[1], historyOptionTexts[2], historyOptionTexts[3]);

        if (historyAns[historyQuizIndex] == 0)
        {
            HighlightIndex = 0;
            historyFinalAnswer = histOp1[historyQuizIndex].answer;
        }
        else if (historyAns[historyQuizIndex] == 1)
        {
            HighlightIndex = 1;
            historyFinalAnswer = histOp2[historyQuizIndex].answer;
        }
        else if (historyAns[historyQuizIndex] == 2)
        {
            HighlightIndex = 2;
            historyFinalAnswer = histOp3[historyQuizIndex].answer;
        }
        else if (historyAns[historyQuizIndex] == 3)
        {
            HighlightIndex = 3;
            historyFinalAnswer = histOp4[historyQuizIndex].answer;
        }


        Debug.Log(historyFinalAnswer);
    }
    private void EnableImage(int quizIndex,int imageIndex)
    {
        if (quizIndex == 11)
        {
            infoBtn.GetComponent<Button>().onClick.RemoveAllListeners();
            infoBtn.GetComponent<Button>().onClick.AddListener(() => infoBtnClick(imageIndex));
            infoBtn.SetActive(true);
        }
    }
    private void SetHistoryOptionData()
    {

        for (int i = 0; i < MCQSData.questions.Length; i++)
        {
            historyQues = new string[MCQSData.questions.Length];
            historyQues[i] = "";

            historyAns = new int[MCQSData.questions.Length];
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
                for (int i = 0; i < MCQSData.questions.Length; i++)
                {
                    historyQues[i] = MCQSData.questions[i];
                    historyAns[i] = MCQSData.answersIndex[i];

                    histOp1[i].answer = MCQSData.Op1[i];
                    histOp2[i].answer = MCQSData.Op2[i];
                    histOp3[i].answer = MCQSData.Op3[i];
                    histOp4[i].answer = MCQSData.Op4[i];
                }
                break;

            case 1:
                for (int i = 0; i < MCQSData_Italian.questions.Length; i++)
                {
                    historyQues[i] = MCQSData_Italian.questions[i];
                    historyAns[i] = MCQSData_Italian.answersIndex[i];

                    histOp1[i].answer = MCQSData_Italian.Op1[i];
                    histOp2[i].answer = MCQSData_Italian.Op2[i];
                    histOp3[i].answer = MCQSData_Italian.Op3[i];
                    histOp4[i].answer = MCQSData_Italian.Op4[i];
                }
                break;
            case 2:
                for (int i = 0; i < MCQSData_Greek.questions.Length; i++)
                {
                    historyQues[i] = MCQSData_Greek.questions[i];
                    historyAns[i] = MCQSData_Greek.answersIndex[i];

                    histOp1[i].answer = MCQSData_Greek.Op1[i];
                    histOp2[i].answer = MCQSData_Greek.Op2[i];
                    histOp3[i].answer = MCQSData_Greek.Op3[i];
                    histOp4[i].answer = MCQSData_Greek.Op4[i];
                }
                break;
            case 3:
                for (int i = 0; i < MCQSData_Polish.questions.Length; i++)
                {
                    historyQues[i] = MCQSData_Polish.questions[i];
                    historyAns[i] = MCQSData_Polish.answersIndex[i];

                    histOp1[i].answer = MCQSData_Polish.Op1[i];
                    histOp2[i].answer = MCQSData_Polish.Op2[i];
                    histOp3[i].answer = MCQSData_Polish.Op3[i];
                    histOp4[i].answer = MCQSData_Polish.Op4[i];
                }
                break;
        }
    }

    //****************** Mcqs *************// 
    public void SetHistoryQuizDataMCQS(int index)
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

        TickButton3.gameObject.SetActive(true);

        selectedCategory = index;
        SetHistoryOptionDataMCQS();
        int temp = historyQuizIndex;

        historyQuizIndex = Random.Range(0, historyQues.Length);

        if (temp == historyQuizIndex)
        {
            historyQuizIndex = Random.Range(0, historyQues.Length);
        }

        Debug.Log(historyQuizIndex);

        historyQuestonText.text = historyQues[historyQuizIndex];


        switch (GData.selectedLanguage)
        {
            case 0:
                explainText.text = MCQSData.Question_Explanation[historyQuizIndex];
                break;

            case 1:
                explainText.text = MCQSData_Italian.Question_Explanation[historyQuizIndex];
                break;
            case 2:
                explainText.text = MCQSData_Greek.Question_Explanation[historyQuizIndex];
                break;
            case 3:
                explainText.text = MCQSData_Polish.Question_Explanation[historyQuizIndex];
                break;
        }

        historyOptionTexts[0].text = histOp1[historyQuizIndex].answer;
        historyOptionTexts[1].text = histOp2[historyQuizIndex].answer;
        historyOptionTexts[2].text = histOp3[historyQuizIndex].answer;
        historyOptionTexts[3].text = histOp4[historyQuizIndex].answer;

        //Debug.Log(HistoryAnsMcqs[historyQuizIndex].Index.Length);

        for (int i = 0; i < 4; i++)
        {
            if ((HistoryAnsMcqs[historyQuizIndex].Index) == 0)
            {
                TickButton1.GetComponent<Answer>().iscorrect = true;

                Debug.Log("Correct Option: 0");
            }
            if ((HistoryAnsMcqs[historyQuizIndex].Index) == 1)
            {
                TickButton2.GetComponent<Answer>().iscorrect = true;
                Debug.Log("Correct Option: 1");

            }
            if ((HistoryAnsMcqs[historyQuizIndex].Index) == 2)
            {
                TickButton3.GetComponent<Answer>().iscorrect = true;
                Debug.Log("Correct Option: 2");

            }
            if ((HistoryAnsMcqs[historyQuizIndex].Index) == 3)
            {
                TickButton4.GetComponent<Answer>().iscorrect = true;
                Debug.Log("Correct Option: 3");

            }
        }


        //if (historyAns[historyQuizIndex] == 0)
        //{
        //    historyFinalAnswer = histOp1[historyQuizIndex].answer;
        //}
        //else if (historyAns[historyQuizIndex] == 1)
        //{
        //    historyFinalAnswer = histOp2[historyQuizIndex].answer;
        //}
        //else if (historyAns[historyQuizIndex] == 2)
        //{
        //    historyFinalAnswer = histOp3[historyQuizIndex].answer;
        //}

        Debug.Log(historyFinalAnswer);
    }

    private void SetHistoryOptionDataMCQS()
    {

        for (int i = 0; i < 7; i++)
        {
            historyQues = new string[7];
            historyQues[i] = "";

            historyAns = new int[7];
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
        for (int i = 0; i < HistoryAnsMcqs.Length; i++)
        {
            HistoryAnsMcqs[i] = new FindIndex();
        }


        switch (GData.selectedLanguage)
        {
            case 0:
                for (int i = 0; i < 7; i++)
                {
                    historyQues[i] = MCQSData.questions[i];
                    //historyAns[i] = MCQSData.answersIndex[i];
                    HistoryAnsMcqs[i].Index = MCQSData.answersIndex[i];
                    //Debug.Log(ans[0]);

                    histOp1[i].answer = MCQSData.Op1[i];
                    histOp2[i].answer = MCQSData.Op2[i];
                    histOp3[i].answer = MCQSData.Op3[i];
                    histOp4[i].answer = MCQSData.Op4[i];

                    //  explainText.text = MCQSData.Question_Explanation[i];

                }
                break;

            case 1:
                for (int i = 0; i < 7; i++)
                {
                    historyQues[i] = MCQSData_Italian.questions[i];
                    //historyAns[i] = MCQSData.answersIndex[i];
                    HistoryAnsMcqs[i].Index = MCQSData_Italian.answersIndex[i];
                    //Debug.Log(ans[0]);

                    histOp1[i].answer = MCQSData_Italian.Op1[i];
                    histOp2[i].answer = MCQSData_Italian.Op2[i];
                    histOp3[i].answer = MCQSData_Italian.Op3[i];
                    histOp4[i].answer = MCQSData_Italian.Op4[i];

                    //  explainText.text = MCQSData.Question_Explanation[i];

                }
                break;
            case 2:
                for (int i = 0; i < 7; i++)
                {
                    historyQues[i] = MCQSData_Greek.questions[i];
                    //historyAns[i] = MCQSData.answersIndex[i];
                    HistoryAnsMcqs[i].Index = MCQSData_Greek.answersIndex[i];
                    //Debug.Log(ans[0]);

                    histOp1[i].answer = MCQSData_Greek.Op1[i];
                    histOp2[i].answer = MCQSData_Greek.Op2[i];
                    histOp3[i].answer = MCQSData_Greek.Op3[i];
                    histOp4[i].answer = MCQSData_Greek.Op4[i];

                    //  explainText.text = MCQSData.Question_Explanation[i];

                }
                break;
            case 3:
                for (int i = 0; i < 7; i++)
                {
                    historyQues[i] = MCQSData_Polish.questions[i];
                    //historyAns[i] = MCQSData.answersIndex[i];
                    HistoryAnsMcqs[i].Index = MCQSData_Polish.answersIndex[i];
                    //Debug.Log(ans[0]);

                    histOp1[i].answer = MCQSData_Polish.Op1[i];
                    histOp2[i].answer = MCQSData_Polish.Op2[i];
                    histOp3[i].answer = MCQSData_Polish.Op3[i];
                    histOp4[i].answer = MCQSData_Polish.Op4[i];

                    //  explainText.text = MCQSData.Question_Explanation[i];

                }
                break;
        }
    }


    #endregion

    #region Geography Quiz Data
    //*************** TRUE False *************//
    public void SetGeographyQuizData(int index)
    {
        //onclicks added or removed
        //TickButton1.onClick.RemoveAllListeners();
        //TickButton1.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[0], TF_KEY, TickButton1));

        //TickButton2.onClick.RemoveAllListeners();
        //TickButton2.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[1], TF_KEY, TickButton2));

        //ResetButton.onClick.RemoveAllListeners();
        //ResetButton.onClick.AddListener(() => ResetQuestionaPanel(TF_KEY));

        // TickButton3.gameObject.SetActive(false);

        selectedCategory = index;
        SetGeographyOptionData();

        int temp = geographyQuizIndex;

        geographyQuizIndex = Random.Range(0, geographyQues.Length);

        if (temp == geographyQuizIndex)
        {
            geographyQuizIndex = Random.Range(0, geographyQues.Length);
        }

        Debug.Log(geographyQuizIndex);

        geographyQuestonText.text = geographyQues[geographyQuizIndex];

        geographyOptionTexts[0].text = geogOp1[geographyQuizIndex].answer;
        geographyOptionTexts[1].text = geogOp2[geographyQuizIndex].answer;
        geographyOptionTexts[2].text = geogOp3[geographyQuizIndex].answer;
        geographyOptionTexts[3].text = geogOp4[geographyQuizIndex].answer;

        switch (GData.selectedLanguage)
        {
            case 0:
                explainText.text = MCQSData.Question_Explanation[geographyQuizIndex + 7];
                break;

            case 1:
                explainText.text = MCQSData_Italian.Question_Explanation[geographyQuizIndex + 7];
                break;
            case 2:
                explainText.text = MCQSData_Greek.Question_Explanation[geographyQuizIndex + 7];
                break;
            case 3:
                explainText.text = MCQSData_Polish.Question_Explanation[geographyQuizIndex + 7];
                break;
        }

        //setting style
        //SetTextStyle(geographyOptionTexts[0], geographyOptionTexts[1]);
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
        for (int i = 0; i < 7; i++)
        {
            geographyQues = new string[7];
            geographyQues[i] = "";

            geographyAns = new int[7];
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
                for (int i = 0; i < 7; i++)
                {
                    geographyQues[i] = MCQSData.questions[i + 7];
                    geographyAns[i] = MCQSData.answersIndex[i + 7];

                    geogOp1[i].answer = MCQSData.Op1[i + 7];
                    geogOp2[i].answer = MCQSData.Op2[i + 7];
                    geogOp3[i].answer = MCQSData.Op3[i + 7];
                    geogOp4[i].answer = MCQSData.Op4[i + 7];

                    //  explainText.text = MCQSData.Question_Explanation[i+7];

                }
                break;

            case 1:
                for (int i = 0; i < 7; i++)
                {
                    geographyQues[i] = MCQSData_Italian.questions[i + 7];
                    geographyAns[i] = MCQSData_Italian.answersIndex[i + 7];

                    geogOp1[i].answer = MCQSData_Italian.Op1[i + 7];
                    geogOp2[i].answer = MCQSData_Italian.Op2[i + 7];
                    geogOp3[i].answer = MCQSData_Italian.Op3[i + 7];
                    geogOp4[i].answer = MCQSData_Italian.Op4[i + 7];

                    //  explainText.text = MCQSData.Question_Explanation[i+7];

                }
                break;
            case 2:
                for (int i = 0; i < 7; i++)
                {
                    geographyQues[i] = MCQSData_Greek.questions[i + 7];
                    geographyAns[i] = MCQSData_Greek.answersIndex[i + 7];

                    geogOp1[i].answer = MCQSData_Greek.Op1[i + 7];
                    geogOp2[i].answer = MCQSData_Greek.Op2[i + 7];
                    geogOp3[i].answer = MCQSData_Greek.Op3[i + 7];
                    geogOp4[i].answer = MCQSData_Greek.Op4[i + 7];

                    //  explainText.text = MCQSData.Question_Explanation[i+7];

                }
                break;
            case 3:
                for (int i = 0; i < 7; i++)
                {
                    geographyQues[i] = MCQSData_Polish.questions[i + 7];
                    geographyAns[i] = MCQSData_Polish.answersIndex[i + 7];

                    geogOp1[i].answer = MCQSData_Polish.Op1[i + 7];
                    geogOp2[i].answer = MCQSData_Polish.Op2[i + 7];
                    geogOp3[i].answer = MCQSData_Polish.Op3[i + 7];
                    geogOp4[i].answer = MCQSData_Polish.Op4[i + 7];

                    //  explainText.text = MCQSData.Question_Explanation[i+7];

                }
                break;
        }
    }

    //************* MCQS ********************//
    public void SetGeographyQuizDataMCQS(int index)
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

        TickButton3.gameObject.SetActive(true);

        selectedCategory = index;
        SetGeographyOptionDataMCQS();

        int temp = geographyQuizIndex;

        geographyQuizIndex = Random.Range(0, geographyQues.Length);

        if (temp == geographyQuizIndex)
        {
            geographyQuizIndex = Random.Range(0, geographyQues.Length);
        }

        Debug.Log(geographyQuizIndex);


        if (geographyQuizIndex == 3)
        {
            infoBtn.GetComponent<Button>().onClick.RemoveAllListeners();
            infoBtn.GetComponent<Button>().onClick.AddListener(() => infoBtnClick(0));
            infoBtn.SetActive(true);
        }



        geographyQuestonText.text = geographyQues[geographyQuizIndex];

        geographyOptionTexts[0].text = geogOp1[geographyQuizIndex].answer;
        geographyOptionTexts[1].text = geogOp2[geographyQuizIndex].answer;
        geographyOptionTexts[2].text = geogOp3[geographyQuizIndex].answer;
        geographyOptionTexts[3].text = geogOp4[geographyQuizIndex].answer;


        switch (GData.selectedLanguage)
        {
            case 0:
                explainText.text = MCQSData.Question_Explanation[geographyQuizIndex + 7];
                break;

            case 1:
                explainText.text = MCQSData_Italian.Question_Explanation[geographyQuizIndex + 7];
                break;
            case 2:
                explainText.text = MCQSData_Greek.Question_Explanation[geographyQuizIndex + 7];
                break;
            case 3:
                explainText.text = MCQSData_Polish.Question_Explanation[geographyQuizIndex + 7];
                break;
        }


        for (int i = 0; i < 4; i++)
        {
            if (geographyAnsMcqs[geographyQuizIndex].Index == 0)
            {
                TickButton1.GetComponent<Answer>().iscorrect = true;
            }
            if (geographyAnsMcqs[geographyQuizIndex].Index == 1)
            {
                TickButton2.GetComponent<Answer>().iscorrect = true;
            }
            if ((geographyAnsMcqs[geographyQuizIndex].Index) == 2)
            {
                TickButton3.GetComponent<Answer>().iscorrect = true;
            }
            if ((geographyAnsMcqs[geographyQuizIndex].Index) == 3)
            {
                TickButton4.GetComponent<Answer>().iscorrect = true;
            }
        }

        //if (geographyAns[geographyQuizIndex] == 0)
        //{
        //    geographyFinalAnswer = geogOp1[geographyQuizIndex].answer;
        //}
        //else if (geographyAns[geographyQuizIndex] == 1)
        //{
        //    geographyFinalAnswer = geogOp2[geographyQuizIndex].answer;
        //}
        //else if (geographyAns[geographyQuizIndex] == 2)
        //{
        //    geographyFinalAnswer = geogOp3[geographyQuizIndex].answer;
        //}

        Debug.Log(geographyFinalAnswer);
    }

    private void SetGeographyOptionDataMCQS()
    {
        for (int i = 0; i < 7; i++)
        {
            geographyQues = new string[7];
            geographyQues[i] = "";

            geographyAns = new int[7];
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

        for (int i = 0; i < geographyAnsMcqs.Length; i++)
        {
            geographyAnsMcqs[i] = new FindIndex();
        }


        switch (GData.selectedLanguage)
        {
            case 0:
                for (int i = 0; i < 7; i++)
                {
                    geographyQues[i] = MCQSData.questions[i + 7];
                    //geographyAns[i] = MCQSData.answersIndex[i];
                    geographyAnsMcqs[i].Index = MCQSData.answersIndex[i + 7];

                    geogOp1[i].answer = MCQSData.Op1[i + 7];
                    geogOp2[i].answer = MCQSData.Op2[i + 7];
                    geogOp3[i].answer = MCQSData.Op3[i + 7];
                    geogOp4[i].answer = MCQSData.Op4[i + 7];

                    //    explainText.text = MCQSData.Question_Explanation[i + 7];

                }
                break;

            case 1:
                for (int i = 0; i < 7; i++)
                {
                    geographyQues[i] = MCQSData_Italian.questions[i + 7];
                    //geographyAns[i] = MCQSData.answersIndex[i];
                    geographyAnsMcqs[i].Index = MCQSData_Italian.answersIndex[i + 7];

                    geogOp1[i].answer = MCQSData_Italian.Op1[i + 7];
                    geogOp2[i].answer = MCQSData_Italian.Op2[i + 7];
                    geogOp3[i].answer = MCQSData_Italian.Op3[i + 7];
                    geogOp4[i].answer = MCQSData_Italian.Op4[i + 7];

                    //    explainText.text = MCQSData.Question_Explanation[i + 7];

                }
                break;
            case 2:
                for (int i = 0; i < 7; i++)
                {
                    geographyQues[i] = MCQSData_Greek.questions[i + 7];
                    //geographyAns[i] = MCQSData.answersIndex[i];
                    geographyAnsMcqs[i].Index = MCQSData_Greek.answersIndex[i + 7];

                    geogOp1[i].answer = MCQSData_Greek.Op1[i + 7];
                    geogOp2[i].answer = MCQSData_Greek.Op2[i + 7];
                    geogOp3[i].answer = MCQSData_Greek.Op3[i + 7];
                    geogOp4[i].answer = MCQSData_Greek.Op4[i + 7];

                    //    explainText.text = MCQSData.Question_Explanation[i + 7];

                }
                break;
            case 3:
                for (int i = 0; i < 7; i++)
                {
                    geographyQues[i] = MCQSData_Polish.questions[i + 7];
                    //geographyAns[i] = MCQSData.answersIndex[i];
                    geographyAnsMcqs[i].Index = MCQSData_Polish.answersIndex[i + 7];

                    geogOp1[i].answer = MCQSData_Polish.Op1[i + 7];
                    geogOp2[i].answer = MCQSData_Polish.Op2[i + 7];
                    geogOp3[i].answer = MCQSData_Polish.Op3[i + 7];
                    geogOp4[i].answer = MCQSData_Polish.Op4[i + 7];

                    //    explainText.text = MCQSData.Question_Explanation[i + 7];

                }
                break;
        }
    }

    #endregion

    #region Food Quiz Data
    //*************** TRUE False *************//
    public void SetFoodQuizData(int index)
    {
        //onclicks added or removed
        //TickButton1.onClick.RemoveAllListeners();
        //TickButton1.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[0], TF_KEY, TickButton1));

        //TickButton2.onClick.RemoveAllListeners();
        //TickButton2.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[1], TF_KEY, TickButton2));

        //ResetButton.onClick.RemoveAllListeners();
        //ResetButton.onClick.AddListener(() => ResetQuestionaPanel(TF_KEY));

        //TickButton3.gameObject.SetActive(false);

        selectedCategory = index;
        SetFoodOptionData();

        int temp = foodQuizIndex;

        foodQuizIndex = Random.Range(0, foodQues.Length);

        if (temp == foodQuizIndex)
        {
            foodQuizIndex = Random.Range(0, foodQues.Length);
        }

        Debug.Log(foodQuizIndex);

        foodQuestonText.text = foodQues[foodQuizIndex];

        foodOptionTexts[0].text = foodOp1[foodQuizIndex].answer;
        foodOptionTexts[1].text = foodOp2[foodQuizIndex].answer;
        foodOptionTexts[2].text = foodOp3[foodQuizIndex].answer;
        foodOptionTexts[3].text = foodOp4[foodQuizIndex].answer;


        switch (GData.selectedLanguage)
        {
            case 0:
                explainText.text = MCQSData.Question_Explanation[foodQuizIndex + 14];
                break;

            case 1:
                explainText.text = MCQSData_Italian.Question_Explanation[foodQuizIndex + 14];
                break;

            case 2:
                explainText.text = MCQSData_Greek.Question_Explanation[foodQuizIndex + 14];
                break;
            case 3:
                explainText.text = MCQSData_Polish.Question_Explanation[foodQuizIndex + 14];
                break;
        }

        //setting style
        // SetTextStyle(foodOptionTexts[0], foodOptionTexts[1]);
        // SetTextStyle(foodOptionTexts[0], foodOptionTexts[1], foodOptionTexts[2], foodOptionTexts[3]);


        if (foodAns[foodQuizIndex] == 0)
        {
            HighlightIndex = 0;
            foodFinalAnswer = foodOp1[foodQuizIndex].answer;
        }
        else if (foodAns[foodQuizIndex] == 1)
        {
            HighlightIndex = 1;
            foodFinalAnswer = foodOp2[foodQuizIndex].answer;
        }
        else if (foodAns[foodQuizIndex] == 2)
        {
            HighlightIndex = 2;
            foodFinalAnswer = foodOp3[foodQuizIndex].answer;
        }
        else if (foodAns[foodQuizIndex] == 3)
        {
            HighlightIndex = 3;
            foodFinalAnswer = foodOp4[foodQuizIndex].answer;
        }


        Debug.Log(foodFinalAnswer);
    }

    private void SetFoodOptionData()
    {
        for (int i = 0; i < 7; i++)
        {
            foodQues = new string[7];
            foodQues[i] = "";

            foodAns = new int[7];
            foodAns[i] = 0;
        }


        for (int i = 0; i < foodOp1.Length; i++)
        {
            foodOp1[i] = new Option();
        }
        for (int i = 0; i < foodOp2.Length; i++)
        {
            foodOp2[i] = new Option();
        }
        for (int i = 0; i < foodOp3.Length; i++)
        {
            foodOp3[i] = new Option();
        }
        for (int i = 0; i < foodOp4.Length; i++)
        {
            foodOp4[i] = new Option();
        }


        switch (GData.selectedLanguage)
        {
            case 0:
                for (int i = 0; i < 7; i++)
                {
                    foodQues[i] = MCQSData.questions[i + 14];
                    foodAns[i] = MCQSData.answersIndex[i + 14];

                    foodOp1[i].answer = MCQSData.Op1[i + 14];
                    foodOp2[i].answer = MCQSData.Op2[i + 14];
                    foodOp3[i].answer = MCQSData.Op3[i + 14];
                    foodOp4[i].answer = MCQSData.Op4[i + 14];
                }
                break;

            case 1:
                for (int i = 0; i < 7; i++)
                {
                    foodQues[i] = MCQSData_Italian.questions[i + 14];
                    foodAns[i] = MCQSData_Italian.answersIndex[i + 14];

                    foodOp1[i].answer = MCQSData_Italian.Op1[i + 14];
                    foodOp2[i].answer = MCQSData_Italian.Op2[i + 14];
                    foodOp3[i].answer = MCQSData_Italian.Op3[i + 14];
                    foodOp4[i].answer = MCQSData_Italian.Op4[i + 14];
                }
                break;
            case 2:
                for (int i = 0; i < 7; i++)
                {
                    foodQues[i] = MCQSData_Greek.questions[i + 14];
                    foodAns[i] = MCQSData_Greek.answersIndex[i + 14];

                    foodOp1[i].answer = MCQSData_Greek.Op1[i + 14];
                    foodOp2[i].answer = MCQSData_Greek.Op2[i + 14];
                    foodOp3[i].answer = MCQSData_Greek.Op3[i + 14];
                    foodOp4[i].answer = MCQSData_Greek.Op4[i + 14];
                }
                break;
            case 3:
                for (int i = 0; i < 7; i++)
                {
                    foodQues[i] = MCQSData_Polish.questions[i + 14];
                    foodAns[i] = MCQSData_Polish.answersIndex[i + 14];

                    foodOp1[i].answer = MCQSData_Polish.Op1[i + 14];
                    foodOp2[i].answer = MCQSData_Polish.Op2[i + 14];
                    foodOp3[i].answer = MCQSData_Polish.Op3[i + 14];
                    foodOp4[i].answer = MCQSData_Polish.Op4[i + 14];
                }
                break;
        }
    }

    //************* MCQS ********************//

    public void SetFoodQuizDataMCQS(int index)
    {
        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[0]));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[1]));


        TickButton3.onClick.RemoveAllListeners();
        TickButton3.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[2]));

        TickButton4.onClick.RemoveAllListeners();
        TickButton4.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[3]));

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel());

        TickButton3.gameObject.SetActive(true);

        selectedCategory = index;
        SetFoodOptionDataMCQS();

        int temp = foodQuizIndex;

        foodQuizIndex = Random.Range(0, foodQues.Length);

        if (temp == foodQuizIndex)
        {
            foodQuizIndex = Random.Range(0, foodQues.Length);
        }

        Debug.Log(foodQuizIndex);

        foodQuestonText.text = foodQues[foodQuizIndex];

        foodOptionTexts[0].text = foodOp1[foodQuizIndex].answer;
        foodOptionTexts[1].text = foodOp2[foodQuizIndex].answer;
        foodOptionTexts[2].text = foodOp3[foodQuizIndex].answer;
        foodOptionTexts[3].text = foodOp4[foodQuizIndex].answer;

        // explainText.text = MCQSData.Question_Explanation[foodQuizIndex + 14];
        switch (GData.selectedLanguage)
        {
            case 0:
                explainText.text = MCQSData.Question_Explanation[foodQuizIndex + 14];
                break;

            case 1:
                explainText.text = MCQSData_Italian.Question_Explanation[foodQuizIndex + 14];
                break;
            case 2:
                explainText.text = MCQSData_Greek.Question_Explanation[foodQuizIndex + 14];
                break;
            case 3:
                explainText.text = MCQSData_Polish.Question_Explanation[foodQuizIndex + 14];
                break;
        }

        for (int i = 0; i < 4; i++)
        {
            if ((foodAnsMcqs[foodQuizIndex].Index) == 0)
            {
                TickButton1.GetComponent<Answer>().iscorrect = true;
            }
            if ((foodAnsMcqs[foodQuizIndex].Index) == 1)
            {
                TickButton2.GetComponent<Answer>().iscorrect = true;
            }
            if ((foodAnsMcqs[foodQuizIndex].Index) == 2)
            {
                TickButton3.GetComponent<Answer>().iscorrect = true;
            }
            if ((foodAnsMcqs[foodQuizIndex].Index) == 3)
            {
                TickButton4.GetComponent<Answer>().iscorrect = true;
            }
        }


        //if (foodAns[foodQuizIndex] == 0)
        //{
        //    foodFinalAnswer = foodOp1[foodQuizIndex].answer;
        //}
        //else if (foodAns[foodQuizIndex] == 1)
        //{
        //    foodFinalAnswer = foodOp2[foodQuizIndex].answer;
        //}
        //else if (foodAns[foodQuizIndex] == 2)
        //{
        //    foodFinalAnswer = foodOp3[foodQuizIndex].answer;
        //}


        Debug.Log(foodFinalAnswer);
    }

    private void SetFoodOptionDataMCQS()
    {
        for (int i = 0; i < 4; i++)
        {
            foodQues = new string[4];
            foodQues[i] = "";

            foodAns = new int[4];
            foodAns[i] = 0;
        }


        for (int i = 0; i < foodOp1.Length; i++)
        {
            foodOp1[i] = new Option();
        }
        for (int i = 0; i < foodOp2.Length; i++)
        {
            foodOp2[i] = new Option();
        }
        for (int i = 0; i < foodOp3.Length; i++)
        {
            foodOp3[i] = new Option();
        }
        for (int i = 0; i < foodOp4.Length; i++)
        {
            foodOp4[i] = new Option();
        }

        for (int i = 0; i < foodAnsMcqs.Length; i++)
        {
            foodAnsMcqs[i] = new FindIndex();
        }


        //for (int i = 0; i < 7; i++)
        //{
        //    foodQues[i] = MCQSData.questions[i + 14];
        //    foodAnsMcqs[i].Index = MCQSData.answersIndex[i + 14]; //.Split(',');
        //    foodOp1[i].answer = MCQSData.Op1[i + 14];
        //    foodOp2[i].answer = MCQSData.Op2[i + 14];
        //    foodOp3[i].answer = MCQSData.Op3[i + 14];
        //    foodOp4[i].answer = MCQSData.Op4[i + 14];
        //}
        switch (GData.selectedLanguage)
        {
            case 0:
                for (int i = 0; i < 7; i++)
                {
                    foodQues[i] = MCQSData.questions[i + 14];
                    foodAnsMcqs[i].Index = MCQSData.answersIndex[i + 14]; //.Split(',');
                    foodOp1[i].answer = MCQSData.Op1[i + 14];
                    foodOp2[i].answer = MCQSData.Op2[i + 14];
                    foodOp3[i].answer = MCQSData.Op3[i + 14];
                    foodOp4[i].answer = MCQSData.Op4[i + 14];
                }
                break;

            case 1:
                for (int i = 0; i < 7; i++)
                {
                    foodQues[i] = MCQSData_Italian.questions[i + 14];
                    foodAnsMcqs[i].Index = MCQSData_Italian.answersIndex[i + 14]; //.Split(',');
                    foodOp1[i].answer = MCQSData_Italian.Op1[i + 14];
                    foodOp2[i].answer = MCQSData_Italian.Op2[i + 14];
                    foodOp3[i].answer = MCQSData_Italian.Op3[i + 14];
                    foodOp4[i].answer = MCQSData_Italian.Op4[i + 14];
                }
                break;
            case 2:
                for (int i = 0; i < 7; i++)
                {
                    foodQues[i] = MCQSData_Greek.questions[i + 14];
                    foodAnsMcqs[i].Index = MCQSData_Greek.answersIndex[i + 14]; //.Split(',');
                    foodOp1[i].answer = MCQSData_Greek.Op1[i + 14];
                    foodOp2[i].answer = MCQSData_Greek.Op2[i + 14];
                    foodOp3[i].answer = MCQSData_Greek.Op3[i + 14];
                    foodOp4[i].answer = MCQSData_Greek.Op4[i + 14];
                }
                break;
            case 3:
                for (int i = 0; i < 7; i++)
                {
                    foodQues[i] = MCQSData_Polish.questions[i + 14];
                    foodAnsMcqs[i].Index = MCQSData_Polish.answersIndex[i + 14]; //.Split(',');
                    foodOp1[i].answer = MCQSData_Polish.Op1[i + 14];
                    foodOp2[i].answer = MCQSData_Polish.Op2[i + 14];
                    foodOp3[i].answer = MCQSData_Polish.Op3[i + 14];
                    foodOp4[i].answer = MCQSData_Polish.Op4[i + 14];
                }
                break;
        }
    }

    #endregion

    #region Culture Quiz Data
    //*************** TRUE False *************//
    public void SetCultureQuizData(int index)
    {
        //onclicks added or removed
        //TickButton1.onClick.RemoveAllListeners();
        //TickButton1.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[0], TF_KEY, TickButton1));

        //TickButton2.onClick.RemoveAllListeners();
        //TickButton2.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[1], TF_KEY, TickButton2));

        //ResetButton.onClick.RemoveAllListeners();
        //ResetButton.onClick.AddListener(() => ResetQuestionaPanel(TF_KEY));

        //TickButton3.gameObject.SetActive(false);

        selectedCategory = index;
        SetCultureOptionData();
        int temp = cultureQuizIndex;

        cultureQuizIndex = Random.Range(0, cultureQues.Length);

        if (temp == cultureQuizIndex)
        {
            cultureQuizIndex = Random.Range(0, cultureQues.Length);
        }

        Debug.Log(cultureQuizIndex);

        cultureQuestonText.text = cultureQues[cultureQuizIndex];

        cultureOptionTexts[0].text = culOp1[cultureQuizIndex].answer;
        cultureOptionTexts[1].text = culOp2[cultureQuizIndex].answer;
        cultureOptionTexts[2].text = culOp3[cultureQuizIndex].answer;
        cultureOptionTexts[3].text = culOp4[cultureQuizIndex].answer;



        switch (GData.selectedLanguage)
        {
            case 0:
                explainText.text = MCQSData.Question_Explanation[cultureQuizIndex + 21];
                break;

            case 1:
                explainText.text = MCQSData_Italian.Question_Explanation[cultureQuizIndex + 21];
                break;
            case 2:
                explainText.text = MCQSData_Greek.Question_Explanation[cultureQuizIndex + 21];
                break;
            case 3:
                explainText.text = MCQSData_Polish.Question_Explanation[cultureQuizIndex + 21];
                break;
        }
        //setting style
        //  SetTextStyle(cultureOptionTexts[0], cultureOptionTexts[1]);
        // SetTextStyle(cultureOptionTexts[0], cultureOptionTexts[1], cultureOptionTexts[2], cultureOptionTexts[3]);


        if (cultureAns[cultureQuizIndex] == 0)
        {
            HighlightIndex = 0;
            cultureFinalAnswer = culOp1[cultureQuizIndex].answer;
        }
        else if (cultureAns[cultureQuizIndex] == 1)
        {
            HighlightIndex = 1;
            cultureFinalAnswer = culOp2[cultureQuizIndex].answer;
        }
        else if (cultureAns[cultureQuizIndex] == 2)
        {
            HighlightIndex = 2;
            cultureFinalAnswer = culOp3[cultureQuizIndex].answer;
        }
        else if (cultureAns[cultureQuizIndex] == 3)
        {
            HighlightIndex = 3;
            cultureFinalAnswer = culOp4[cultureQuizIndex].answer;
        }


        Debug.Log(cultureFinalAnswer);
    }

    private void SetCultureOptionData()
    {
        for (int i = 0; i < 7; i++)
        {
            cultureQues = new string[7];
            cultureQues[i] = "";

            cultureAns = new int[7];
            cultureAns[i] = 0;
        }


        for (int i = 0; i < culOp1.Length; i++)
        {
            culOp1[i] = new Option();
        }
        for (int i = 0; i < culOp2.Length; i++)
        {
            culOp2[i] = new Option();
        }
        for (int i = 0; i < culOp3.Length; i++)
        {
            culOp3[i] = new Option();
        }
        for (int i = 0; i < culOp4.Length; i++)
        {
            culOp4[i] = new Option();
        }

        //for (int i = 0; i < 7; i++)
        //{
        //    cultureQues[i] = MCQSData.questions[i + 21];
        //    cultureAns[i] = MCQSData.answersIndex[i + 21];

        //    culOp1[i].answer = MCQSData.Op1[i + 21];
        //    culOp2[i].answer = MCQSData.Op2[i + 21];
        //    culOp3[i].answer = MCQSData.Op3[i + 21];
        //    culOp4[i].answer = MCQSData.Op4[i + 21];
        //}
        switch (GData.selectedLanguage)
        {
            case 0:
                for (int i = 0; i < 7; i++)
                {
                    cultureQues[i] = MCQSData.questions[i + 21];
                    cultureAns[i] = MCQSData.answersIndex[i + 21];

                    culOp1[i].answer = MCQSData.Op1[i + 21];
                    culOp2[i].answer = MCQSData.Op2[i + 21];
                    culOp3[i].answer = MCQSData.Op3[i + 21];
                    culOp4[i].answer = MCQSData.Op4[i + 21];
                }
                break;

            case 1:
                for (int i = 0; i < 7; i++)
                {
                    cultureQues[i] = MCQSData_Italian.questions[i + 21];
                    cultureAns[i] = MCQSData_Italian.answersIndex[i + 21];

                    culOp1[i].answer = MCQSData_Italian.Op1[i + 21];
                    culOp2[i].answer = MCQSData_Italian.Op2[i + 21];
                    culOp3[i].answer = MCQSData_Italian.Op3[i + 21];
                    culOp4[i].answer = MCQSData_Italian.Op4[i + 21];
                }
                break;
            case 2:
                for (int i = 0; i < 7; i++)
                {
                    cultureQues[i] = MCQSData_Greek.questions[i + 21];
                    cultureAns[i] = MCQSData_Greek.answersIndex[i + 21];

                    culOp1[i].answer = MCQSData_Greek.Op1[i + 21];
                    culOp2[i].answer = MCQSData_Greek.Op2[i + 21];
                    culOp3[i].answer = MCQSData_Greek.Op3[i + 21];
                    culOp4[i].answer = MCQSData_Greek.Op4[i + 21];
                }
                break;
            case 3:
                for (int i = 0; i < 7; i++)
                {
                    cultureQues[i] = MCQSData_Polish.questions[i + 21];
                    cultureAns[i] = MCQSData_Polish.answersIndex[i + 21];

                    culOp1[i].answer = MCQSData_Polish.Op1[i + 21];
                    culOp2[i].answer = MCQSData_Polish.Op2[i + 21];
                    culOp3[i].answer = MCQSData_Polish.Op3[i + 21];
                    culOp4[i].answer = MCQSData_Polish.Op4[i + 21];
                }
                break;
        }
    }

    //************* MCQS ********************//
    public void SetCultureQuizDataMCQS(int index)
    {
        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[0]));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[1]));

        TickButton3.onClick.RemoveAllListeners();
        TickButton3.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[2]));

        TickButton4.onClick.RemoveAllListeners();
        TickButton4.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[3]));

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel());

        TickButton3.gameObject.SetActive(true);

        selectedCategory = index;
        SetCultureOptionDataMCQS();
        int temp = cultureQuizIndex;

        cultureQuizIndex = Random.Range(0, cultureQues.Length);

        if (temp == cultureQuizIndex)
        {
            cultureQuizIndex = Random.Range(0, cultureQues.Length);
        }

        Debug.Log(cultureQuizIndex);

        cultureQuestonText.text = cultureQues[cultureQuizIndex];

        cultureOptionTexts[0].text = culOp1[cultureQuizIndex].answer;
        cultureOptionTexts[1].text = culOp2[cultureQuizIndex].answer;
        cultureOptionTexts[2].text = culOp3[cultureQuizIndex].answer;
        cultureOptionTexts[3].text = culOp4[cultureQuizIndex].answer;

        // explainText.text = MCQSData.Question_Explanation[cultureQuizIndex + 21];
        switch (GData.selectedLanguage)
        {
            case 0:
                explainText.text = MCQSData.Question_Explanation[cultureQuizIndex + 21];
                break;

            case 1:
                explainText.text = MCQSData_Italian.Question_Explanation[cultureQuizIndex + 21];
                break;
            case 2:
                explainText.text = MCQSData_Greek.Question_Explanation[cultureQuizIndex + 21];
                break;
            case 3:
                explainText.text = MCQSData_Polish.Question_Explanation[cultureQuizIndex + 21];
                break;
        }

        for (int i = 0; i < 4; i++)
        {
            if ((cultureAnsMcqs[cultureQuizIndex].Index) == 0)
            {
                TickButton1.GetComponent<Answer>().iscorrect = true;
            }
            if ((cultureAnsMcqs[cultureQuizIndex].Index) == 1)
            {
                TickButton2.GetComponent<Answer>().iscorrect = true;
            }
            if ((cultureAnsMcqs[cultureQuizIndex].Index) == 2)
            {
                TickButton3.GetComponent<Answer>().iscorrect = true;
            }
            if ((cultureAnsMcqs[cultureQuizIndex].Index) == 3)
            {
                TickButton4.GetComponent<Answer>().iscorrect = true;
            }
        }

        //if (cultureAns[cultureQuizIndex] == 0)
        //{
        //    cultureFinalAnswer = culOp1[cultureQuizIndex].answer;
        //}
        //else if (cultureAns[cultureQuizIndex] == 1)
        //{
        //    cultureFinalAnswer = culOp2[cultureQuizIndex].answer;
        //}
        //else if (cultureAns[cultureQuizIndex] == 2)
        //{
        //    cultureFinalAnswer = culOp3[cultureQuizIndex].answer;
        //}

        Debug.Log(cultureFinalAnswer);
    }

    private void SetCultureOptionDataMCQS()
    {
        for (int i = 0; i < 7; i++)
        {
            cultureQues = new string[7];
            cultureQues[i] = "";

            cultureAns = new int[7];
            cultureAns[i] = 0;
        }


        for (int i = 0; i < culOp1.Length; i++)
        {
            culOp1[i] = new Option();
        }
        for (int i = 0; i < culOp2.Length; i++)
        {
            culOp2[i] = new Option();
        }
        for (int i = 0; i < culOp3.Length; i++)
        {
            culOp3[i] = new Option();
        }
        for (int i = 0; i < culOp4.Length; i++)
        {
            culOp4[i] = new Option();
        }

        for (int i = 0; i < cultureAnsMcqs.Length; i++)
        {
            cultureAnsMcqs[i] = new FindIndex();
        }


        //for (int i = 0; i < 7; i++)
        //{
        //    cultureQues[i] = MCQSData.questions[i+21];
        //    //cultureAns[i] = MCQSData.answersIndex[i];

        //    cultureAnsMcqs[i].Index = MCQSData.answersIndex[i + 21];//.Split(',');

        //    culOp1[i].answer = MCQSData.Op1[i + 21];
        //    culOp2[i].answer = MCQSData.Op2[i + 21];
        //    culOp3[i].answer = MCQSData.Op3[i + 21];
        //    culOp4[i].answer = MCQSData.Op4[i + 21];
        // //   explainText.text = MCQSData.Question_Explanation[i + 21];

        //}
        switch (GData.selectedLanguage)
        {
            case 0:
                for (int i = 0; i < 7; i++)
                {
                    cultureQues[i] = MCQSData.questions[i + 21];
                    //cultureAns[i] = MCQSData.answersIndex[i];

                    cultureAnsMcqs[i].Index = MCQSData.answersIndex[i + 21];//.Split(',');

                    culOp1[i].answer = MCQSData.Op1[i + 21];
                    culOp2[i].answer = MCQSData.Op2[i + 21];
                    culOp3[i].answer = MCQSData.Op3[i + 21];
                    culOp4[i].answer = MCQSData.Op4[i + 21];
                    //   explainText.text = MCQSData.Question_Explanation[i + 21];

                }
                break;

            case 1:
                for (int i = 0; i < 7; i++)
                {
                    cultureQues[i] = MCQSData_Italian.questions[i + 21];
                    //cultureAns[i] = MCQSData_Italian.answersIndex[i];

                    cultureAnsMcqs[i].Index = MCQSData_Italian.answersIndex[i + 21];//.Split(',');

                    culOp1[i].answer = MCQSData_Italian.Op1[i + 21];
                    culOp2[i].answer = MCQSData_Italian.Op2[i + 21];
                    culOp3[i].answer = MCQSData_Italian.Op3[i + 21];
                    culOp4[i].answer = MCQSData_Italian.Op4[i + 21];
                    //   explainText.text = MCQSData.Question_Explanation[i + 21];

                }
                break;
            case 2:
                for (int i = 0; i < 7; i++)
                {
                    cultureQues[i] = MCQSData_Greek.questions[i + 21];
                    //cultureAns[i] = MCQSData_Italian.answersIndex[i];

                    cultureAnsMcqs[i].Index = MCQSData_Greek.answersIndex[i + 21];//.Split(',');

                    culOp1[i].answer = MCQSData_Greek.Op1[i + 21];
                    culOp2[i].answer = MCQSData_Greek.Op2[i + 21];
                    culOp3[i].answer = MCQSData_Greek.Op3[i + 21];
                    culOp4[i].answer = MCQSData_Greek.Op4[i + 21];
                    //   explainText.text = MCQSData.Question_Explanation[i + 21];

                }
                break;
            case 3:
                for (int i = 0; i < 7; i++)
                {
                    cultureQues[i] = MCQSData_Polish.questions[i + 21];
                    //cultureAns[i] = MCQSData_Italian.answersIndex[i];

                    cultureAnsMcqs[i].Index = MCQSData_Polish.answersIndex[i + 21];//.Split(',');

                    culOp1[i].answer = MCQSData_Polish.Op1[i + 21];
                    culOp2[i].answer = MCQSData_Polish.Op2[i + 21];
                    culOp3[i].answer = MCQSData_Polish.Op3[i + 21];
                    culOp4[i].answer = MCQSData_Polish.Op4[i + 21];
                    //   explainText.text = MCQSData.Question_Explanation[i + 21];

                }
                break;
        }
    }

    #endregion


    #region Common Functions



    public void infoBtnClick(int index)
    {
        scrollImages.SetActive(true);
        quizImages[index].SetActive(true);
        closeScrollBtn.SetActive(true);
    }


    public class Option
    {
        public string answer;
        public string tag;
    }

    // private void SetTextStyle(Text text1, Text text2, Text text3, Text text4)
    // {
    //     //increase fonts
    //     text1.fontSize = 50;
    //     text2.fontSize = 50;
    //     text3.fontSize = 50;
    //     text4.fontSize = 50;
    //
    //     //set fontstyle
    //     text1.fontStyle = FontStyle.Bold;
    //     text2.fontStyle = FontStyle.Bold;
    //     text3.fontStyle = FontStyle.Bold;
    //     text4.fontStyle = FontStyle.Bold;
    //
    // }
    //
    // public void RemoveTextStyleFunc()
    // {
    //     historyOptionTexts[0].fontSize = 40;
    //     historyOptionTexts[1].fontSize = 40;
    //     historyOptionTexts[2].fontSize = 40;
    //     historyOptionTexts[3].fontSize = 40;
    //
    //     historyOptionTexts[0].fontStyle = FontStyle.Bold;
    //     historyOptionTexts[1].fontStyle = FontStyle.Bold;
    //     historyOptionTexts[2].fontStyle = FontStyle.Bold;
    //     historyOptionTexts[3].fontStyle = FontStyle.Bold;
    // }

    public void ResetQuestionaPanel()
    {
        explanationPanel.SetActive(false);

        //if (Category.Equals(TF_KEY))
        //{
        if (PlayerPrefs.GetInt("levelcurrent") == 2)
        {
            switch (GData.selectedLanguage)
            {
                case 0:
                    if (GData.belgiumData.completedHist < MCQSData.questions.Length)
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
                    if (GData.belgiumData.completedHistItalian < MCQSData_Italian.questions.Length)
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
                    if (GData.belgiumData.completedHistGreek < MCQSData_Greek.questions.Length)
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
                    if (GData.belgiumData.completedHistpolish < MCQSData_Polish.questions.Length)
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


    }  //Complete

    public void AnswerBtnClick(Text text)
    {
        TickButton1.interactable = false;
        TickButton2.interactable = false;
        TickButton3.interactable = false;
        TickButton4.interactable = false;
        //if (Category.Equals(TF_KEY))
        //{
        if (PlayerPrefs.GetInt("levelcurrent") == 2)
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
            Debug.Log("Correct culture Answer Selected");
            historyOptionTexts[HighlightIndex].color = Color.white;
            StartCoroutine(CorrectAnswerWait());
        }
        else if (index == 1)
        {
            historyOptionTexts[HighlightIndex].color = Color.white;
            StartCoroutine(WrongAnswerwait());
            Debug.Log("Wrong culture Answer Selected");
        }
        for (int i = 0; i < historyOptionTexts.Length; i++)
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
        RightAnswerPartical.SetActive(false);
        Answerdecision.text = "";
        //if (Category.Equals(TF_KEY))
        //{
        if (selectedCategory == 1)
        {
            switch (GData.selectedLanguage)
            {
                case 0:
                    if (GData.belgiumData.completedHist < MCQSData.questions.Length)
                    {
                        GData.belgiumData.completedHist++;
                        if (GData.belgiumData.completedHist < MCQSData.questions.Length)
                        {
                            SetHistoryQuizData(1);
                        }
                        else if (GData.belgiumData.completedHist == MCQSData.questions.Length)
                        {
                            if (GameManager.Instance.isMultiplayer)
                            {
                                if (GameManager.Instance.SelectedPlayer == 0)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    MulticongratsPanel.SetActive(true);
                                    GData.belgiumData.completedHist = 0;
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
                                if (GData.RightAnswer >= 14)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    congratsPanel.SetActive(true);
                                    congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                    GData.SceondLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                    Background.SetActive(true);
                                    GData.belgiumData.completedHist = 0;
                                    GData.RightAnswer = 0;
                                    GData.roomLockedIndex++;
                                }
                                else
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    GData.belgiumData.completedHist = 0;

                                    ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                                    levelFailPanel.SetActive(true);
                                    GData.RightAnswer = 0;
                                }
                            }
                        }
                    }

                    break;

                case 1:
                    if (GData.belgiumData.completedHistItalian < MCQSData_Italian.questions.Length)
                    {
                        GData.belgiumData.completedHistItalian++;
                        if (GData.belgiumData.completedHistItalian < MCQSData_Italian.questions.Length)
                        {
                            SetHistoryQuizData(1);
                        }
                        else if (GData.belgiumData.completedHistItalian == MCQSData_Italian.questions.Length)
                        {
                            if (GameManager.Instance.isMultiplayer)
                            {
                                if (GameManager.Instance.SelectedPlayer == 0)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    MulticongratsPanel.SetActive(true);
                                    GData.belgiumData.completedHistItalian = 0;
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

                                if (GData.RightAnswer >= 14)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    congratsPanel.SetActive(true);
                                     congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                    GData.SceondLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                    Background.SetActive(true);
                                    GData.belgiumData.completedHistItalian = 0;
                                    GData.RightAnswer = 0;
                                    GData.roomLockedIndex++;
                                }
                                else
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    GData.belgiumData.completedHistItalian = 0;

                                    ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                                    levelFailPanel.SetActive(true);
                                    GData.RightAnswer = 0;
                                }
                            }
                        }
                    }
                    break;
                case 2:
                    if (GData.belgiumData.completedHistGreek < MCQSData_Greek.questions.Length)
                    {
                        GData.belgiumData.completedHistGreek++;
                        if (GData.belgiumData.completedHistGreek < MCQSData_Greek.questions.Length)
                        {
                            SetHistoryQuizData(1);
                        }
                        else if (GData.belgiumData.completedHistGreek == MCQSData_Greek.questions.Length)
                        {
                            if (GameManager.Instance.isMultiplayer)
                            {
                                if (GameManager.Instance.SelectedPlayer == 0)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    MulticongratsPanel.SetActive(true);
                                    GData.belgiumData.completedHistGreek = 0;
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

                                if (GData.RightAnswer >= 14)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    congratsPanel.SetActive(true);
                                    congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                    GData.SceondLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                    Background.SetActive(true);
                                    GData.belgiumData.completedHistGreek = 0;
                                    GData.RightAnswer = 0;
                                    GData.roomLockedIndex++;
                                }
                                else
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    GData.belgiumData.completedHistGreek = 0;

                                    ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                                    levelFailPanel.SetActive(true);
                                    GData.RightAnswer = 0;
                                }
                            }
                        }
                    }
                    break;
                case 3:
                    if (GData.belgiumData.completedHistpolish < MCQSData_Polish.questions.Length)
                    {
                        GData.belgiumData.completedHistpolish++;
                        if (GData.belgiumData.completedHistpolish < MCQSData_Polish.questions.Length)
                        {
                            SetHistoryQuizData(1);
                        }
                        else if (GData.belgiumData.completedHistpolish == MCQSData_Polish.questions.Length)
                        {
                            if (GameManager.Instance.isMultiplayer)
                            {
                                if (GameManager.Instance.SelectedPlayer == 0)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    MulticongratsPanel.SetActive(true);
                                    GData.belgiumData.completedHistpolish = 0;
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

                                if (GData.RightAnswer >= 14)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    congratsPanel.SetActive(true);
                                    congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                    GData.SceondLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                    Background.SetActive(true);
                                    GData.belgiumData.completedHistpolish = 0;
                                    GData.RightAnswer = 0;
                                    GData.roomLockedIndex++;
                                }
                                else
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    GData.belgiumData.completedHistpolish = 0;

                                    ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
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
            //ResetQuestionaPanel();
            //levelFailPanel.SetActive(true);
            //Background.SetActive(true);
            //quizPanel.SetActive(false);
            //loadingManager.levelLoad(0);
            if (selectedCategory == 1)
            {
                switch (GData.selectedLanguage)
                {
                    case 0:
                        if (GData.belgiumData.completedHist < MCQSData.questions.Length)
                        {
                            GData.belgiumData.completedHist++;
                            if (GData.belgiumData.completedHist < MCQSData.questions.Length)
                            {
                                SetHistoryQuizData(1);
                            }
                            else if (GData.belgiumData.completedHist == MCQSData.questions.Length)
                            {
                                if (GameManager.Instance.isMultiplayer)
                                {
                                    if (GameManager.Instance.SelectedPlayer == 0)
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        MulticongratsPanel.SetActive(true);
                                        GData.belgiumData.completedHist = 0;
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
                                    if (GData.RightAnswer >= 14)
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        congratsPanel.SetActive(true);
                                        congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                        GData.SceondLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                        Background.SetActive(true);
                                        GData.RightAnswer = 0;
                                        GData.belgiumData.completedHist = 0;
                                        GData.roomLockedIndex++;
                                    }
                                    else
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        GData.belgiumData.completedHist = 0;
                                        ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                                        levelFailPanel.SetActive(true);
                                        GData.RightAnswer = 0;
                                    }
                                }
                            }
                        }

                        break;

                    case 1:
                        if (GData.belgiumData.completedHistItalian < MCQSData_Italian.questions.Length)
                        {
                            GData.belgiumData.completedHistItalian++;
                            if (GData.belgiumData.completedHistItalian < MCQSData_Italian.questions.Length)
                            {
                                SetHistoryQuizData(1);
                            }
                            else if (GData.belgiumData.completedHistItalian == MCQSData_Italian.questions.Length)
                            {
                                if (GameManager.Instance.isMultiplayer)
                                {
                                    if (GameManager.Instance.SelectedPlayer == 0)
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        MulticongratsPanel.SetActive(true);
                                        GData.belgiumData.completedHistItalian = 0;
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
                                    if (GData.RightAnswer >= 14)
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        congratsPanel.SetActive(true);
                                        congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                        GData.SceondLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                        Background.SetActive(true);
                                        GData.belgiumData.completedHistItalian = 0;
                                        GData.RightAnswer = 0;
                                        GData.roomLockedIndex++;
                                    }
                                    else
                                    {
                                        quizPanel.SetActive(false);
                                        GData.belgiumData.completedHistItalian = 0;
                                        quizobjecthandle();
                                        ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                                        levelFailPanel.SetActive(true);
                                        GData.RightAnswer = 0;


                                    }
                                }
                            }
                        }
                        break;
                    case 2:
                        if (GData.belgiumData.completedHistGreek < MCQSData_Greek.questions.Length)
                        {
                            GData.belgiumData.completedHistGreek++;
                            if (GData.belgiumData.completedHistGreek < MCQSData_Greek.questions.Length)
                            {
                                SetHistoryQuizData(1);
                            }
                            else if (GData.belgiumData.completedHistGreek == MCQSData_Greek.questions.Length)
                            {
                                if (GameManager.Instance.isMultiplayer)
                                {
                                    if (GameManager.Instance.SelectedPlayer == 0)
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        MulticongratsPanel.SetActive(true);
                                        GData.belgiumData.completedHistGreek = 0;
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
                                    if (GData.RightAnswer >= 14)
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        congratsPanel.SetActive(true);
                                        congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                        GData.SceondLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                        Background.SetActive(true);
                                        GData.belgiumData.completedHistGreek = 0;
                                        GData.RightAnswer = 0;
                                        GData.roomLockedIndex++;
                                    }
                                    else
                                    {
                                        quizPanel.SetActive(false);
                                        GData.belgiumData.completedHistGreek = 0;
                                        quizobjecthandle();
                                        ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                                        levelFailPanel.SetActive(true);
                                        GData.RightAnswer = 0;


                                    }
                                }
                            }
                        }
                        break;
                    case 3:
                        if (GData.belgiumData.completedHistpolish < MCQSData_Polish.questions.Length)
                        {
                            GData.belgiumData.completedHistpolish++;
                            if (GData.belgiumData.completedHistpolish < MCQSData_Polish.questions.Length)
                            {
                                SetHistoryQuizData(1);
                            }
                            else if (GData.belgiumData.completedHistpolish == MCQSData_Polish.questions.Length)
                            {
                                if (GameManager.Instance.isMultiplayer)
                                {
                                    if (GameManager.Instance.SelectedPlayer == 0)
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        MulticongratsPanel.SetActive(true);
                                        GData.belgiumData.completedHistpolish = 0;
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
                                    if (GData.RightAnswer >= 14)
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        congratsPanel.SetActive(true);
                                        congratsPanelScore.text = (GData.RightAnswer * 5).ToString();
                                        GData.SceondLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                        Background.SetActive(true);
                                        GData.belgiumData.completedHistpolish = 0;
                                        GData.RightAnswer = 0;
                                        GData.roomLockedIndex++;
                                    }
                                    else
                                    {
                                        quizPanel.SetActive(false);
                                        GData.belgiumData.completedHistpolish = 0;
                                        quizobjecthandle();
                                        ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
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
    [System.Serializable]
    public class FindIndex
    {
        public int Index;
    }
    public void quizobjecthandle()
    {
        QuizCamera.SetActive(false);
        // QuizCanvas.SetActive(false);
        mainCavas.SetActive(true);
    }

    #endregion
}
//[System.Serializable]
