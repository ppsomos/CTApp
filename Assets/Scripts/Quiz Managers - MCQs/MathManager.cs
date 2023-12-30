using EasyMobile;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MathManager : MonoBehaviour
{
    public CountDown countDown;
 //   public TrueFalseData TFData;
    public MCQData MCQsData;

    /// <summary>
    /// Fake News Quizes Data
    /// </summary>
    /// 

    private const string TF_KEY = "TF";
    private const string MCQS_KEY = "MCQS";
    public Button ResetButton;

    public Button TickButton1;
    public Button TickButton2;
    public Button TickButton3;
    public Button TickButton4;

    //public string[] TFQuestions;
    //public int[] TFAns;


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

    private Option[] histOp1 = new Option[3];
    private Option[] histOp2 = new Option[3];
    private Option[] histOp3 = new Option[3];
    private Option[] histOp4 = new Option[3];


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

    private Option[] geogOp1 = new Option[3];
    private Option[] geogOp2 = new Option[3];
    private Option[] geogOp3 = new Option[3];
    private Option[] geogOp4 = new Option[3];


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

    private Option[] foodOp1 = new Option[3];
    private Option[] foodOp2 = new Option[3];
    private Option[] foodOp3 = new Option[3];
    private Option[] foodOp4 = new Option[3];


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
    public GameObject playerController;

    public GameObject controller;
    public LoadManager loadingManager;

    public Button RemoveTextStyle;

    //public Button quizHist;
    //public Button quizGeo;
    //public Button quizFood;
    //public Button quizCult;


    void Start()
    {
        selectedCategory = 0;
        PlayerPrefs.SetString("SelectedManager", "Math");

        RemoveTextStyle.onClick.RemoveAllListeners();
        RemoveTextStyle.onClick.AddListener(RemoveTextStyleFunc);
    }

    void Update()
    {
        historyScoreText.text = PlayerPrefs.GetInt("MathHist") + "/3";
        geographyScoreText.text = PlayerPrefs.GetInt("MathGeo") + "/3";
        foodScoreText.text = PlayerPrefs.GetInt("MathFood") + "/3";
        cultureScoreText.text = PlayerPrefs.GetInt("MathCult") + "/3";


        if (PlayerPrefs.GetInt("MathHist") >= 3)
        {
            //quizHist.interactable = false;

            historyCompleteImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("MathGeo") >= 3)
        {
            //quizGeo.interactable = false;

            geographyCompleteImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("MathFood") >= 3)
        {
            //quizFood.interactable = false;

            foodCompleteImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("MathCult") >= 3)
        {
            //quizCult.interactable = false;

            cultureCompleteImage.SetActive(true);
        }


        if (PlayerPrefs.GetInt("Level4") >= 4)
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
            GameServices.ReportScore(PlayerPrefs.GetInt("Score"), EM_GameServicesConstants.Leaderboard_Escape_Hero);

            countDown.timeRemaining = 300f;
            countDown.timerIsRunning = true;
            PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
            PlayerPrefs.Save();

            PlayerPrefs.SetInt("Level4", 0);
            PlayerPrefs.SetInt("LevelM4", 1);
            PlayerPrefs.Save();

        }
        if (PlayerPrefs.GetInt("LevelM4") == 1)
        {
            //   door4Col.isTrigger = true;

        }
    }

    #region History Quiz Data
    //****************** True False *************// 
    public void SetHistoryQuizData(int index)
    {
        //onclicks added or removed
        //TickButton1.onClick.RemoveAllListeners();
        //TickButton1.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[0], TF_KEY, TickButton1));

        //TickButton2.onClick.RemoveAllListeners();
        //TickButton2.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[1], TF_KEY, TickButton2));

        //TickButton3.onClick.RemoveAllListeners();
        //TickButton3.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[2], TF_KEY, TickButton2));

        //TickButton2.onClick.RemoveAllListeners();
        //TickButton2.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[1], TF_KEY, TickButton2));

        //ResetButton.onClick.RemoveAllListeners();
        //ResetButton.onClick.AddListener(() => ResetQuestionaPanel(TF_KEY));

      //  TickButton3.gameObject.SetActive(false);

        selectedCategory = index;
        SetHistoryOptionData();
        int temp = historyQuizIndex;

        historyQuizIndex = Random.Range(0, historyQues.Length);

        if (temp == historyQuizIndex)
        {
            historyQuizIndex = Random.Range(0, historyQues.Length);
        }

        Debug.Log(historyQuizIndex);

        historyQuestonText.text = historyQues[historyQuizIndex];

        historyOptionTexts[0].text = histOp1[historyQuizIndex].answer;
        historyOptionTexts[1].text = histOp2[historyQuizIndex].answer;
        historyOptionTexts[2].text = histOp3[historyQuizIndex].answer;
        historyOptionTexts[3].text = histOp4[historyQuizIndex].answer;

        //setting style
        SetTextStyle(historyOptionTexts[0], historyOptionTexts[1], historyOptionTexts[2], historyOptionTexts[3]);

        if (historyAns[historyQuizIndex] == 0)
        {
            historyFinalAnswer = histOp1[historyQuizIndex].answer;
        }
        else if (historyAns[historyQuizIndex] == 1)
        {
            historyFinalAnswer = histOp2[historyQuizIndex].answer;
        }
        else if (historyAns[historyQuizIndex] == 2)
        {
            historyFinalAnswer = histOp3[historyQuizIndex].answer;
        }
        else if (historyAns[historyQuizIndex] == 3)
        {
            historyFinalAnswer = histOp4[historyQuizIndex].answer;
        }

        Debug.Log(historyFinalAnswer);
    }

    private void SetHistoryOptionData()
    {

        for (int i = 0; i < 3; i++)
        {
            historyQues = new string[3];
            historyQues[i] = "";

            historyAns = new int[3];
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

        for (int i = 0; i < 3; i++)
        {
            historyQues[i] = MCQsData.questions[i];
            historyAns[i] = MCQsData.answersIndex[i];

            histOp1[i].answer = MCQsData.Op1[i];
            histOp2[i].answer = MCQsData.Op2[i];
            histOp3[i].answer = MCQsData.Op3[i];
            histOp4[i].answer = MCQsData.Op4[i];
        }

    }

    //****************** Mcqs *************// 

    public void SetHistoryQuizDataMCQS(int index)
    {
        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[0], MCQS_KEY, TickButton1));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[1], MCQS_KEY, TickButton2));

        TickButton3.onClick.RemoveAllListeners();
        TickButton3.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[2], MCQS_KEY, TickButton3));

        TickButton4.onClick.RemoveAllListeners();
        TickButton4.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[3], MCQS_KEY, TickButton4));


        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel(MCQS_KEY));

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

        historyOptionTexts[0].text = histOp1[historyQuizIndex].answer;
        historyOptionTexts[1].text = histOp2[historyQuizIndex].answer;
        historyOptionTexts[2].text = histOp3[historyQuizIndex].answer;
        historyOptionTexts[3].text = histOp4[historyQuizIndex].answer;

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

        for (int i = 0; i < 3; i++)
        {
            historyQues = new string[3];
            historyQues[i] = "";

            historyAns = new int[3];
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


        for (int i = 0; i < 3; i++)
        {
            historyQues[i] = MCQsData.questions[i];
            //historyAns[i] = MCQSData.answersIndex[i];

            HistoryAnsMcqs[i].Index = MCQsData.answersIndex[i];//.Split(',');

            histOp1[i].answer = MCQsData.Op1[i];
            histOp2[i].answer = MCQsData.Op2[i];
            histOp3[i].answer = MCQsData.Op3[i];
            histOp4[i].answer = MCQsData.Op4[i];

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


        //setting style
        SetTextStyle(geographyOptionTexts[0], geographyOptionTexts[1], geographyOptionTexts[2], geographyOptionTexts[3]);

        if (geographyAns[geographyQuizIndex] == 0)
        {
            geographyFinalAnswer = geogOp1[geographyQuizIndex].answer;
        }
        else if (geographyAns[geographyQuizIndex] == 1)
        {
            geographyFinalAnswer = geogOp2[geographyQuizIndex].answer;
        }
        else if (geographyAns[geographyQuizIndex] == 2)
        {
            geographyFinalAnswer = geogOp3[geographyQuizIndex].answer;
        }
        else if (geographyAns[geographyQuizIndex] == 3)
        {
            geographyFinalAnswer = geogOp4[geographyQuizIndex].answer;
        }

        Debug.Log(geographyFinalAnswer);
    }
    private void SetGeographyOptionData()
    {
        for (int i = 0; i < 3; i++)
        {
            geographyQues = new string[3];
            geographyQues[i] = "";

            geographyAns = new int[3];
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

        for (int i = 0; i < 3; i++)
        {
            geographyQues[i] = MCQsData.questions[i + 3];
            geographyAns[i] = MCQsData.answersIndex[i + 3];

            geogOp1[i].answer = MCQsData.Op1[i + 3];
            geogOp2[i].answer = MCQsData.Op2[i + 3];
            geogOp3[i].answer = MCQsData.Op3[i + 3];
            geogOp4[i].answer = MCQsData.Op4[i + 3];
        }

    }

    //****************** Mcqs *************// 

    public void SetGeographyQuizDataMCQS(int index)
    {
        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[0], MCQS_KEY, TickButton1));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[1], MCQS_KEY, TickButton2));

        TickButton3.onClick.RemoveAllListeners();
        TickButton3.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[2], MCQS_KEY, TickButton3));

        TickButton4.onClick.RemoveAllListeners();
        TickButton4.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[3], MCQS_KEY, TickButton4));

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel(MCQS_KEY));

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

        geographyQuestonText.text = geographyQues[geographyQuizIndex];

        geographyOptionTexts[0].text = geogOp1[geographyQuizIndex].answer;
        geographyOptionTexts[1].text = geogOp2[geographyQuizIndex].answer;
        geographyOptionTexts[2].text = geogOp3[geographyQuizIndex].answer;
        geographyOptionTexts[3].text = geogOp4[geographyQuizIndex].answer;

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
        for (int i = 0; i < 3; i++)
        {
            geographyQues = new string[3];
            geographyQues[i] = "";

            geographyAns = new int[3];
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


        for (int i = 0; i < 3; i++)
        {
            geographyQues[i] = MCQsData.questions[i + 3];
            //geographyAns[i] = MCQSData.answersIndex[i];

            geographyAnsMcqs[i].Index = MCQsData.answersIndex[i + 3];

            geogOp1[i].answer = MCQsData.Op1[i + 3];
            geogOp2[i].answer = MCQsData.Op2[i + 3];
            geogOp3[i].answer = MCQsData.Op3[i + 3];
            geogOp4[i].answer = MCQsData.Op4[i + 3];
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

        //setting style
        SetTextStyle(foodOptionTexts[0], foodOptionTexts[1], foodOptionTexts[2], foodOptionTexts[3]);



        if (foodAns[foodQuizIndex] == 0)
        {
            foodFinalAnswer = foodOp1[foodQuizIndex].answer;
        }
        else if (foodAns[foodQuizIndex] == 1)
        {
            foodFinalAnswer = foodOp2[foodQuizIndex].answer;
        }
        else if (foodAns[foodQuizIndex] == 2)
        {
            foodFinalAnswer = foodOp3[foodQuizIndex].answer;
        }
        else if (foodAns[foodQuizIndex] == 3)
        {
            foodFinalAnswer = foodOp4[foodQuizIndex].answer;
        }


        Debug.Log(foodFinalAnswer);
    }

    private void SetFoodOptionData()
    {
        for (int i = 0; i < 3; i++)
        {
            foodQues = new string[3];
            foodQues[i] = "";

            foodAns = new int[3];
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

        for (int i = 0; i < 3; i++)
        {
            foodQues[i] = MCQsData.questions[i+6];
            foodAns[i] = MCQsData.answersIndex[i + 6];

            foodOp1[i].answer = MCQsData.Op1[i + 6];
            foodOp2[i].answer = MCQsData.Op2[i + 6];
            foodOp3[i].answer = MCQsData.Op3[i + 6];
            foodOp4[i].answer = MCQsData.Op4[i + 6];

        }

    }

    //****************** Mcqs *************// 

    public void SetFoodQuizDataMCQS(int index)
    {
        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[0], MCQS_KEY, TickButton1));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[1], MCQS_KEY, TickButton2));

        TickButton3.onClick.RemoveAllListeners();
        TickButton3.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[2], MCQS_KEY, TickButton3));

        TickButton4.onClick.RemoveAllListeners();
        TickButton4.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[3], MCQS_KEY, TickButton4));

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel(MCQS_KEY));

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
        for (int i = 0; i < 3; i++)
        {
            foodQues = new string[3];
            foodQues[i] = "";

            foodAns = new int[3];
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


        for (int i = 0; i < 3; i++)
        {
            foodQues[i] = MCQsData.questions[i + 6];
            //foodAns[i] = MCQSData.answersIndex[i];

            foodAnsMcqs[i].Index = MCQsData.answersIndex[i + 6];//.Split(',');

            foodOp1[i].answer = MCQsData.Op1[i + 6];
            foodOp2[i].answer = MCQsData.Op2[i + 6];
            foodOp3[i].answer = MCQsData.Op3[i + 6];
            foodOp4[i].answer = MCQsData.Op4[i + 6];
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

        //setting style
        SetTextStyle(cultureOptionTexts[0], cultureOptionTexts[1], cultureOptionTexts[2], cultureOptionTexts[3]);


        if (cultureAns[cultureQuizIndex] == 0)
        {
            cultureFinalAnswer = culOp1[cultureQuizIndex].answer;
        }
        else if (cultureAns[cultureQuizIndex] == 1)
        {
            cultureFinalAnswer = culOp2[cultureQuizIndex].answer;
        }
        else if (cultureAns[cultureQuizIndex] == 2)
        {
            cultureFinalAnswer = culOp3[cultureQuizIndex].answer;
        }
        else if (cultureAns[cultureQuizIndex] == 3)
        {
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

        for (int i = 0; i < 3; i++)
        {
            cultureQues[i] = MCQsData.questions[i+9];
            cultureAns[i] = MCQsData.answersIndex[i + 9];

            culOp1[i].answer = MCQsData.Op1[i + 9];
            culOp2[i].answer = MCQsData.Op2[i + 9];
            culOp3[i].answer = MCQsData.Op3[i + 9];
            culOp4[i].answer = MCQsData.Op4[i + 9];

        }
    }

    //****************** Mcqs *************// 

    public void SetCultureQuizDataMCQS(int index)
    {
        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[0], MCQS_KEY, TickButton1));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[1], MCQS_KEY, TickButton2));

        TickButton3.onClick.RemoveAllListeners();
        TickButton3.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[2], MCQS_KEY, TickButton3));
        
        TickButton4.onClick.RemoveAllListeners();
        TickButton4.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[3], MCQS_KEY, TickButton4));

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel(MCQS_KEY));

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


        for (int i = 0; i < 3; i++)
        {
            cultureQues[i] = MCQsData.questions[i + 9];
            //cultureAns[i] = MCQSData.answersIndex[i];

            cultureAnsMcqs[i].Index = MCQsData.answersIndex[i + 9];//.Split(',');

            culOp1[i].answer = MCQsData.Op1[i + 9];
            culOp2[i].answer = MCQsData.Op2[i + 9];
            culOp3[i].answer = MCQsData.Op3[i + 9];
            culOp4[i].answer = MCQsData.Op4[i + 9];
        }
    }

    #endregion




    #region Common Functions


    public class Option
    {
        public string answer;
        public string tag;
    }

    private void SetTextStyle(Text text1, Text text2, Text text3, Text text4)
    {
        //increase fonts
        text1.fontSize = 50;
        text2.fontSize = 50;
        text3.fontSize = 50;
        text4.fontSize = 50;

        //set fontstyle
        text1.fontStyle = FontStyle.Bold;
        text2.fontStyle = FontStyle.Bold;
        text3.fontStyle = FontStyle.Bold;
        text4.fontStyle = FontStyle.Bold;

    }

    public void RemoveTextStyleFunc()
    {
        historyOptionTexts[0].fontSize = 40;
        historyOptionTexts[1].fontSize = 40;
        historyOptionTexts[2].fontSize = 40;
        historyOptionTexts[3].fontSize = 40;

        historyOptionTexts[0].fontStyle = FontStyle.Bold;
        historyOptionTexts[1].fontStyle = FontStyle.Bold;
        historyOptionTexts[2].fontStyle = FontStyle.Bold;
        historyOptionTexts[3].fontStyle = FontStyle.Bold;
    }

    public void ResetQuestionaPanel(string Category)
    {
        Debug.Log("Came in Math");
        if (Category.Equals(TF_KEY))
        {
            if (PlayerPrefs.GetInt("levelcurrent") == 4)
            {
                if (selectedCategory == 1 && PlayerPrefs.GetInt("MathHist", 0) < 3)
                {
                    SetHistoryQuizData(1);
                    levelFailPanel.SetActive(false);
                    quizPanel.SetActive(true);
                }
                else if (selectedCategory == 2 && PlayerPrefs.GetInt("MathGeo", 0) < 3)
                {
                    SetGeographyQuizData(2);
                    levelFailPanel.SetActive(false);
                    quizPanel.SetActive(true);
                }
                else if (selectedCategory == 3 && PlayerPrefs.GetInt("MathFood", 0) < 3)
                {
                    SetFoodQuizData(3);
                    levelFailPanel.SetActive(false);
                    quizPanel.SetActive(true);
                }
                else if (selectedCategory == 4 && PlayerPrefs.GetInt("MathCult", 0) < 3)
                {
                    SetCultureQuizData(4);
                    levelFailPanel.SetActive(false);
                    quizPanel.SetActive(true);
                }

                else
                {
                    levelFailPanel.SetActive(false);
                    cameraobj.SetActive(false);
                    Background.SetActive(false);
                    controller.SetActive(true);
                    countDown.timeRemaining = 300f;
                    countDown.timerIsRunning = true;
                    PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                    PlayerPrefs.Save();
                }
            }
        }
        else if (Category.Equals(MCQS_KEY))
        {
            if (PlayerPrefs.GetInt("levelcurrent") == 4)
            {
                if (selectedCategory == 1 && PlayerPrefs.GetInt("MathHist", 0) < 3)
                {
                    SetHistoryQuizDataMCQS(1);
                    levelFailPanel.SetActive(false);
                    quizPanel.SetActive(true);
                }
                else if (selectedCategory == 2 && PlayerPrefs.GetInt("MathGeo", 0) < 3)
                {
                    SetGeographyQuizDataMCQS(2);
                    levelFailPanel.SetActive(false);
                    quizPanel.SetActive(true);
                }
                else if (selectedCategory == 3 && PlayerPrefs.GetInt("MathFood", 0) < 3)
                {
                    SetFoodQuizDataMCQS(3);
                    levelFailPanel.SetActive(false);
                    quizPanel.SetActive(true);
                }
                else if (selectedCategory == 4 && PlayerPrefs.GetInt("MathCult", 0) < 3)
                {
                    SetCultureQuizDataMCQS(4);
                    levelFailPanel.SetActive(false);
                    quizPanel.SetActive(true);
                }

                else
                {
                    levelFailPanel.SetActive(false);
                    cameraobj.SetActive(false);
                    Background.SetActive(false);
                    controller.SetActive(true);
                    countDown.timeRemaining = 300f;
                    countDown.timerIsRunning = true;
                    PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                    PlayerPrefs.Save();
                }
            }
        }

    }

    public void AnswerBtnClick(Text text, string Category, Button btn)
    {
        Debug.Log("Came in Math");
        if (Category.Equals(TF_KEY))
        {
            if (PlayerPrefs.GetInt("levelcurrent") == 4)
            {
                Debug.Log("In Math Answer Click : " + selectedCategory);

                if (selectedCategory == 1)
                {
                    if (text.text.Equals(historyFinalAnswer) == true)
                    {
                        Debug.Log("Correct History Answer Selected");
                        Answerdecision.text = "CorrectAnswer";
                        StartCoroutine(CorrectAnswerWait(TF_KEY));
                    }
                    else
                    {
                        Debug.Log("Wrong History Answer Selected");
                        Answerdecision.text = "WrongAnswer";
                        StartCoroutine(WrongAnswerwait());
                    }
                }
                else if (selectedCategory == 2)
                {
                    if (text.text.Equals(geographyFinalAnswer) == true)
                    {
                        Debug.Log("Correct geography Answer Selected");
                        Answerdecision.text = "CorrectAnswer";
                        StartCoroutine(CorrectAnswerWait(TF_KEY));
                    }
                    else
                    {
                        Debug.Log("Wrong geography Answer Selected");
                        Answerdecision.text = "WrongAnswer";
                        StartCoroutine(WrongAnswerwait());
                    }
                }
                else if (selectedCategory == 3)
                {
                    if (text.text.Equals(foodFinalAnswer) == true)
                    {
                        Debug.Log("Correct food Answer Selected");
                        Answerdecision.text = "CorrectAnswer";
                        StartCoroutine(CorrectAnswerWait(TF_KEY));
                    }
                    else
                    {
                        Debug.Log("Wrong food Answer Selected");
                        Answerdecision.text = "WrongAnswer";
                        StartCoroutine(WrongAnswerwait());
                    }
                }
                else if (selectedCategory == 4)
                {
                    if (text.text.Equals(cultureFinalAnswer) == true)
                    {
                        Debug.Log("Correct culture Answer Selected");
                        Answerdecision.text = "CorrectAnswer";
                        StartCoroutine(CorrectAnswerWait(TF_KEY));
                    }
                    else
                    {
                        Debug.Log("Wrong culture Answer Selected");
                        Answerdecision.text = "WrongAnswer";
                        StartCoroutine(WrongAnswerwait());
                    }
                }

            }
        }
        else if (Category.Equals(MCQS_KEY))
        {
            if (PlayerPrefs.GetInt("levelcurrent") == 4)
            {
                Debug.Log("In Math Answer Click : " + selectedCategory);

                if (selectedCategory == 1)
                {
                    if (btn.GetComponent<Answer>().iscorrect == true)
                    {
                        Debug.Log("Correct History Answer Selected");
                        Answerdecision.text = "CorrectAnswer";
                        StartCoroutine(CorrectAnswerWait(MCQS_KEY));
                    }
                    else
                    {
                        Debug.Log("Wrong History Answer Selected");
                        Answerdecision.text = "WrongAnswer";
                        StartCoroutine(WrongAnswerwait());
                    }
                }
                else if (selectedCategory == 2)
                {
                    if (btn.GetComponent<Answer>().iscorrect == true)
                    {
                        Debug.Log("Correct geography Answer Selected");
                        Answerdecision.text = "CorrectAnswer";
                        StartCoroutine(CorrectAnswerWait(MCQS_KEY));
                    }
                    else
                    {
                        Debug.Log("Wrong geography Answer Selected");
                        Answerdecision.text = "WrongAnswer";
                        StartCoroutine(WrongAnswerwait());
                    }
                }
                else if (selectedCategory == 3)
                {
                    if (btn.GetComponent<Answer>().iscorrect == true)
                    {
                        Debug.Log("Correct food Answer Selected");
                        Answerdecision.text = "CorrectAnswer";
                        StartCoroutine(CorrectAnswerWait(MCQS_KEY));
                    }
                    else
                    {
                        Debug.Log("Wrong food Answer Selected");
                        Answerdecision.text = "WrongAnswer";
                        StartCoroutine(WrongAnswerwait());
                    }
                }
                else if (selectedCategory == 4)
                {
                    if (btn.GetComponent<Answer>().iscorrect == true)
                    {
                        Debug.Log("Correct culture Answer Selected");
                        Answerdecision.text = "CorrectAnswer";
                        StartCoroutine(CorrectAnswerWait(MCQS_KEY));
                    }
                    else
                    {
                        Debug.Log("Wrong culture Answer Selected");
                        Answerdecision.text = "WrongAnswer";
                        StartCoroutine(WrongAnswerwait());
                    }
                }

            }
        }

    }

    IEnumerator CorrectAnswerWait(string Category)
    {
        yield return new WaitForSeconds(0.5f);
        Answerdecision.text = "";
        if (Category.Equals(TF_KEY))
        {
            if (selectedCategory == 1)
            {
                if (PlayerPrefs.GetInt("MathHist", 0) < 3)
                {
                    PlayerPrefs.SetInt("MathHist", (PlayerPrefs.GetInt("MathHist")) + 1);
                    PlayerPrefs.Save();

                    if (PlayerPrefs.GetInt("MathHist", 0) < 3)
                    {
                        SetHistoryQuizData(1);
                    }
                    else if (PlayerPrefs.GetInt("MathHist", 0) == 3)
                    {
                        PlayerPrefs.SetInt("Level4", (PlayerPrefs.GetInt("Level4")) + 1);
                        PlayerPrefs.Save();

                        //quizHist.interactable = false;

                        quizPanel.SetActive(false);
                        levelCompletePanel.SetActive(true);
                        Background.SetActive(true);
                    }
                }
                else if (PlayerPrefs.GetInt("MathHist", 0) == 3 && !historyCompleteImage.activeInHierarchy)
                {
                    PlayerPrefs.SetInt("Level4", (PlayerPrefs.GetInt("Level4")) + 1);
                    PlayerPrefs.Save();

                    //quizHist.interactable = false;

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                    Background.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("MathHist", 0) == 3 && historyCompleteImage.activeInHierarchy)
                {
                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                    Background.SetActive(true);
                }

            }
            else if (selectedCategory == 2)
            {
                if (PlayerPrefs.GetInt("MathGeo", 0) < 3)
                {
                    PlayerPrefs.SetInt("MathGeo", (PlayerPrefs.GetInt("MathGeo")) + 1);
                    PlayerPrefs.Save();

                    if (PlayerPrefs.GetInt("MathGeo", 0) < 3)
                    {
                        SetGeographyQuizData(2);
                    }
                    else if (PlayerPrefs.GetInt("MathGeo", 0) == 3)
                    {
                        PlayerPrefs.SetInt("Level4", (PlayerPrefs.GetInt("Level4")) + 1);
                        PlayerPrefs.Save();

                        //quizGeo.interactable = false;

                        quizPanel.SetActive(false);
                        levelCompletePanel.SetActive(true);
                        Background.SetActive(true);
                    }
                }
                else if (PlayerPrefs.GetInt("MathGeo", 0) == 3 && !geographyCompleteImage.activeInHierarchy)
                {
                    PlayerPrefs.SetInt("Level4", (PlayerPrefs.GetInt("Level4")) + 1);
                    PlayerPrefs.Save();

                    //quizGeo.interactable = false;

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                    Background.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("MathGeo", 0) == 3 && geographyCompleteImage.activeInHierarchy)
                {
                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                    Background.SetActive(true);
                }
            }
            else if (selectedCategory == 3)
            {
                if (PlayerPrefs.GetInt("MathFood", 0) < 3)
                {
                    PlayerPrefs.SetInt("MathFood", (PlayerPrefs.GetInt("MathFood")) + 1);
                    PlayerPrefs.Save();
                    if (PlayerPrefs.GetInt("MathFood", 0) < 3)
                    {
                        SetFoodQuizData(3);
                    }
                    else if (PlayerPrefs.GetInt("MathFood", 0) == 3)
                    {
                        PlayerPrefs.SetInt("Level4", (PlayerPrefs.GetInt("Level4")) + 1);
                        PlayerPrefs.Save();

                        //quizFood.interactable = false;

                        quizPanel.SetActive(false);
                        levelCompletePanel.SetActive(true);
                        Background.SetActive(true);
                    }

                }
                else if (PlayerPrefs.GetInt("MathFood", 0) == 3 && !foodCompleteImage.activeInHierarchy)
                {
                    PlayerPrefs.SetInt("Level4", (PlayerPrefs.GetInt("Level4")) + 1);
                    PlayerPrefs.Save();

                    //quizFood.interactable = false;

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                    Background.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("MathFood", 0) == 3 && foodCompleteImage.activeInHierarchy)
                {
                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                    Background.SetActive(true);
                }
            }
            else if (selectedCategory == 4)
            {
                if (PlayerPrefs.GetInt("MathCult", 0) < 3)
                {
                    PlayerPrefs.SetInt("MathCult", (PlayerPrefs.GetInt("MathCult")) + 1);
                    PlayerPrefs.Save();
                    if (PlayerPrefs.GetInt("MathCult", 0) < 3)
                    {
                        SetCultureQuizData(4);
                    }
                    else if (PlayerPrefs.GetInt("MathCult", 0) == 3)
                    {
                        PlayerPrefs.SetInt("Level4", (PlayerPrefs.GetInt("Level4")) + 1);
                        PlayerPrefs.Save();

                        //quizCult.interactable = false;

                        quizPanel.SetActive(false);
                        levelCompletePanel.SetActive(true);
                        Background.SetActive(true);
                    }
                }
                else if (PlayerPrefs.GetInt("MathCult", 0) == 3 && !cultureCompleteImage.activeInHierarchy)
                {
                    PlayerPrefs.SetInt("Level4", (PlayerPrefs.GetInt("Level4")) + 1);
                    PlayerPrefs.Save();

                    //quizCult.interactable = false;

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                    Background.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("MathCult", 0) == 3 && cultureCompleteImage.activeInHierarchy)
                {
                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                    Background.SetActive(true);
                }
            }
        }
        else if (Category.Equals(MCQS_KEY))
        {
            if (selectedCategory == 1)
            {
                if (PlayerPrefs.GetInt("MathHist", 0) < 3)
                {
                    PlayerPrefs.SetInt("MathHist", (PlayerPrefs.GetInt("MathHist")) + 1);
                    PlayerPrefs.Save();

                    if (PlayerPrefs.GetInt("MathHist", 0) < 3)
                    {
                        SetHistoryQuizDataMCQS(1);
                    }
                    else if (PlayerPrefs.GetInt("MathHist", 0) == 3)
                    {
                        PlayerPrefs.SetInt("Level4", (PlayerPrefs.GetInt("Level4")) + 1);
                        PlayerPrefs.Save();

                        //quizHist.interactable = false;

                        quizPanel.SetActive(false);
                        levelCompletePanel.SetActive(true);
                        Background.SetActive(true);
                    }
                }
                else if (PlayerPrefs.GetInt("MathHist", 0) == 3 && !historyCompleteImage.activeInHierarchy)
                {
                    PlayerPrefs.SetInt("Level4", (PlayerPrefs.GetInt("Level4")) + 1);
                    PlayerPrefs.Save();

                    //quizHist.interactable = false;

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                    Background.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("MathHist", 0) == 3 && historyCompleteImage.activeInHierarchy)
                {
                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                    Background.SetActive(true);
                }
            }
            else if (selectedCategory == 2)
            {
                if (PlayerPrefs.GetInt("MathGeo", 0) < 3)
                {
                    PlayerPrefs.SetInt("MathGeo", (PlayerPrefs.GetInt("MathGeo")) + 1);
                    PlayerPrefs.Save();

                    if (PlayerPrefs.GetInt("MathGeo", 0) < 3)
                    {
                        SetGeographyQuizDataMCQS(2);
                    }
                    else if (PlayerPrefs.GetInt("MathGeo", 0) == 3)
                    {
                        PlayerPrefs.SetInt("Level4", (PlayerPrefs.GetInt("Level4")) + 1);
                        PlayerPrefs.Save();

                        //quizGeo.interactable = false;

                        quizPanel.SetActive(false);
                        levelCompletePanel.SetActive(true);
                        Background.SetActive(true);
                    }
                }
                else if (PlayerPrefs.GetInt("MathGeo", 0) == 3 && !geographyCompleteImage.activeInHierarchy)
                {
                    PlayerPrefs.SetInt("Level4", (PlayerPrefs.GetInt("Level4")) + 1);
                    PlayerPrefs.Save();

                    //quizGeo.interactable = false;

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                    Background.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("MathGeo", 0) == 3 && geographyCompleteImage.activeInHierarchy)
                {
                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                    Background.SetActive(true);
                }
            }
            else if (selectedCategory == 3)
            {
                if (PlayerPrefs.GetInt("MathFood", 0) < 3)
                {
                    PlayerPrefs.SetInt("MathFood", (PlayerPrefs.GetInt("MathFood")) + 1);
                    PlayerPrefs.Save();
                    if (PlayerPrefs.GetInt("MathFood", 0) < 3)
                    {
                        SetFoodQuizDataMCQS(3);
                    }
                    else if (PlayerPrefs.GetInt("MathFood", 0) == 3)
                    {
                        PlayerPrefs.SetInt("Level4", (PlayerPrefs.GetInt("Level4")) + 1);
                        PlayerPrefs.Save();

                        //quizFood.interactable = false;

                        quizPanel.SetActive(false);
                        levelCompletePanel.SetActive(true);
                        Background.SetActive(true);
                    }

                }
                else if (PlayerPrefs.GetInt("MathFood", 0) == 3 && !foodCompleteImage.activeInHierarchy)
                {
                    PlayerPrefs.SetInt("Level4", (PlayerPrefs.GetInt("Level4")) + 1);
                    PlayerPrefs.Save();

                    //quizFood.interactable = false;

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                    Background.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("MathFood", 0) == 3 && foodCompleteImage.activeInHierarchy)
                {
                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                    Background.SetActive(true);
                }
            }
            else if (selectedCategory == 4)
            {
                if (PlayerPrefs.GetInt("MathCult", 0) < 3)
                {
                    PlayerPrefs.SetInt("MathCult", (PlayerPrefs.GetInt("MathCult")) + 1);
                    PlayerPrefs.Save();
                    if (PlayerPrefs.GetInt("MathCult", 0) < 3)
                    {
                        SetCultureQuizDataMCQS(4);
                    }
                    else if (PlayerPrefs.GetInt("MathCult", 0) == 3)
                    {
                        PlayerPrefs.SetInt("Level4", (PlayerPrefs.GetInt("Level4")) + 1);
                        PlayerPrefs.Save();

                        //quizCult.interactable = false;

                        quizPanel.SetActive(false);
                        levelCompletePanel.SetActive(true);
                        Background.SetActive(true);
                    }
                }
                else if (PlayerPrefs.GetInt("MathCult", 0) == 3 && !cultureCompleteImage.activeInHierarchy)
                {
                    PlayerPrefs.SetInt("Level4", (PlayerPrefs.GetInt("Level4")) + 1);
                    PlayerPrefs.Save();

                    //quizCult.interactable = false;

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                    Background.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("MathCult", 0) == 3 && cultureCompleteImage.activeInHierarchy)
                {
                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                    Background.SetActive(true);
                }
            }
        }

    }
    IEnumerator WrongAnswerwait()
    {
        yield return new WaitForSeconds(1f);
        Answerdecision.text = "";
        if (selectedCategory <= 5)
        {
            levelFailPanel.SetActive(true);
            Background.SetActive(true);
            quizPanel.SetActive(false);
            //loadingManager.levelLoad(0);
        }
    }
    [System.Serializable]
    public class FindIndex
    {
        public int Index;
    }
    #endregion
}

