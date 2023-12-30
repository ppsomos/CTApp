using EasyMobile;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PortugalManager : MonoBehaviour
{
    public TrueFalseData TFData;
    public CountDown countDown;

    /// <summary>
    /// Fake News Quizes Data
    /// </summary>
    /// 

    public Button TickButton1;
    public Button TickButton2;
    public Button TickButton3;


    public Button ResetButton;
    //public string[] TFQuestions;
    //public int[] TFAns;


    public Text Answerdecision;
    /// <summary>
    /// History Quiz Data
    /// </summary>
    /// 

    public int[] historyAns;
    public string[] historyQues;
    public static string historyFinalAnswer;
    public static int historyQuizIndex;

    private Option[] histOp1 = new Option[5];
    private Option[] histOp2 = new Option[5];


    public Text historyQuestonText;
    public Text[] historyOptionTexts;
    public TextMeshProUGUI historyScoreText;
    public GameObject historyCompleteImage;

    /// <summary>
    /// Geography Quiz Data
    /// </summary>
    /// 
    public int[] geographyAns;
    public string[] geographyQues;
    public static string geographyFinalAnswer;
    public static int geographyQuizIndex;

    private Option[] geogOp1 = new Option[5];
    private Option[] geogOp2 = new Option[5];

    public Text geographyQuestonText;
    public Text[] geographyOptionTexts;
    public TextMeshProUGUI geographyScoreText;
    public GameObject geographyCompleteImage;


    /// <summary>
    /// Food Quiz Data
    /// </summary>
    /// 
    public int[] foodAns;
    public string[] foodQues;
    public static string foodFinalAnswer;
    public static int foodQuizIndex;

    private Option[] foodOp1 = new Option[6];
    private Option[] foodOp2 = new Option[6];


    public Text foodQuestonText;
    public Text[] foodOptionTexts;
    public TextMeshProUGUI foodScoreText;
    public GameObject foodCompleteImage;

    /// <summary>
    /// Culture Quiz Data
    /// </summary>
    /// 
    public int[] cultureAns;
    public string[] cultureQues;
    public static string cultureFinalAnswer;
    public static int cultureQuizIndex;

    private Option[] culOp1 = new Option[6];
    private Option[] culOp2 = new Option[6];


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
    //public Button quizLang;


    void Start()
    {
        selectedCategory = 0;
        playerController.SetActive(true);

        RemoveTextStyle.onClick.RemoveAllListeners();
        RemoveTextStyle.onClick.AddListener(RemoveTextStyleFunc);
    }

    void Update()
    {
        historyScoreText.text = PlayerPrefs.GetInt("PortugalHist") + "/3";
        geographyScoreText.text = PlayerPrefs.GetInt("PortugalGeo") + "/3";
        foodScoreText.text = PlayerPrefs.GetInt("PortugalFood") + "/3";
        cultureScoreText.text = PlayerPrefs.GetInt("PortugalCult") + "/3";


        if (PlayerPrefs.GetInt("PortugalHist") >= 3)
        {
            //quizHist.interactable = false;

            historyCompleteImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("PortugalGeo") >= 3)
        {
            //quizGeo.interactable = false;

            geographyCompleteImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("PortugalFood") >= 3)
        {
            //quizFood.interactable = false;
            foodCompleteImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("PortugalCult") >= 3)
        {
            //quizCult.interactable = false;
            cultureCompleteImage.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Level6") >= 4)
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

            countDown.timeRemaining = 900f;
            countDown.timerIsRunning = true;
            PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
            PlayerPrefs.Save();

            PlayerPrefs.SetInt("Level6", 0);
            PlayerPrefs.SetInt("LevelM6", 1);
            PlayerPrefs.Save();

        }
        if (PlayerPrefs.GetInt("LevelM6") == 1)
        {
            //            door4Col.isTrigger = true;

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

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel());

        TickButton3.gameObject.SetActive(false);

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

        //setting style
        SetTextStyle(historyOptionTexts[0], historyOptionTexts[1]);

        if (historyAns[historyQuizIndex] == 0)
        {
            historyFinalAnswer = histOp1[historyQuizIndex].answer;
        }
        else if (historyAns[historyQuizIndex] == 1)
        {
            historyFinalAnswer = histOp2[historyQuizIndex].answer;
        }

        Debug.Log(historyFinalAnswer);
    }

    private void SetHistoryOptionData()
    {

        for (int i = 0; i < 5; i++)
        {
            historyQues = new string[5];
            historyQues[i] = "";

            historyAns = new int[5];
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

        for (int i = 0; i < 5; i++)
        {
            historyQues[i] = TFData.questions[i];
            historyAns[i] = TFData.answersIndex[i];

            histOp1[i].answer = TFData.Op1[i];
            histOp2[i].answer = TFData.Op2[i];
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

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel());

        TickButton3.gameObject.SetActive(false);

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

        //setting style
        SetTextStyle(geographyOptionTexts[0], geographyOptionTexts[1]);

        if (geographyAns[geographyQuizIndex] == 0)
        {
            geographyFinalAnswer = geogOp1[geographyQuizIndex].answer;
        }
        else if (geographyAns[geographyQuizIndex] == 1)
        {
            geographyFinalAnswer = geogOp2[geographyQuizIndex].answer;
        }

        Debug.Log(geographyFinalAnswer);
    }

    private void SetGeographyOptionData()
    {
        for (int i = 0; i < 5; i++)
        {
            geographyQues = new string[5];
            geographyQues[i] = "";

            geographyAns = new int[5];
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

        for (int i = 0; i < 5; i++)
        {
            geographyQues[i] = TFData.questions[i + 5];
            geographyAns[i] = TFData.answersIndex[i + 5];

            geogOp1[i].answer = TFData.Op1[i + 5];
            geogOp2[i].answer = TFData.Op2[i + 5];
        }

    }

    #endregion

    #region Food Quiz Data

    public void SetFoodQuizData(int index)
    {
        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[0]));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[1]));

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel());

        TickButton3.gameObject.SetActive(false);

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

        //setting style
        SetTextStyle(foodOptionTexts[0], foodOptionTexts[1]);

        if (foodAns[foodQuizIndex] == 0)
        {
            foodFinalAnswer = foodOp1[foodQuizIndex].answer;
        }
        else if (foodAns[foodQuizIndex] == 1)
        {
            foodFinalAnswer = foodOp2[foodQuizIndex].answer;
        }


        Debug.Log(foodFinalAnswer);
    }



    private void SetFoodOptionData()
    {
        for (int i = 0; i < 6; i++)
        {
            foodQues = new string[6];
            foodQues[i] = "";

            foodAns = new int[6];
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

        for (int i = 0; i < 6; i++)
        {
            foodQues[i] = TFData.questions[i + 10];
            foodAns[i] = TFData.answersIndex[i + 10];

            foodOp1[i].answer = TFData.Op1[i + 10];
            foodOp2[i].answer = TFData.Op2[i + 10];
        }

    }

    #endregion

    #region Culture Quiz Data

    public void SetCultureQuizData(int index)
    {
        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[0]));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[1]));

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel());

        TickButton3.gameObject.SetActive(false);

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

        //setting style
        SetTextStyle(cultureOptionTexts[0], cultureOptionTexts[1]);

        if (cultureAns[cultureQuizIndex] == 0)
        {
            cultureFinalAnswer = culOp1[cultureQuizIndex].answer;
        }
        else if (cultureAns[cultureQuizIndex] == 1)
        {
            cultureFinalAnswer = culOp2[cultureQuizIndex].answer;
        }

        Debug.Log(cultureFinalAnswer);
    }


    private void SetCultureOptionData()
    {
        for (int i = 0; i < 6; i++)
        {
            cultureQues = new string[6];
            cultureQues[i] = "";

            cultureAns = new int[6];
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

        for (int i = 0; i < 6; i++)
        {
            cultureQues[i] = TFData.questions[i + 15];
            cultureAns[i] = TFData.answersIndex[i + 15];

            culOp1[i].answer = TFData.Op1[i + 15];
            culOp2[i].answer = TFData.Op2[i + 15];
        }
    }




    #endregion



    #region Common Functions


    public class Option
    {
        public string answer;
        public string tag;
    }

    private void SetTextStyle(Text text1, Text text2)
    {
        //increase fonts
        text1.fontSize = 50;
        text2.fontSize = 50;
        //set fontstyle
        text1.fontStyle = FontStyle.Bold;
        text2.fontStyle = FontStyle.Bold;
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

    public void ResetQuestionaPanel()
    {
        if (PlayerPrefs.GetInt("levelcurrent") == 6)
        {
            if (selectedCategory == 1 && PlayerPrefs.GetInt("PortugalHist", 0) < 3)
            {
                SetHistoryQuizData(1);
                levelFailPanel.SetActive(false);
                quizPanel.SetActive(true);
            }
            else if (selectedCategory == 2 && PlayerPrefs.GetInt("PortugalGeo", 0) < 3)
            {
                SetGeographyQuizData(2);
                levelFailPanel.SetActive(false);
                quizPanel.SetActive(true);
            }
            else if (selectedCategory == 3 && PlayerPrefs.GetInt("PortugalFood", 0) < 3)
            {
                SetFoodQuizData(3);
                levelFailPanel.SetActive(false);
                quizPanel.SetActive(true);
            }
            else if (selectedCategory == 4 && PlayerPrefs.GetInt("PortugalCult", 0) < 3)
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
                countDown.timeRemaining = 900f;
                countDown.timerIsRunning = true;
                PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                PlayerPrefs.Save();
            }
        }

    }


    public void AnswerBtnClick(Text text)
    {

        Debug.Log("Answer click  : " + PlayerPrefs.GetInt("levelcurrent"));

        if (PlayerPrefs.GetInt("levelcurrent") == 6)
        {
            if (selectedCategory == 1)
            {
                if (text.text.Equals(historyFinalAnswer) == true)
                {
                    Debug.Log("Correct History Answer Selected");
                    Answerdecision.text = "CorrectAnswer";
                    StartCoroutine(CorrectAnswerWait());
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
                    StartCoroutine(CorrectAnswerWait());
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
                    StartCoroutine(CorrectAnswerWait());
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
                    StartCoroutine(CorrectAnswerWait());
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

    IEnumerator CorrectAnswerWait()
    {
        yield return new WaitForSeconds(0.5f);
        Answerdecision.text = "";
        if (selectedCategory == 1)
        {
            if (PlayerPrefs.GetInt("PortugalHist", 0) < 3)
            {
                PlayerPrefs.SetInt("PortugalHist", (PlayerPrefs.GetInt("PortugalHist")) + 1);
                PlayerPrefs.Save();

                if (PlayerPrefs.GetInt("PortugalHist", 0) < 3)
                {
                    SetHistoryQuizData(1);
                }
                else if (PlayerPrefs.GetInt("PortugalHist", 0) == 3)
                {
                    PlayerPrefs.SetInt("Level5", (PlayerPrefs.GetInt("Level5")) + 1);
                    PlayerPrefs.Save();

                    //quizHist.interactable = false;

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                    Background.SetActive(true);
                }
            }
            else if (PlayerPrefs.GetInt("PortugalHist", 0) == 3 && !historyCompleteImage.activeInHierarchy)
            {
                PlayerPrefs.SetInt("Level5", (PlayerPrefs.GetInt("Level5")) + 1);
                PlayerPrefs.Save();

                //quizHist.interactable = false;

                quizPanel.SetActive(false);
                levelCompletePanel.SetActive(true);
                Background.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("PortugalHist", 0) == 3 && historyCompleteImage.activeInHierarchy)
            {
                quizPanel.SetActive(false);
                levelCompletePanel.SetActive(true);
                Background.SetActive(true);
            }
        }
        else if (selectedCategory == 2)
        {
            if (PlayerPrefs.GetInt("PortugalGeo", 0) < 3)
            {
                PlayerPrefs.SetInt("PortugalGeo", (PlayerPrefs.GetInt("PortugalGeo")) + 1);
                PlayerPrefs.Save();

                if (PlayerPrefs.GetInt("PortugalGeo", 0) < 3)
                {
                    SetGeographyQuizData(2);
                }
                else if (PlayerPrefs.GetInt("PortugalGeo", 0) == 3)
                {
                    PlayerPrefs.SetInt("Level5", (PlayerPrefs.GetInt("Level5")) + 1);
                    PlayerPrefs.Save();

                    //quizGeo.interactable = false;

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                    Background.SetActive(true);
                }
            }
            else if (PlayerPrefs.GetInt("PortugalGeo", 0) == 3 && !geographyCompleteImage.activeInHierarchy)
            {
                PlayerPrefs.SetInt("Level5", (PlayerPrefs.GetInt("Level5")) + 1);
                PlayerPrefs.Save();

                //quizGeo.interactable = false;

                quizPanel.SetActive(false);
                levelCompletePanel.SetActive(true);
                Background.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("PortugalGeo", 0) == 3 && geographyCompleteImage.activeInHierarchy)
            {
                quizPanel.SetActive(false);
                levelCompletePanel.SetActive(true);
                Background.SetActive(true);
            }
        }
        else if (selectedCategory == 3)
        {
            if (PlayerPrefs.GetInt("PortugalFood", 0) < 3)
            {
                PlayerPrefs.SetInt("PortugalFood", (PlayerPrefs.GetInt("PortugalFood")) + 1);
                PlayerPrefs.Save();

                if (PlayerPrefs.GetInt("PortugalFood", 0) < 3)
                {
                    SetFoodQuizData(3);
                }
                else if (PlayerPrefs.GetInt("PortugalFood", 0) == 3)
                {
                    PlayerPrefs.SetInt("Level5", (PlayerPrefs.GetInt("Level5")) + 1);
                    PlayerPrefs.Save();

                    //quizFood.interactable = false;

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                    Background.SetActive(true);
                }
            }
            else if (PlayerPrefs.GetInt("PortugalFood", 0) == 3 && !foodCompleteImage.activeInHierarchy)
            {
                PlayerPrefs.SetInt("Level5", (PlayerPrefs.GetInt("Level5")) + 1);
                PlayerPrefs.Save();

                //quizFood.interactable = false;

                quizPanel.SetActive(false);
                levelCompletePanel.SetActive(true);
                Background.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("PortugalFood", 0) == 3 && foodCompleteImage.activeInHierarchy)
            {
                quizPanel.SetActive(false);
                levelCompletePanel.SetActive(true);
                Background.SetActive(true);
            }
        }
        else if (selectedCategory == 4)
        {
            if (PlayerPrefs.GetInt("PortugalCult", 0) < 3)
            {
                PlayerPrefs.SetInt("PortugalCult", (PlayerPrefs.GetInt("PortugalCult")) + 1);
                PlayerPrefs.Save();

                if (PlayerPrefs.GetInt("PortugalCult", 0) < 3)
                {
                    SetCultureQuizData(4);
                }
                else if (PlayerPrefs.GetInt("PortugalCult", 0) == 3)
                {
                    PlayerPrefs.SetInt("Level5", (PlayerPrefs.GetInt("Level5")) + 1);
                    PlayerPrefs.Save();

                    //quizCult.interactable = false;

                    quizPanel.SetActive(false);
                    levelCompletePanel.SetActive(true);
                    Background.SetActive(true);
                }
            }
            else if (PlayerPrefs.GetInt("PortugalCult", 0) == 3 && !cultureCompleteImage.activeInHierarchy)
            {
                PlayerPrefs.SetInt("Level5", (PlayerPrefs.GetInt("Level5")) + 1);
                PlayerPrefs.Save();

                //quizCult.interactable = false;

                quizPanel.SetActive(false);
                levelCompletePanel.SetActive(true);
                Background.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("PortugalCult", 0) == 3 && cultureCompleteImage.activeInHierarchy)
            {
                quizPanel.SetActive(false);
                levelCompletePanel.SetActive(true);
                Background.SetActive(true);
            }
        }

    }
    IEnumerator WrongAnswerwait()
    {
        yield return new WaitForSeconds(1f);
        Answerdecision.text = "";
        if (selectedCategory <= 5)
        {
            //levelFailPanel.SetActive(true);
            //Background.SetActive(true);
            quizPanel.SetActive(false);
            loadingManager.levelLoad(0);
        }
    }

    #endregion
}
