using EasyMobile;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PolandManager : MonoBehaviour
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



    //  public TrueFalseData TFData;
    public MCQData MCQsData;
    public MCQData MCQsData_Italian;
    public MCQData MCQsData_Greek;
    public MCQData MCQsData_Polish;
    public GameData GData;
    /// <summary>
    /// Fake News Quizes Data
    /// </summary>
    /// 
    public Button TickButton1;
    public Button TickButton2;
    public Button TickButton3;
    public Button TickButton4;


    //public string[] TFQuestions;
    //public int[] TFAns;

    private const string TF_KEY = "TF";
    private const string MCQS_KEY = "MCQS";
    public Button ResetButton;

    public Text Answerdecision;
    /// <summary>
    /// History Quiz Data
    /// </summary>
    /// 

    public int[] historyAns;
    public FindIndex[] HistoryAnsMcqs = new FindIndex[4];
    public string[] historyQues;
    public static string historyFinalAnswer;
    public static int historyQuizIndex;

    private Option[] histOp1 = new Option[15];
    private Option[] histOp2 = new Option[15];
    private Option[] histOp3 = new Option[15];
    private Option[] histOp4 = new Option[15];


    public Text historyQuestonText;
    public Text[] historyOptionTexts;
    public TextMeshProUGUI historyScoreText;
    public GameObject historyCompleteImage;

    /// <summary>
    /// Geography Quiz Data
    /// </summary>
    /// 
    public int[] geographyAns;
    public FindIndex[] geographyAnsMcqs = new FindIndex[4];
    public string[] geographyQues;
    public static string geographyFinalAnswer;
    public static int geographyQuizIndex;

    private Option[] geogOp1 = new Option[4];
    private Option[] geogOp2 = new Option[4];
    private Option[] geogOp3 = new Option[4];
    private Option[] geogOp4 = new Option[4];

    public Text geographyQuestonText;
    public Text[] geographyOptionTexts;
    public TextMeshProUGUI geographyScoreText;
    public GameObject geographyCompleteImage;


    /// <summary>
    /// Food Quiz Data
    /// </summary>
    /// 
    public int[] foodAns;
    public FindIndex[] foodAnsMcqs = new FindIndex[4];
    public string[] foodQues;
    public static string foodFinalAnswer;
    public static int foodQuizIndex;

    private Option[] foodOp1 = new Option[4];
    private Option[] foodOp2 = new Option[4];
    private Option[] foodOp3 = new Option[4];
    private Option[] foodOp4 = new Option[4];


    public Text foodQuestonText;
    public Text[] foodOptionTexts;
    public TextMeshProUGUI foodScoreText;
    public GameObject foodCompleteImage;

    /// <summary>
    /// Culture Quiz Data
    /// </summary>
    /// 
    public int[] cultureAns;
    public FindIndex[] cultureAnsMcqs = new FindIndex[4];
    public string[] cultureQues;
    public static string cultureFinalAnswer;
    public static int cultureQuizIndex;

    private Option[] culOp1 = new Option[3];
    private Option[] culOp2 = new Option[3];
    private Option[] culOp3 = new Option[3];
    private Option[] culOp4 = new Option[3];


    public Text cultureQuestonText;
    public Text[] cultureOptionTexts;
    public TextMeshProUGUI cultureScoreText;
    public GameObject cultureCompleteImage;


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

    public BoxCollider door3Col;
    public GameObject congratsPanel;
    public Text congratsPanelTotalScore;
    public Text fstRoomScore;
    public Text scndRoomScore;
    public Text ThrdRoomScore;
    public Text frthRoomScore;
    public GameObject playerController;

    public GameObject controller;
    public LoadManager loadingManager;

    // public Button RemoveTextStyle;


    //public Button quizHist;
    //public Button quizGeo;
    //public Button quizFood;
    //public Button quizCult;

    private int HighlightIndex;
    public Text ScoreDisplayText;
    public Text ScoreDisplayPanelText;
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
        PlayerPrefs.SetString("SelectedManager", "PL");
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
                historyScoreText.text = GData.polandData.completedHist + "/" + MCQsData.questions.Length;
                geographyScoreText.text = GData.polandData.completedHist + "/" + MCQsData.questions.Length;
                cultureScoreText.text = GData.polandData.completedHist + "/" + MCQsData.questions.Length;
                foodScoreText.text = GData.polandData.completedHist + "/" + MCQsData.questions.Length;
                break;
            case 1:
                historyScoreText.text = GData.polandData.completedHistItalian + "/" + MCQsData_Italian.questions.Length;
                geographyScoreText.text = GData.polandData.completedHistItalian + "/" + MCQsData_Italian.questions.Length;
                cultureScoreText.text = GData.polandData.completedHistItalian + "/" + MCQsData_Italian.questions.Length;
                foodScoreText.text = GData.polandData.completedHistItalian + "/" + MCQsData_Italian.questions.Length;
                break;
            case 2:
                historyScoreText.text = GData.polandData.completedHistGreek + "/" + MCQsData_Greek.questions.Length;
                geographyScoreText.text = GData.polandData.completedHistGreek + "/" + MCQsData_Greek.questions.Length;
                cultureScoreText.text = GData.polandData.completedHistGreek + "/" + MCQsData_Greek.questions.Length;
                foodScoreText.text = GData.polandData.completedHistGreek + "/" + MCQsData_Greek.questions.Length;
                break;
            case 3:
                historyScoreText.text = GData.polandData.completedHistpolish + "/" + MCQsData_Polish.questions.Length;
                geographyScoreText.text = GData.polandData.completedHistpolish + "/" + MCQsData_Polish.questions.Length;
                cultureScoreText.text = GData.polandData.completedHistpolish + "/" + MCQsData_Polish.questions.Length;
                foodScoreText.text = GData.polandData.completedHistpolish + "/" + MCQsData_Polish.questions.Length;
                break;
        }

        // GData.polandData.completedHist
        // GData.polandData.completedGeo
        // GData.polandData.completedHistItalian
        // GData.polandData.completedGeoItalian
        //historyScoreText.text = PlayerPrefs.GetInt("PolandHist") + "/3";
        //geographyScoreText.text = PlayerPrefs.GetInt("PolandGeo") + "/3";
        //foodScoreText.text = PlayerPrefs.GetInt("PolandFood") + "/3";
        //cultureScoreText.text = PlayerPrefs.GetInt("PolandCult") + "/3";


        //if (PlayerPrefs.GetInt("PolandHist") >= 3)
        //{
        //    //quizHist.interactable = false;

        //    historyCompleteImage.SetActive(true);
        //}
        //if (PlayerPrefs.GetInt("PolandGeo") >= 3)
        //{
        //    //quizGeo.interactable = false;

        //    geographyCompleteImage.SetActive(true);
        //}
        //if (PlayerPrefs.GetInt("PolandFood") >= 3)
        //{
        //    //quizFood.interactable = false;

        //    foodCompleteImage.SetActive(true);
        //}
        //if (PlayerPrefs.GetInt("PolandCult") >= 3)
        //{
        //    //quizCult.interactable = false;

        //    cultureCompleteImage.SetActive(true);
        //}


        if (PlayerPrefs.GetInt("Level5") >= 4)
        {
            PlayerPrefs.SetInt("levelunlocked", 0);

            congratsPanel.SetActive(true);
            playerController.SetActive(false);

            GameManagers.score = PlayerPrefs.GetInt("Score") + 12;


            PlayerPrefs.SetInt("Score", GameManagers.score);
            PlayerPrefs.Save();

            // Report a score of 100
            // EM_GameServicesConstants.Sample_Leaderboard is the generated name constant
            // of a leaderboard named "Sample Leaderboard"
            //  GameServices.ReportScore(PlayerPrefs.GetInt("Score"), EM_GameServicesConstants.Leaderboard_Escape_Hero);

            countDown.timeRemaining = 900f;
            countDown.timerIsRunning = true;
            PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
            PlayerPrefs.Save();

            PlayerPrefs.SetInt("Level5", 0);
            PlayerPrefs.SetInt("LevelM5", 1);
            PlayerPrefs.Save();

        }
        if (PlayerPrefs.GetInt("LevelM5") == 1)
        {
            //   door4Col.isTrigger = true;

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
                historyQuizIndex = GData.polandData.completedHist;
                break;
            case 1:
                historyQuizIndex = GData.polandData.completedHistItalian;
                break;
            case 2:
                historyQuizIndex = GData.polandData.completedHistGreek;
                break;
            case 3:
                historyQuizIndex = GData.polandData.completedHistpolish;
                break;
        }

        //if (temp == historyQuizIndex)
        //{
        //    historyQuizIndex = Random.Range(0, historyQues.Length);
        //}

        Debug.Log("Quiz index: " + historyQuizIndex);
        switch (GData.selectedLanguage)
        {
            case 0:
                if (historyQuizIndex == 0)
                {
                    EnableImage(0, 0);
                }
                else if (historyQuizIndex == 2)
                {
                    EnableImage(2, 1);
                }
                else if (historyQuizIndex == 3)
                {
                    EnableImage(3, 2);
                }
                else if (historyQuizIndex == 4)
                {
                    EnableImage(4, 3);
                }
                break;
            case 1:
                if (historyQuizIndex == 0)
                {
                    EnableImage(0, 0);
                }
                else if (historyQuizIndex == 2)
                {
                    EnableImage(2, 1);
                }
                else if (historyQuizIndex == 3)
                {
                    EnableImage(3, 4);
                }
                else if (historyQuizIndex == 4)
                {
                    EnableImage(4, 3);
                }
                break;
            case 2:
                if (historyQuizIndex == 0)
                {
                    EnableImage(0, 0);
                }
                else if (historyQuizIndex == 2)
                {
                    EnableImage(2, 1);
                }
                else if (historyQuizIndex == 3)
                {
                    EnableImage(3, 5);
                }
                else if (historyQuizIndex == 4)
                {
                    EnableImage(4, 3);
                }
                break;
            case 3:
                if (historyQuizIndex == 0)
                {
                    EnableImage(0, 0);
                }
                else if (historyQuizIndex == 2)
                {
                    EnableImage(2, 1);
                }
                else if (historyQuizIndex == 3)
                {
                    EnableImage(3, 6);
                }
                else if (historyQuizIndex == 4)
                {
                    EnableImage(4, 3);
                }
                break;
        }

        historyQuestonText.text = historyQues[historyQuizIndex];

        QLength = historyQuestonText.text.Length;
        Debug.Log("Question Lenght is==" + QLength.ToString());
        if(QLength>400)
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
                explainText.text = MCQsData.Question_Explanation[historyQuizIndex];
                break;
            case 1:
                explainText.text = MCQsData_Italian.Question_Explanation[historyQuizIndex];
                break;
            case 2:
                explainText.text = MCQsData_Greek.Question_Explanation[historyQuizIndex];
                break;
            case 3:
                explainText.text = MCQsData_Polish.Question_Explanation[historyQuizIndex];
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

    private void SetHistoryOptionData()
    {

        for (int i = 0; i < MCQsData.questions.Length; i++)
        {
            historyQues = new string[MCQsData.questions.Length];
            historyQues[i] = "";

            historyAns = new int[MCQsData.questions.Length];
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
                for (int i = 0; i < MCQsData.questions.Length; i++)
                {
                    historyQues[i] = MCQsData.questions[i];
                    historyAns[i] = MCQsData.answersIndex[i];

                    histOp1[i].answer = MCQsData.Op1[i];
                    histOp2[i].answer = MCQsData.Op2[i];
                    histOp3[i].answer = MCQsData.Op3[i];
                    histOp4[i].answer = MCQsData.Op4[i];

                    //            explainText.text = MCQsData.Question_Explanation[i];

                }
                break;
            case 1:
                for (int i = 0; i < MCQsData_Italian.questions.Length; i++)
                {
                    historyQues[i] = MCQsData_Italian.questions[i];
                    historyAns[i] = MCQsData_Italian.answersIndex[i];

                    histOp1[i].answer = MCQsData_Italian.Op1[i];
                    histOp2[i].answer = MCQsData_Italian.Op2[i];
                    histOp3[i].answer = MCQsData_Italian.Op3[i];
                    histOp4[i].answer = MCQsData_Italian.Op4[i];

                    //            explainText.text = MCQsData.Question_Explanation[i];

                }
                break;
            case 2:
                for (int i = 0; i < MCQsData_Greek.questions.Length; i++)
                {
                    historyQues[i] = MCQsData_Greek.questions[i];
                    historyAns[i] = MCQsData_Greek.answersIndex[i];

                    histOp1[i].answer = MCQsData_Greek.Op1[i];
                    histOp2[i].answer = MCQsData_Greek.Op2[i];
                    histOp3[i].answer = MCQsData_Greek.Op3[i];
                    histOp4[i].answer = MCQsData_Greek.Op4[i];

                    //            explainText.text = MCQsData.Question_Explanation[i];

                }
                break;
            case 3:
                for (int i = 0; i < MCQsData_Polish.questions.Length; i++)
                {
                    historyQues[i] = MCQsData_Polish.questions[i];
                    historyAns[i] = MCQsData_Polish.answersIndex[i];

                    histOp1[i].answer = MCQsData_Polish.Op1[i];
                    histOp2[i].answer = MCQsData_Polish.Op2[i];
                    histOp3[i].answer = MCQsData_Polish.Op3[i];
                    histOp4[i].answer = MCQsData_Polish.Op4[i];

                    //            explainText.text = MCQsData.Question_Explanation[i];

                }
                break;
        }
    }

    //****************** Mcqs *************// 
    public void SetHistoryQuizDataMCQS(int index)
    {
        //onclicks added or removed
        //TickButton1.onClick.RemoveAllListeners();
        //TickButton1.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[0], MCQS_KEY, TickButton1));

        //TickButton2.onClick.RemoveAllListeners();
        //TickButton2.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[1], MCQS_KEY, TickButton2));

        //TickButton3.onClick.RemoveAllListeners();
        //TickButton3.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[2], MCQS_KEY, TickButton3));

        //TickButton4.onClick.RemoveAllListeners();
        //TickButton4.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[3], MCQS_KEY, TickButton4));

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

        if (historyQuizIndex == 0)
        {
            Debug.Log("btn");
            infoBtn.GetComponent<Button>().onClick.RemoveAllListeners();
            infoBtn.GetComponent<Button>().onClick.AddListener(() => infoBtnClick(0));

            infoBtn.SetActive(true);
        }
        if (historyQuizIndex == 2)
        {
            infoBtn.GetComponent<Button>().onClick.RemoveAllListeners();
            infoBtn.GetComponent<Button>().onClick.AddListener(() => infoBtnClick(1));

            infoBtn.SetActive(true);
        }
        if (historyQuizIndex == 3)
        {
            infoBtn.GetComponent<Button>().onClick.RemoveAllListeners();
            infoBtn.GetComponent<Button>().onClick.AddListener(() => infoBtnClick(2));

            infoBtn.SetActive(true);
        }

        historyQuestonText.text = historyQues[historyQuizIndex];

        historyOptionTexts[0].text = histOp1[historyQuizIndex].answer;
        historyOptionTexts[1].text = histOp2[historyQuizIndex].answer;
        historyOptionTexts[2].text = histOp3[historyQuizIndex].answer;
        historyOptionTexts[3].text = histOp4[historyQuizIndex].answer;


        switch (GData.selectedLanguage)
        {
            case 0:
                explainText.text = MCQsData.Question_Explanation[historyQuizIndex];
                break;

            case 1:
                explainText.text = MCQsData_Italian.Question_Explanation[historyQuizIndex];
                break;
            case 2:
                explainText.text = MCQsData_Greek.Question_Explanation[historyQuizIndex];
                break;
            case 3:
                explainText.text = MCQsData_Polish.Question_Explanation[historyQuizIndex];
                break;
        }

        for (int i = 0; i < 4; i++)
        {
            if ((HistoryAnsMcqs[historyQuizIndex].Index) == 0)
            {
                TickButton1.GetComponent<Answer>().iscorrect = true;
            }
            if ((HistoryAnsMcqs[historyQuizIndex].Index) == 1)
            {
                TickButton2.GetComponent<Answer>().iscorrect = true;
            }
            if ((HistoryAnsMcqs[historyQuizIndex].Index) == 2)
            {
                TickButton3.GetComponent<Answer>().iscorrect = true;
            }
            if ((HistoryAnsMcqs[historyQuizIndex].Index) == 3)
            {
                TickButton4.GetComponent<Answer>().iscorrect = true;
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

        for (int i = 0; i < 4; i++)
        {
            historyQues = new string[4];
            historyQues[i] = "";

            historyAns = new int[4];
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
                for (int i = 0; i < 4; i++)
                {
                    historyQues[i] = MCQsData.questions[i];
                    HistoryAnsMcqs[i].Index = MCQsData.answersIndex[i];

                    histOp1[i].answer = MCQsData.Op1[i];
                    histOp2[i].answer = MCQsData.Op2[i];
                    histOp3[i].answer = MCQsData.Op3[i];
                    histOp4[i].answer = MCQsData.Op4[i];
                }
                break;
            case 1:
                for (int i = 0; i < 4; i++)
                {
                    historyQues[i] = MCQsData_Italian.questions[i];
                    HistoryAnsMcqs[i].Index = MCQsData_Italian.answersIndex[i];

                    histOp1[i].answer = MCQsData_Italian.Op1[i];
                    histOp2[i].answer = MCQsData_Italian.Op2[i];
                    histOp3[i].answer = MCQsData_Italian.Op3[i];
                    histOp4[i].answer = MCQsData_Italian.Op4[i];
                }
                break;
            case 2:
                for (int i = 0; i < 4; i++)
                {
                    historyQues[i] = MCQsData_Greek.questions[i];
                    HistoryAnsMcqs[i].Index = MCQsData_Greek.answersIndex[i];

                    histOp1[i].answer = MCQsData_Greek.Op1[i];
                    histOp2[i].answer = MCQsData_Greek.Op2[i];
                    histOp3[i].answer = MCQsData_Greek.Op3[i];
                    histOp4[i].answer = MCQsData_Greek.Op4[i];
                }
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    historyQues[i] = MCQsData_Polish.questions[i];
                    HistoryAnsMcqs[i].Index = MCQsData_Polish.answersIndex[i];

                    histOp1[i].answer = MCQsData_Polish.Op1[i];
                    histOp2[i].answer = MCQsData_Polish.Op2[i];
                    histOp3[i].answer = MCQsData_Polish.Op3[i];
                    histOp4[i].answer = MCQsData_Polish.Op4[i];
                }
                break;
        }
    }

    #endregion

    #region Geography Quiz Data
    //****************** True False *************// 
    public void SetGeographyQuizData(int index)
    {
        //onclicks added or removed
        //TickButton1.onClick.RemoveAllListeners();
        //TickButton1.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[0], TF_KEY, TickButton1));

        //TickButton2.onClick.RemoveAllListeners();
        //TickButton2.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[1], TF_KEY, TickButton2));

        //ResetButton.onClick.RemoveAllListeners();
        //ResetButton.onClick.AddListener(() => ResetQuestionaPanel(TF_KEY));

        //TickButton3.gameObject.SetActive(false);

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
                explainText.text = MCQsData.Question_Explanation[geographyQuizIndex + 4];
                break;

            case 1:
                explainText.text = MCQsData_Italian.Question_Explanation[geographyQuizIndex + 4];
                break;
            case 2:
                explainText.text = MCQsData_Greek.Question_Explanation[geographyQuizIndex + 4];
                break;
            case 3:
                explainText.text = MCQsData_Polish.Question_Explanation[geographyQuizIndex + 4];
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
        for (int i = 0; i < 4; i++)
        {
            geographyQues = new string[4];
            geographyQues[i] = "";

            geographyAns = new int[4];
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
                for (int i = 0; i < 4; i++)
                {
                    geographyQues[i] = MCQsData.questions[i + 4];
                    geographyAns[i] = MCQsData.answersIndex[i + 4];

                    geogOp1[i].answer = MCQsData.Op1[i + 4];
                    geogOp2[i].answer = MCQsData.Op2[i + 4];
                    geogOp3[i].answer = MCQsData.Op3[i + 4];
                    geogOp4[i].answer = MCQsData.Op4[i + 4];

                    //    explainText.text = MCQsData.Question_Explanation[i + 4];

                }
                break;
            case 1:
                for (int i = 0; i < 4; i++)
                {
                    geographyQues[i] = MCQsData_Italian.questions[i + 4];
                    geographyAns[i] = MCQsData_Italian.answersIndex[i + 4];

                    geogOp1[i].answer = MCQsData_Italian.Op1[i + 4];
                    geogOp2[i].answer = MCQsData_Italian.Op2[i + 4];
                    geogOp3[i].answer = MCQsData_Italian.Op3[i + 4];
                    geogOp4[i].answer = MCQsData_Italian.Op4[i + 4];

                    //    explainText.text = MCQsData.Question_Explanation[i + 4];

                }
                break;
            case 2:
                for (int i = 0; i < 4; i++)
                {
                    geographyQues[i] = MCQsData_Greek.questions[i + 4];
                    geographyAns[i] = MCQsData_Greek.answersIndex[i + 4];

                    geogOp1[i].answer = MCQsData_Greek.Op1[i + 4];
                    geogOp2[i].answer = MCQsData_Greek.Op2[i + 4];
                    geogOp3[i].answer = MCQsData_Greek.Op3[i + 4];
                    geogOp4[i].answer = MCQsData_Greek.Op4[i + 4];

                    //    explainText.text = MCQsData.Question_Explanation[i + 4];

                }
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    geographyQues[i] = MCQsData_Polish.questions[i + 4];
                    geographyAns[i] = MCQsData_Polish.answersIndex[i + 4];

                    geogOp1[i].answer = MCQsData_Polish.Op1[i + 4];
                    geogOp2[i].answer = MCQsData_Polish.Op2[i + 4];
                    geogOp3[i].answer = MCQsData_Polish.Op3[i + 4];
                    geogOp4[i].answer = MCQsData_Polish.Op4[i + 4];

                    //    explainText.text = MCQsData.Question_Explanation[i + 4];

                }
                break;
        }
    }

    //****************** Mcqs *************// 

    public void SetGeographyQuizDataMCQS(int index)
    {
        //onclicks added or removed
        //TickButton1.onClick.RemoveAllListeners();
        //TickButton1.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[0], MCQS_KEY, TickButton1));

        //TickButton2.onClick.RemoveAllListeners();
        //TickButton2.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[1], MCQS_KEY, TickButton2));

        //TickButton3.onClick.RemoveAllListeners();
        //TickButton3.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[2], MCQS_KEY, TickButton3));

        //TickButton4.onClick.RemoveAllListeners();
        //TickButton4.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[3], MCQS_KEY, TickButton4));

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


        if (geographyQuizIndex == 0)
        {
            infoBtn.GetComponent<Button>().onClick.RemoveAllListeners();
            infoBtn.GetComponent<Button>().onClick.AddListener(() => infoBtnClick(3));

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
                explainText.text = MCQsData.Question_Explanation[geographyQuizIndex + 4];
                break;
            case 1:
                explainText.text = MCQsData_Italian.Question_Explanation[geographyQuizIndex + 4];
                break;
            case 2:
                explainText.text = MCQsData_Greek.Question_Explanation[geographyQuizIndex + 4];
                break;
            case 3:
                explainText.text = MCQsData_Polish.Question_Explanation[geographyQuizIndex + 4];
                break;
        }

        for (int i = 0; i < 4; i++)
        {
            if ((geographyAnsMcqs[geographyQuizIndex].Index) == 0)
            {
                TickButton1.GetComponent<Answer>().iscorrect = true;
            }
            if ((geographyAnsMcqs[geographyQuizIndex].Index) == 1)
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
        for (int i = 0; i < 4; i++)
        {
            geographyQues = new string[4];
            geographyQues[i] = "";

            geographyAns = new int[4];
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
                for (int i = 0; i < 4; i++)
                {
                    geographyQues[i] = MCQsData.questions[i + 4];
                    geographyAnsMcqs[i].Index = MCQsData.answersIndex[i + 4];

                    geogOp1[i].answer = MCQsData.Op1[i + 4];
                    geogOp2[i].answer = MCQsData.Op2[i + 4];
                    geogOp3[i].answer = MCQsData.Op3[i + 4];
                    geogOp4[i].answer = MCQsData.Op4[i + 4];
                }
                break;
            case 1:
                for (int i = 0; i < 4; i++)
                {
                    geographyQues[i] = MCQsData_Italian.questions[i + 4];
                    geographyAnsMcqs[i].Index = MCQsData_Italian.answersIndex[i + 4];

                    geogOp1[i].answer = MCQsData_Italian.Op1[i + 4];
                    geogOp2[i].answer = MCQsData_Italian.Op2[i + 4];
                    geogOp3[i].answer = MCQsData_Italian.Op3[i + 4];
                    geogOp4[i].answer = MCQsData_Italian.Op4[i + 4];
                }
                break;
            case 2:
                for (int i = 0; i < 4; i++)
                {
                    geographyQues[i] = MCQsData_Greek.questions[i + 4];
                    geographyAnsMcqs[i].Index = MCQsData_Greek.answersIndex[i + 4];

                    geogOp1[i].answer = MCQsData_Greek.Op1[i + 4];
                    geogOp2[i].answer = MCQsData_Greek.Op2[i + 4];
                    geogOp3[i].answer = MCQsData_Greek.Op3[i + 4];
                    geogOp4[i].answer = MCQsData_Greek.Op4[i + 4];
                }
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    geographyQues[i] = MCQsData_Polish.questions[i + 4];
                    geographyAnsMcqs[i].Index = MCQsData_Polish.answersIndex[i + 4];

                    geogOp1[i].answer = MCQsData_Polish.Op1[i + 4];
                    geogOp2[i].answer = MCQsData_Polish.Op2[i + 4];
                    geogOp3[i].answer = MCQsData_Polish.Op3[i + 4];
                    geogOp4[i].answer = MCQsData_Polish.Op4[i + 4];
                }
                break;
        }
    }

    #endregion

    #region Food Quiz Data
    //****************** True False *************// 
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
                explainText.text = MCQsData.Question_Explanation[foodQuizIndex + 8];
                break;
            case 1:
                explainText.text = MCQsData_Italian.Question_Explanation[foodQuizIndex + 8];
                break;
            case 2:
                explainText.text = MCQsData_Greek.Question_Explanation[foodQuizIndex + 8];
                break;
            case 3:
                explainText.text = MCQsData_Polish.Question_Explanation[foodQuizIndex + 8];
                break;
        }

        //setting style
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


        switch (GData.selectedLanguage)
        {
            case 0:
                for (int i = 0; i < 4; i++)
                {
                    foodQues[i] = MCQsData.questions[i + 8];
                    foodAns[i] = MCQsData.answersIndex[i + 8];

                    foodOp1[i].answer = MCQsData.Op1[i + 8];
                    foodOp2[i].answer = MCQsData.Op2[i + 8];
                    foodOp3[i].answer = MCQsData.Op3[i + 8];
                    foodOp4[i].answer = MCQsData.Op4[i + 8];

                    //   explainText.text = MCQsData.Question_Explanation[i + 8];

                }
                break;
            case 1:
                for (int i = 0; i < 4; i++)
                {
                    foodQues[i] = MCQsData_Italian.questions[i + 8];
                    foodAns[i] = MCQsData_Italian.answersIndex[i + 8];

                    foodOp1[i].answer = MCQsData_Italian.Op1[i + 8];
                    foodOp2[i].answer = MCQsData_Italian.Op2[i + 8];
                    foodOp3[i].answer = MCQsData_Italian.Op3[i + 8];
                    foodOp4[i].answer = MCQsData_Italian.Op4[i + 8];

                    //   explainText.text = MCQsData.Question_Explanation[i + 8];

                }
                break;
            case 2:
                for (int i = 0; i < 4; i++)
                {
                    foodQues[i] = MCQsData_Greek.questions[i + 8];
                    foodAns[i] = MCQsData_Greek.answersIndex[i + 8];

                    foodOp1[i].answer = MCQsData_Greek.Op1[i + 8];
                    foodOp2[i].answer = MCQsData_Greek.Op2[i + 8];
                    foodOp3[i].answer = MCQsData_Greek.Op3[i + 8];
                    foodOp4[i].answer = MCQsData_Greek.Op4[i + 8];

                    //   explainText.text = MCQsData.Question_Explanation[i + 8];

                }
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    foodQues[i] = MCQsData_Polish.questions[i + 8];
                    foodAns[i] = MCQsData_Polish.answersIndex[i + 8];

                    foodOp1[i].answer = MCQsData_Polish.Op1[i + 8];
                    foodOp2[i].answer = MCQsData_Polish.Op2[i + 8];
                    foodOp3[i].answer = MCQsData_Polish.Op3[i + 8];
                    foodOp4[i].answer = MCQsData_Polish.Op4[i + 8];

                    //   explainText.text = MCQsData.Question_Explanation[i + 8];

                }
                break;
        }
    }

    //****************** Mcqs *************// 

    public void SetFoodQuizDataMCQS(int index)
    {
        //onclicks added or removed
        //TickButton1.onClick.RemoveAllListeners();
        //TickButton1.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[0], MCQS_KEY, TickButton1));

        //TickButton2.onClick.RemoveAllListeners();
        //TickButton2.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[1], MCQS_KEY, TickButton2));

        //TickButton3.onClick.RemoveAllListeners();
        //TickButton3.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[2], MCQS_KEY, TickButton3));

        //TickButton4.onClick.RemoveAllListeners();
        //TickButton4.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[3], MCQS_KEY, TickButton4));

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
        switch (GData.selectedLanguage)
        {
            case 0:
                explainText.text = MCQsData.Question_Explanation[foodQuizIndex + 8];
                break;
            case 1:
                explainText.text = MCQsData_Italian.Question_Explanation[foodQuizIndex + 8];
                break;
            case 2:
                explainText.text = MCQsData_Greek.Question_Explanation[foodQuizIndex + 8];
                break;
            case 3:
                explainText.text = MCQsData_Polish.Question_Explanation[foodQuizIndex + 8];
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



        switch (GData.selectedLanguage)
        {
            case 0:
                for (int i = 0; i < 4; i++)
                {
                    foodQues[i] = MCQsData.questions[i + 8];
                    //foodAns[i] = MCQSData.answersIndex[i];

                    foodAnsMcqs[i].Index = MCQsData.answersIndex[i + 8];

                    foodOp1[i].answer = MCQsData.Op1[i + 8];
                    foodOp2[i].answer = MCQsData.Op2[i + 8];
                    foodOp3[i].answer = MCQsData.Op3[i + 8];
                    foodOp4[i].answer = MCQsData.Op4[i + 8];

                    //   explainText.text = MCQsData.Question_Explanation[i + 8];

                }
                break;
            case 1:
                for (int i = 0; i < 4; i++)
                {
                    foodQues[i] = MCQsData_Italian.questions[i + 8];
                    //foodAns[i] = MCQSData.answersIndex[i];

                    foodAnsMcqs[i].Index = MCQsData_Italian.answersIndex[i + 8];

                    foodOp1[i].answer = MCQsData_Italian.Op1[i + 8];
                    foodOp2[i].answer = MCQsData_Italian.Op2[i + 8];
                    foodOp3[i].answer = MCQsData_Italian.Op3[i + 8];
                    foodOp4[i].answer = MCQsData_Italian.Op4[i + 8];

                    //   explainText.text = MCQsData.Question_Explanation[i + 8];

                }
                break;
            case 2:
                for (int i = 0; i < 4; i++)
                {
                    foodQues[i] = MCQsData_Greek.questions[i + 8];
                    //foodAns[i] = MCQSData.answersIndex[i];

                    foodAnsMcqs[i].Index = MCQsData_Greek.answersIndex[i + 8];

                    foodOp1[i].answer = MCQsData_Greek.Op1[i + 8];
                    foodOp2[i].answer = MCQsData_Greek.Op2[i + 8];
                    foodOp3[i].answer = MCQsData_Greek.Op3[i + 8];
                    foodOp4[i].answer = MCQsData_Greek.Op4[i + 8];

                    //   explainText.text = MCQsData.Question_Explanation[i + 8];

                }
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    foodQues[i] = MCQsData_Polish.questions[i + 8];
                    //foodAns[i] = MCQSData.answersIndex[i];

                    foodAnsMcqs[i].Index = MCQsData_Polish.answersIndex[i + 8];

                    foodOp1[i].answer = MCQsData_Polish.Op1[i + 8];
                    foodOp2[i].answer = MCQsData_Polish.Op2[i + 8];
                    foodOp3[i].answer = MCQsData_Polish.Op3[i + 8];
                    foodOp4[i].answer = MCQsData_Polish.Op4[i + 8];

                    //   explainText.text = MCQsData.Question_Explanation[i + 8];

                }
                break;
        }
    }

    #endregion

    #region Culture Quiz Data

    //****************** True False *************// 
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
                explainText.text = MCQsData.Question_Explanation[cultureQuizIndex + 12];
                break;
            case 1:
                explainText.text = MCQsData_Italian.Question_Explanation[cultureQuizIndex + 12];
                break;
            case 2:
                explainText.text = MCQsData_Greek.Question_Explanation[cultureQuizIndex + 12];
                break;
            case 3:
                explainText.text = MCQsData_Polish.Question_Explanation[cultureQuizIndex + 12];
                break;
        }
        //setting style
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
        else if (cultureAns[cultureQuizIndex] == 3)
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
        for (int i = 0; i < 3; i++)
        {
            cultureQues = new string[3];
            cultureQues[i] = "";

            cultureAns = new int[3];
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
        switch (GData.selectedLanguage)
        {
            case 0:
                for (int i = 0; i < 3; i++)
                {
                    cultureQues[i] = MCQsData.questions[i + 12];
                    cultureAns[i] = MCQsData.answersIndex[i + 12];

                    culOp1[i].answer = MCQsData.Op1[i + 12];
                    culOp2[i].answer = MCQsData.Op2[i + 12];
                    culOp3[i].answer = MCQsData.Op3[i + 12];
                    culOp4[i].answer = MCQsData.Op4[i + 12];
                }
                break;
            case 1:
                for (int i = 0; i < 3; i++)
                {
                    cultureQues[i] = MCQsData_Italian.questions[i + 12];
                    cultureAns[i] = MCQsData_Italian.answersIndex[i + 12];

                    culOp1[i].answer = MCQsData_Italian.Op1[i + 12];
                    culOp2[i].answer = MCQsData_Italian.Op2[i + 12];
                    culOp3[i].answer = MCQsData_Italian.Op3[i + 12];
                    culOp4[i].answer = MCQsData_Italian.Op4[i + 12];

                    // explainText.text = MCQsData.Question_Explanation[i + 12];

                }
                break;
            case 2:
                for (int i = 0; i < 3; i++)
                {
                    cultureQues[i] = MCQsData_Greek.questions[i + 12];
                    cultureAns[i] = MCQsData_Greek.answersIndex[i + 12];

                    culOp1[i].answer = MCQsData_Greek.Op1[i + 12];
                    culOp2[i].answer = MCQsData_Greek.Op2[i + 12];
                    culOp3[i].answer = MCQsData_Greek.Op3[i + 12];
                    culOp4[i].answer = MCQsData_Greek.Op4[i + 12];

                    // explainText.text = MCQsData.Question_Explanation[i + 12];

                }
                break;
            case 3:
                for (int i = 0; i < 3; i++)
                {
                    cultureQues[i] = MCQsData_Polish.questions[i + 12];
                    cultureAns[i] = MCQsData_Polish.answersIndex[i + 12];

                    culOp1[i].answer = MCQsData_Polish.Op1[i + 12];
                    culOp2[i].answer = MCQsData_Polish.Op2[i + 12];
                    culOp3[i].answer = MCQsData_Polish.Op3[i + 12];
                    culOp4[i].answer = MCQsData_Polish.Op4[i + 12];

                    // explainText.text = MCQsData.Question_Explanation[i + 12];

                }
                break;
        }
    }

    //****************** Mcqs *************// 

    public void SetCultureQuizDataMCQS(int index)
    {
        //onclicks added or removed
        //TickButton1.onClick.RemoveAllListeners();
        //TickButton1.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[0], MCQS_KEY, TickButton1));

        //TickButton2.onClick.RemoveAllListeners();
        //TickButton2.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[1], MCQS_KEY, TickButton2));

        //TickButton3.onClick.RemoveAllListeners();
        //TickButton3.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[2], MCQS_KEY, TickButton3));

        //TickButton4.onClick.RemoveAllListeners();
        //TickButton4.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[3], MCQS_KEY, TickButton4));

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

        switch (GData.selectedLanguage)
        {
            case 0:
                explainText.text = MCQsData_Italian.Question_Explanation[cultureQuizIndex + 12];
                break;
            case 1:
                explainText.text = MCQsData_Italian.Question_Explanation[cultureQuizIndex + 12];
                break;
            case 2:
                explainText.text = MCQsData_Greek.Question_Explanation[cultureQuizIndex + 12];
                break;
            case 3:
                explainText.text = MCQsData_Polish.Question_Explanation[cultureQuizIndex + 12];
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
        for (int i = 0; i < 3; i++)
        {
            cultureQues = new string[3];
            cultureQues[i] = "";

            cultureAns = new int[3];
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



        switch (GData.selectedLanguage)
        {
            case 0:
                for (int i = 0; i < 3; i++)
                {
                    cultureQues[i] = MCQsData.questions[i + 12];
                    cultureAnsMcqs[i].Index = MCQsData.answersIndex[i + 12];

                    culOp1[i].answer = MCQsData.Op1[i + 12];
                    culOp2[i].answer = MCQsData.Op2[i + 12];
                    culOp3[i].answer = MCQsData.Op3[i + 12];
                    culOp4[i].answer = MCQsData.Op4[i + 12];
                }
                break;
            case 1:
                for (int i = 0; i < 3; i++)
                {
                    cultureQues[i] = MCQsData_Italian.questions[i + 12];
                    cultureAnsMcqs[i].Index = MCQsData_Italian.answersIndex[i + 12];

                    culOp1[i].answer = MCQsData_Italian.Op1[i + 12];
                    culOp2[i].answer = MCQsData_Italian.Op2[i + 12];
                    culOp3[i].answer = MCQsData_Italian.Op3[i + 12];
                    culOp4[i].answer = MCQsData_Italian.Op4[i + 12];
                }
                break;
            case 2:
                for (int i = 0; i < 3; i++)
                {
                    cultureQues[i] = MCQsData_Greek.questions[i + 12];
                    cultureAnsMcqs[i].Index = MCQsData_Greek.answersIndex[i + 12];

                    culOp1[i].answer = MCQsData_Greek.Op1[i + 12];
                    culOp2[i].answer = MCQsData_Greek.Op2[i + 12];
                    culOp3[i].answer = MCQsData_Greek.Op3[i + 12];
                    culOp4[i].answer = MCQsData_Greek.Op4[i + 12];
                }
                break;
            case 3:
                for (int i = 0; i < 3; i++)
                {
                    cultureQues[i] = MCQsData_Polish.questions[i + 12];
                    cultureAnsMcqs[i].Index = MCQsData_Polish.answersIndex[i + 12];

                    culOp1[i].answer = MCQsData_Polish.Op1[i + 12];
                    culOp2[i].answer = MCQsData_Polish.Op2[i + 12];
                    culOp3[i].answer = MCQsData_Polish.Op3[i + 12];
                    culOp4[i].answer = MCQsData_Polish.Op4[i + 12];
                }
                
                break;
        }
    }

    #endregion




    #region Common Functions

    public class Option
    {
        public string answer;
        public string tag;
    }
    private void EnableImage(int quizIndex, int imageIndex)
    {
        
        {
            infoBtn.GetComponent<Button>().onClick.RemoveAllListeners();
            infoBtn.GetComponent<Button>().onClick.AddListener(() => infoBtnClick(imageIndex));
            infoBtn.SetActive(true);
        }
    }
    public void infoBtnClick(int index)
    {
        scrollImages.SetActive(true);
        quizImages[index].SetActive(true);
        closeScrollBtn.SetActive(true);
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
        if (PlayerPrefs.GetInt("levelcurrent") == 5)
        {
            if (selectedCategory == 1)
            {
                switch (GData.selectedLanguage)
                {
                    case 0:
                        if (GData.polandData.completedHist < MCQsData.questions.Length)
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
                        if (GData.polandData.completedHistItalian < MCQsData_Italian.questions.Length)
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
                        if (GData.polandData.completedHistGreek < MCQsData_Greek.questions.Length)
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
                        if (GData.polandData.completedHistpolish < MCQsData_Polish.questions.Length)
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
        }

    }

    public void AnswerBtnClick(Text text)
    {
        //if (Category.Equals(TF_KEY))
        //{
        TickButton1.interactable = false;
        TickButton2.interactable = false;
        TickButton3.interactable = false;
        TickButton4.interactable = false;
        if (PlayerPrefs.GetInt("levelcurrent") == 5)
        {
            Debug.Log("In Poland Answer Click : " + selectedCategory);

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
                    if (GData.polandData.completedHist < MCQsData.questions.Length)
                    {
                        GData.polandData.completedHist++;
                        if (GData.polandData.completedHist < MCQsData.questions.Length)
                        {
                            SetHistoryQuizData(1);
                        }
                        else if (GData.polandData.completedHist == MCQsData.questions.Length)
                        {
                            if (GameManager.Instance.isMultiplayer)
                            {
                                if (GameManager.Instance.SelectedPlayer == 0)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    MulticongratsPanel.SetActive(true);
                                    GData.polandData.completedHist = 0;
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
                                if (GData.RightAnswer >= 8)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    congratsPanel.SetActive(true);
                                  //  congratsPanelText.text = "Congratulations! You have unlocked all Rooms.";
                                   
                                    frthRoomScore.text = (GData.RightAnswer * 5).ToString();
                                    GData.ForthLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                    congratsPanelTotalScore.text = (GData.FirstLevelScore + GData.SceondLevelScore + GData.ThirdtLevelScore + GData.ForthLevelScore).ToString();
                                    fstRoomScore.text = GData.FirstLevelScore.ToString();
                                    scndRoomScore.text = GData.SceondLevelScore.ToString();
                                    ThrdRoomScore.text = GData.ThirdtLevelScore.ToString();
                                    Background.SetActive(true);
                                    GData.polandData.completedHist = 0;
                                    GData.RightAnswer = 0;
                                    GData.roomLockedIndex++;
                                }
                                else
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                                    GData.polandData.completedHist = 0;
                                    levelFailPanel.SetActive(true);
                                    GData.RightAnswer = 0;
                                }
                            }
                        }
                    }

                    break;

                case 1:
                    if (GData.polandData.completedHistItalian < MCQsData_Italian.questions.Length)
                    {
                        GData.polandData.completedHistItalian++;
                        if (GData.polandData.completedHistItalian < MCQsData_Italian.questions.Length)
                        {
                            SetHistoryQuizData(1);
                        }
                        else if (GData.polandData.completedHistItalian == MCQsData_Italian.questions.Length)
                        {
                            if (GameManager.Instance.isMultiplayer)
                            {
                                if (GameManager.Instance.SelectedPlayer == 0)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    MulticongratsPanel.SetActive(true);
                                    GData.polandData.completedHistItalian = 0;
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
                                if (GData.RightAnswer >= 8)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    congratsPanel.SetActive(true);
                                    //  congratsPanelText.text = "Congratulations! You have unlocked all Rooms.";
                                    frthRoomScore.text = (GData.RightAnswer * 5).ToString();
                                    GData.ForthLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                    congratsPanelTotalScore.text = (GData.FirstLevelScore + GData.SceondLevelScore + GData.ThirdtLevelScore + GData.ForthLevelScore).ToString();
                                    fstRoomScore.text = GData.FirstLevelScore.ToString();
                                    scndRoomScore.text = GData.SceondLevelScore.ToString();
                                    ThrdRoomScore.text = GData.ThirdtLevelScore.ToString();
                                    Background.SetActive(true);
                                    GData.polandData.completedHistItalian = 0;
                                    GData.RightAnswer = 0;
                                    GData.roomLockedIndex++;
                                }
                                else
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    GData.polandData.completedHistItalian = 0;

                                    ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                                    levelFailPanel.SetActive(true);
                                    GData.RightAnswer = 0;
                                }
                            }
                        }
                    }
                    break;
                case 2:
                    if (GData.polandData.completedHistGreek < MCQsData_Greek.questions.Length)
                    {
                        GData.polandData.completedHistGreek++;
                        if (GData.polandData.completedHistGreek < MCQsData_Greek.questions.Length)
                        {
                            SetHistoryQuizData(1);
                        }
                        else if (GData.polandData.completedHistGreek == MCQsData_Greek.questions.Length)
                        {
                            if (GameManager.Instance.isMultiplayer)
                            {
                                if (GameManager.Instance.SelectedPlayer == 0)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    MulticongratsPanel.SetActive(true);
                                    GData.polandData.completedHistGreek = 0;
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
                                if (GData.RightAnswer >= 8)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    congratsPanel.SetActive(true);
                                    //  congratsPanelText.text = "Congratulations! You have unlocked all Rooms.";
                                    frthRoomScore.text = (GData.RightAnswer * 5).ToString();
                                    GData.ForthLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                    congratsPanelTotalScore.text = (GData.FirstLevelScore + GData.SceondLevelScore + GData.ThirdtLevelScore + GData.ForthLevelScore).ToString();
                                    fstRoomScore.text = GData.FirstLevelScore.ToString();
                                    scndRoomScore.text = GData.SceondLevelScore.ToString();
                                    ThrdRoomScore.text = GData.ThirdtLevelScore.ToString();
                                    Background.SetActive(true);
                                    GData.polandData.completedHistGreek = 0;
                                    GData.RightAnswer = 0;
                                    GData.roomLockedIndex++;
                                }
                                else
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    GData.polandData.completedHistGreek = 0;

                                    ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                                    levelFailPanel.SetActive(true);
                                    GData.RightAnswer = 0;
                                }
                            }
                        }
                    }
                    break;
                case 3:
                    if (GData.polandData.completedHistpolish < MCQsData_Polish.questions.Length)
                    {
                        GData.polandData.completedHistpolish++;
                        if (GData.polandData.completedHistpolish < MCQsData_Polish.questions.Length)
                        {
                            SetHistoryQuizData(1);
                        }
                        else if (GData.polandData.completedHistpolish == MCQsData_Polish.questions.Length)
                        {
                            if (GameManager.Instance.isMultiplayer)
                            {
                                if (GameManager.Instance.SelectedPlayer == 0)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    MulticongratsPanel.SetActive(true);
                                    GData.polandData.completedHistpolish = 0;
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
                                if (GData.RightAnswer >= 8)
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    congratsPanel.SetActive(true);
                                    //  congratsPanelText.text = "Congratulations! You have unlocked all Rooms.";
                                    frthRoomScore.text = (GData.RightAnswer * 5).ToString();
                                    GData.ForthLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                    congratsPanelTotalScore.text = (GData.FirstLevelScore + GData.SceondLevelScore + GData.ThirdtLevelScore + GData.ForthLevelScore).ToString();
                                    fstRoomScore.text = GData.FirstLevelScore.ToString();
                                    scndRoomScore.text = GData.SceondLevelScore.ToString();
                                    ThrdRoomScore.text = GData.ThirdtLevelScore.ToString();
                                    Background.SetActive(true);
                                    GData.polandData.completedHistpolish = 0;
                                    GData.RightAnswer = 0;
                                    GData.roomLockedIndex++;
                                }
                                else
                                {
                                    quizPanel.SetActive(false);
                                    quizobjecthandle();
                                    GData.polandData.completedHistpolish = 0;

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
                        if (GData.polandData.completedHist < MCQsData.questions.Length)
                        {
                            GData.polandData.completedHist++;
                            if (GData.polandData.completedHist < MCQsData.questions.Length)
                            {
                                SetHistoryQuizData(1);
                            }
                            else if (GData.polandData.completedHist == MCQsData.questions.Length)
                            {
                                if (GameManager.Instance.isMultiplayer)
                                {
                                    if (GameManager.Instance.SelectedPlayer == 0)
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        MulticongratsPanel.SetActive(true);
                                        GData.polandData.completedHist = 0;
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
                                    if (GData.RightAnswer >= 8)
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        congratsPanel.SetActive(true);
                                        // congratsPanelText.text = "Congratulations! You have unlocked all Rooms.";
                                        frthRoomScore.text = (GData.RightAnswer * 5).ToString();
                                        GData.ForthLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                        congratsPanelTotalScore.text = (GData.FirstLevelScore + GData.SceondLevelScore + GData.ThirdtLevelScore + GData.ForthLevelScore).ToString();
                                        fstRoomScore.text = GData.FirstLevelScore.ToString();
                                        scndRoomScore.text = GData.SceondLevelScore.ToString();
                                        ThrdRoomScore.text = GData.ThirdtLevelScore.ToString();
                                        Background.SetActive(true);
                                        GData.polandData.completedHist = 0;
                                        GData.RightAnswer = 0;
                                        GData.roomLockedIndex++;
                                    }
                                    else
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        GData.polandData.completedHist = 0;

                                        ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                                        levelFailPanel.SetActive(true);
                                        GData.RightAnswer = 0;
                                    }
                                }
                            }
                        }

                        break;

                    case 1:
                        if (GData.polandData.completedHistItalian < MCQsData_Italian.questions.Length)
                        {
                            GData.polandData.completedHistItalian++;
                            if (GData.polandData.completedHistItalian < MCQsData_Italian.questions.Length)
                            {
                                SetHistoryQuizData(1);
                            }
                            else if (GData.polandData.completedHistItalian == MCQsData_Italian.questions.Length)
                            {
                                if (GameManager.Instance.isMultiplayer)
                                {
                                    if (GameManager.Instance.SelectedPlayer == 0)
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        MulticongratsPanel.SetActive(true);
                                        GData.polandData.completedHistItalian = 0;

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
                                    if (GData.RightAnswer >= 8)
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        congratsPanel.SetActive(true);
                                        // congratsPanelText.text = "Congratulations! You have unlocked all Rooms.";
                                        frthRoomScore.text = (GData.RightAnswer * 5).ToString();
                                        GData.ForthLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                        congratsPanelTotalScore.text = (GData.FirstLevelScore + GData.SceondLevelScore + GData.ThirdtLevelScore + GData.ForthLevelScore).ToString();
                                        fstRoomScore.text = GData.FirstLevelScore.ToString();
                                        scndRoomScore.text = GData.SceondLevelScore.ToString();
                                        ThrdRoomScore.text = GData.ThirdtLevelScore.ToString();
                                        Background.SetActive(true);
                                        GData.polandData.completedHistItalian = 0;
                                        GData.RightAnswer = 0;
                                        GData.roomLockedIndex++;
                                    }
                                    else
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        GData.polandData.completedHistItalian = 0;

                                        ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                                        levelFailPanel.SetActive(true);
                                        GData.RightAnswer = 0;

                                    }
                                }
                            }
                        }
                        break;
                    case 2:
                        if (GData.polandData.completedHistGreek < MCQsData_Greek.questions.Length)
                        {
                            GData.polandData.completedHistGreek++;
                            if (GData.polandData.completedHistGreek < MCQsData_Greek.questions.Length)
                            {
                                SetHistoryQuizData(1);
                            }
                            else if (GData.polandData.completedHistGreek == MCQsData_Greek.questions.Length)
                            {
                                if (GameManager.Instance.isMultiplayer)
                                {
                                    if (GameManager.Instance.SelectedPlayer == 0)
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        MulticongratsPanel.SetActive(true);
                                        GData.polandData.completedHistGreek = 0;

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
                                    if (GData.RightAnswer >= 8)
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        congratsPanel.SetActive(true);
                                        // congratsPanelText.text = "Congratulations! You have unlocked all Rooms.";
                                        frthRoomScore.text = (GData.RightAnswer * 5).ToString();
                                        GData.ForthLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                        congratsPanelTotalScore.text = (GData.FirstLevelScore + GData.SceondLevelScore + GData.ThirdtLevelScore + GData.ForthLevelScore).ToString();
                                        fstRoomScore.text = GData.FirstLevelScore.ToString();
                                        scndRoomScore.text = GData.SceondLevelScore.ToString();
                                        ThrdRoomScore.text = GData.ThirdtLevelScore.ToString();
                                        Background.SetActive(true);
                                        GData.polandData.completedHistGreek = 0;
                                        GData.RightAnswer = 0;
                                        GData.roomLockedIndex++;
                                    }
                                    else
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        GData.polandData.completedHistGreek = 0;

                                        ScoreDisplayPanelText.text = (GData.RightAnswer * 5).ToString();
                                        levelFailPanel.SetActive(true);
                                        GData.RightAnswer = 0;

                                    }
                                }
                            }
                        }
                        break;
                    case 3:
                        if (GData.polandData.completedHistpolish < MCQsData_Polish.questions.Length)
                        {
                            GData.polandData.completedHistpolish++;
                            if (GData.polandData.completedHistpolish < MCQsData_Polish.questions.Length)
                            {
                                SetHistoryQuizData(1);
                            }
                            else if (GData.polandData.completedHistpolish == MCQsData_Polish.questions.Length)
                            {
                                if (GameManager.Instance.isMultiplayer)
                                {
                                    if (GameManager.Instance.SelectedPlayer == 0)
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        MulticongratsPanel.SetActive(true);
                                        GData.polandData.completedHistpolish = 0;

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
                                    if (GData.RightAnswer >= 8)
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        congratsPanel.SetActive(true);
                                        // congratsPanelText.text = "Congratulations! You have unlocked all Rooms.";
                                        frthRoomScore.text = (GData.RightAnswer * 5).ToString();
                                        GData.ForthLevelScore = int.Parse((GData.RightAnswer * 5).ToString());
                                        congratsPanelTotalScore.text = (GData.FirstLevelScore + GData.SceondLevelScore + GData.ThirdtLevelScore + GData.ForthLevelScore).ToString();
                                        fstRoomScore.text = GData.FirstLevelScore.ToString();
                                        scndRoomScore.text = GData.SceondLevelScore.ToString();
                                        ThrdRoomScore.text = GData.ThirdtLevelScore.ToString();
                                        Background.SetActive(true);
                                        GData.polandData.completedHistpolish = 0;
                                        GData.RightAnswer = 0;
                                        GData.roomLockedIndex++;
                                    }
                                    else
                                    {
                                        quizPanel.SetActive(false);
                                        quizobjecthandle();
                                        GData.polandData.completedHistpolish = 0;

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
