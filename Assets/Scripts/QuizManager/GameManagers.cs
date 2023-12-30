using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagers : MonoBehaviour
{
    public static GameManagers instance;
    public GameObject[] roomObject;
    public CountDown countDown;
    [Header("UKManager")]
    public MCQData MCQsData_UKManager;
    public MCQData MCQsData_Italian_UKManager;
    public PolishData MCQsData_Greek_UKManager;
    public PolishData MCQsData_Polish_UKManager;
    [Header("BelgiumManager")]
    public MCQData MCQsData_BelgiumManager;
    public MCQData MCQsData_Italian_BelgiumManager;
    public MCQData MCQsData_Greek_BelgiumManager;
    public MCQData MCQsData_Polish_BelgiumManager;
    [Header("GreeceManager")]
    public MCQData MCQsData_GreeceManager;
    public MCQData MCQsData_Italian_GreeceManager;
    public MCQData MCQsData_Greek_GreeceManager;
    public MCQData MCQsData_Polish_GreeceManager;
    [Header("PolandManager")]
    public MCQData MCQsData_PolandManager;
    public MCQData MCQsData_Italian_PolandManager;
    public MCQData MCQsData_Greek_PolandManager;
    public MCQData MCQsData_Polish_PolandManager;

    public GameData GData;

    public GameObject[] levelPos;
    public GameObject player;

    public static int score;

    bool istrue = false;
    public Text totalanswer;
    public Text showrelatedquiztext;

    public Text Countrytext;
    public Button[] FakeNewsQuestionBtn;
    public Button[] AddictionQuestionBtn;
    public Button[] GroomingQuestionBtn;
    public Button[] CyberQuestionBtn;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        istrue = false;
    }
    void Update()
    {     

        //Debug.Log("currentlevel" + PlayerPrefs.GetInt("CurrentLevel"));
        if (PlayerPrefs.GetInt("levelcurrent") == 1)
        {
            if (istrue == false)
            {
                Debug.Log("Fake News Room");
                Debug.Log("check lvl" + PlayerPrefs.GetInt("levelcurrent"));
                //   Countrytext.text = "Welcome to the United Kingdom";
                istrue = true;
                player.transform.position = levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position;
                player.SetActive(true);
                //Instantiate(player, levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position, Quaternion.identity);
                StartCoroutine(Waitcountrytext());

                roomObject[(PlayerPrefs.GetInt("levelcurrent") - 1)].SetActive(true);
                countDown.timeRemaining = 900f;
                countDown.timerIsRunning = true;
                PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                PlayerPrefs.Save();
            }

        }
        else if (PlayerPrefs.GetInt("levelcurrent") == 2)
        {
            if (istrue == false)
            {
                Debug.Log("Addiction Manager");
                Debug.Log("check lvl" + PlayerPrefs.GetInt("levelcurrent"));
                //   Countrytext.text = "Welcome to Addiction Room";
                istrue = true;
                player.transform.position = levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position;
                player.SetActive(true);
               // Instantiate(player, levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position, Quaternion.identity);
                StartCoroutine(Waitcountrytext());
                roomObject[(PlayerPrefs.GetInt("levelcurrent") - 1)].SetActive(true);

                countDown.timeRemaining = 900f;
                countDown.timerIsRunning = true;
                PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                PlayerPrefs.Save();
            }

        }
        else if (PlayerPrefs.GetInt("levelcurrent") == 3)
        {
            if (istrue == false)
            {
                Debug.Log("Grooming Manager");
                Debug.Log("check lvl" + PlayerPrefs.GetInt("levelcurrent"));
                //       Countrytext.text = "Welcome to Greece";
                istrue = true;
                player.transform.position = levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position;
                player.SetActive(true);
                //Instantiate(player, levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position, Quaternion.identity);
                StartCoroutine(Waitcountrytext());
                roomObject[(PlayerPrefs.GetInt("levelcurrent") - 1)].SetActive(true);

                countDown.timeRemaining = 900f;
                countDown.timerIsRunning = true;
                PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                PlayerPrefs.Save();
            }

        }
        else if (PlayerPrefs.GetInt("levelcurrent") == 4)
        {
            if (istrue == false)
            {
                Debug.Log("Math Manager");
                Debug.Log("check lvl" + PlayerPrefs.GetInt("levelcurrent"));
                // Countrytext.text = "Welcome to Poland";
                istrue = true;
                player.transform.position = levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position;
                player.SetActive(true);
                //Instantiate(player, levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position, Quaternion.identity);
                StartCoroutine(Waitcountrytext());
                roomObject[(PlayerPrefs.GetInt("levelcurrent") - 1)].SetActive(true);

                countDown.timeRemaining = 900f;
                countDown.timerIsRunning = true;
                PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                PlayerPrefs.Save();
            }

        }
        else if (PlayerPrefs.GetInt("levelcurrent") == 5)
        {
            if (istrue == false)
            {
                Debug.Log("Cyber Bullying");
                Debug.Log("check lvl" + PlayerPrefs.GetInt("levelcurrent"));
                //   Countrytext.text = "Welcome to Portugal";
                istrue = true;
                player.transform.position = levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position;
                player.SetActive(true);
                //Instantiate(player, levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position, Quaternion.identity);
                StartCoroutine(Waitcountrytext());
                roomObject[(PlayerPrefs.GetInt("levelcurrent") - 1)].SetActive(true);


                countDown.timeRemaining = 900f;
                countDown.timerIsRunning = true;
                PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                PlayerPrefs.Save();
            }

        }
        else if (PlayerPrefs.GetInt("levelcurrent") == 6)
        {
            if (istrue == false)
            {
                Debug.Log("Phishing");
                Debug.Log("check lvl" + PlayerPrefs.GetInt("levelcurrent"));
                //   Countrytext.text = "Welcome to Portugal";
                istrue = true;
                player.transform.position = levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position;
                player.SetActive(true);
               // Instantiate(player, levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position, Quaternion.identity);
                StartCoroutine(Waitcountrytext());
                roomObject[(PlayerPrefs.GetInt("levelcurrent") - 1)].SetActive(true);


                countDown.timeRemaining = 900f;
                countDown.timerIsRunning = true;
                PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                PlayerPrefs.Save();
            }

        }
        //------Wait for Country Text-----------

        IEnumerator Waitcountrytext()
        {
            yield return new WaitForSeconds(1f);
            Countrytext.text = "";
        }

        if (GData.ukData.completedHist == 16 || GData.ukData.completedHistItalian == 16 
            || GData.ukData.completedHistGreek == 16 || GData.ukData.completedHistpolish == 16)
        {
            FakeNewsQuestionBtn[0].interactable = false;
            FakeNewsQuestionBtn[0].transform.GetChild(1).gameObject.SetActive(true);
        }
        
        else if (GData.ukData.completedGeo == 16 || GData.ukData.completedGeoItalian == 16
            || GData.ukData.completedGeoGreek == 16 || GData.ukData.completedGeoPolish == 16)
        {
            FakeNewsQuestionBtn[1].interactable = false;
            FakeNewsQuestionBtn[1].transform.GetChild(1).gameObject.SetActive(true);
        }
        if (GData.belgiumData.completedHist == 16 || GData.belgiumData.completedHistItalian == 16
            || GData.belgiumData.completedHistGreek == 16 || GData.belgiumData.completedHistpolish == 16)
        {
            AddictionQuestionBtn[0].interactable = false;
            AddictionQuestionBtn[0].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (GData.belgiumData.completedGeo == 16 || GData.belgiumData.completedGeoItalian == 16
            || GData.belgiumData.completedGeoGreek == 16 || GData.belgiumData.completedGeoPolish == 16)
        {
            AddictionQuestionBtn[1].interactable = false;
            AddictionQuestionBtn[1].transform.GetChild(1).gameObject.SetActive(true);
        }
        if (GData.greeceData.completedHist == 16 || GData.greeceData.completedHistItalian == 16
            || GData.greeceData.completedHistGreek == 16 || GData.greeceData.completedHistpolish == 16)
        {
            GroomingQuestionBtn[0].interactable = false;
            GroomingQuestionBtn[0].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (GData.greeceData.completedHist == 16 || GData.greeceData.completedHistItalian == 16
            || GData.greeceData.completedHistGreek == 16 || GData.greeceData.completedHistpolish == 16)
        {
            GroomingQuestionBtn[1].interactable = false;
            GroomingQuestionBtn[1].transform.GetChild(1).gameObject.SetActive(true);
        }
        if (GData.polandData.completedHist == 16 || GData.polandData.completedHistItalian == 16
            || GData.polandData.completedHistGreek == 16 || GData.polandData.completedHistpolish == 16)
        {
            CyberQuestionBtn[0].interactable = false;
            CyberQuestionBtn[0].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (GData.polandData.completedHist == 16 || GData.polandData.completedHistItalian == 16
            || GData.polandData.completedHistGreek == 16 || GData.polandData.completedHistpolish == 16)
        {
            CyberQuestionBtn[1].interactable = false;
            CyberQuestionBtn[1].transform.GetChild(1).gameObject.SetActive(true);
        }


        // For Total Score text

        if (PlayerPrefs.GetInt("levelcurrent") == 1)
        {
            switch (GData.selectedLanguage)
            {
                case 0:
                    totalanswer.text = GData.ukData.score + "/" + 32;
                    break;

                case 1:
                    totalanswer.text = GData.ukData.scoreItalian + "/" + 32;
                    break;
                case 2:
                    totalanswer.text = GData.ukData.scoreGreek + "/" + 32;
                    break;
                case 3:
                    totalanswer.text = GData.ukData.scorepolish + "/" + 32;
                    break;
            }

            //totalanswer.text = PlayerPrefs.GetInt("UKHist") /*+ PlayerPrefs.GetInt("UKGeo") + PlayerPrefs.GetInt("UKFood") + PlayerPrefs.GetInt("UKCult")*/ + "/32";
        }
        else if (PlayerPrefs.GetInt("levelcurrent") == 2)
        {
            switch (GData.selectedLanguage)
            {
                case 0:
                    totalanswer.text = GData.belgiumData.completedHist + "/" + MCQsData_BelgiumManager.questions.Length;
                    break;

                case 1:
                    totalanswer.text = GData.belgiumData.completedHistItalian  + "/" + MCQsData_Italian_BelgiumManager.questions.Length;
                    break;
                case 2:
                    totalanswer.text = GData.belgiumData.completedHistGreek + "/" + MCQsData_Greek_BelgiumManager.questions.Length;
                    break;
                case 3:
                    totalanswer.text = GData.belgiumData.completedHistpolish + "/" + MCQsData_Polish_BelgiumManager.questions.Length;
                    break;
            }
  
        }
        else if (PlayerPrefs.GetInt("levelcurrent") == 3)
        {
            switch (GData.selectedLanguage)
            {
                case 0:
                    totalanswer.text = GData.greeceData.completedHist + "/" + MCQsData_GreeceManager.questions.Length;
                    break;

                case 1:
                    totalanswer.text = GData.greeceData.completedHistItalian + "/" + MCQsData_Italian_GreeceManager.questions.Length;
                    break;
                case 2:
                    totalanswer.text = GData.greeceData.completedHistGreek + "/" + MCQsData_Greek_GreeceManager.questions.Length;
                    break;
                case 3:
                    totalanswer.text = GData.greeceData.completedHistpolish + "/" + MCQsData_Polish_GreeceManager.questions.Length;
                    break;
            }
        }
      
        else if (PlayerPrefs.GetInt("levelcurrent") == 5)
        {
            switch (GData.selectedLanguage)
            {
                case 0:
                    totalanswer.text = GData.polandData.completedHist + "/" + 15;
                    break;

                case 1:
                    totalanswer.text = GData.polandData.completedHistItalian + "/" + 15;
                    break;
                case 2:
                    totalanswer.text = GData.polandData.completedHistGreek + "/" + 15;
                    break;
                case 3:
                    totalanswer.text = GData.polandData.completedHistpolish + "/" + 15;
                    break;
            }          
        }
        
        //----------------Uk Manager//--------

        if (PlayerPrefs.GetInt("levelcurrent") == 1 && UKManager.selectedCategory == 1)
        {
            switch (GData.selectedLanguage)
            {
                case 0:
                    showrelatedquiztext.text = GData.ukData.completedHist + "/" + 16;
                    break;

                case 1:
                    showrelatedquiztext.text = GData.ukData.completedHistItalian + "/" + 16;
                    break;
                case 2:
                    showrelatedquiztext.text = GData.ukData.completedHistGreek + "/" + 16;
                    break;
                case 3:
                    showrelatedquiztext.text = GData.ukData.completedHistpolish + "/" + 16;
                    break;
            }

        }
        else if (PlayerPrefs.GetInt("levelcurrent") == 1 && UKManager.selectedCategory == 2)
        {
            switch (GData.selectedLanguage)
            {
                case 0:
                    showrelatedquiztext.text = GData.ukData.completedGeo + "/" + 16;
                    break;

                case 1:
                    showrelatedquiztext.text = GData.ukData.completedGeoItalian + "/" + 16;
                    break;
                case 2:
                    showrelatedquiztext.text = GData.ukData.completedGeoGreek + "/" + 16;
                    break;
                case 3:
                    showrelatedquiztext.text = GData.ukData.completedGeoPolish + "/" + 16;
                    break;
            }
        }


        //----------------Belgium//--------


        if (PlayerPrefs.GetInt("levelcurrent") == 2 && BelgiumManager.selectedCategory == 1)
        {
            switch (GData.selectedLanguage)
            {
                case 0:
                    showrelatedquiztext.text = GData.belgiumData.completedHist + "/" + MCQsData_BelgiumManager.questions.Length;
                    break;

                case 1:
                    showrelatedquiztext.text = GData.belgiumData.completedHistItalian + "/" + MCQsData_Italian_BelgiumManager.questions.Length;
                    break;
                case 2:
                    showrelatedquiztext.text = GData.belgiumData.completedHistGreek + "/" + MCQsData_Greek_BelgiumManager.questions.Length;
                    break;
                case 3:
                    showrelatedquiztext.text = GData.belgiumData.completedHistpolish + "/" + MCQsData_Polish_BelgiumManager.questions.Length;
                    break;
            }
        }
        else if (PlayerPrefs.GetInt("levelcurrent") == 2 && BelgiumManager.selectedCategory == 2)
        {
            switch (GData.selectedLanguage)
            {
                case 0:
                    showrelatedquiztext.text = GData.belgiumData.completedGeo + "/" + MCQsData_BelgiumManager.questions.Length;
                    break;

                case 1:
                    showrelatedquiztext.text = GData.belgiumData.completedGeoItalian + "/" + MCQsData_Italian_BelgiumManager.questions.Length;
                    break;
                case 2:
                    showrelatedquiztext.text = GData.belgiumData.completedGeoGreek + "/" + MCQsData_Greek_BelgiumManager.questions.Length;
                    break;
                case 3:
                    showrelatedquiztext.text = GData.belgiumData.completedGeoPolish + "/" + MCQsData_Polish_BelgiumManager.questions.Length;
                    break;
            }
        }


        //----------------Greece//--------


        if (PlayerPrefs.GetInt("levelcurrent") == 3 && GreeceManager.selectedCategory == 1)
        {
            switch (GData.selectedLanguage)
            {
                case 0:
                    showrelatedquiztext.text = GData.greeceData.completedHist + "/" + MCQsData_GreeceManager.questions.Length;
                    break;

                case 1:
                    showrelatedquiztext.text = GData.greeceData.completedHistItalian + "/" + MCQsData_Italian_GreeceManager.questions.Length;
                    break;
                case 2:
                    showrelatedquiztext.text = GData.greeceData.completedHistGreek+ "/" + MCQsData_Greek_GreeceManager.questions.Length;
                    break;
                case 3:
                    showrelatedquiztext.text = GData.greeceData.completedHistpolish + "/" + MCQsData_Polish_GreeceManager.questions.Length;
                    break;
            }
        }
        else if (PlayerPrefs.GetInt("levelcurrent") == 3 && GreeceManager.selectedCategory == 2)
        {
            switch (GData.selectedLanguage)
            {
                case 0:
                    showrelatedquiztext.text = GData.greeceData.completedGeo + "/" + MCQsData_GreeceManager.questions.Length;
                    break;

                case 1:
                    showrelatedquiztext.text = GData.greeceData.completedGeoItalian + "/" + MCQsData_Italian_GreeceManager.questions.Length;
                    break;
                case 2:
                    showrelatedquiztext.text = GData.greeceData.completedGeoGreek + "/" + MCQsData_Greek_GreeceManager.questions.Length;
                    break;
                case 3:
                    showrelatedquiztext.text = GData.greeceData.completedGeoPolish + "/" + MCQsData_Polish_GreeceManager.questions.Length;
                    break;
            }
        }
        //----------------Cyber Bullying//--------

        if (PlayerPrefs.GetInt("levelcurrent") == 5 && PolandManager.selectedCategory == 1)
        {
            switch (GData.selectedLanguage)
            {
                case 0:
                    showrelatedquiztext.text = GData.polandData.completedHist + "/" + MCQsData_PolandManager.questions.Length;
                    break;

                case 1:
                    showrelatedquiztext.text = GData.polandData.completedHistItalian + "/" + MCQsData_Italian_PolandManager.questions.Length;
                    break;
                case 2:
                    showrelatedquiztext.text = GData.polandData.completedHistGreek + "/" + MCQsData_Greek_PolandManager.questions.Length;
                    break;
                case 3:
                    showrelatedquiztext.text = GData.polandData.completedHistpolish + "/" + MCQsData_Polish_PolandManager.questions.Length;
                    break;
            }
        }
        else if (PlayerPrefs.GetInt("levelcurrent") == 5 && PolandManager.selectedCategory == 2)
        {
            switch (GData.selectedLanguage)
            {
                case 0:
                    showrelatedquiztext.text = GData.polandData.completedGeo + "/" + MCQsData_PolandManager.questions.Length;
                    break;

                case 1:
                    showrelatedquiztext.text = GData.polandData.completedGeoItalian + "/" + MCQsData_Italian_PolandManager.questions.Length;
                    break;
                case 2:
                    showrelatedquiztext.text = GData.polandData.completedGeoGreek + "/" + MCQsData_Greek_PolandManager.questions.Length;
                    break;
                case 3:
                    showrelatedquiztext.text = GData.polandData.completedGeoPolish + "/" + MCQsData_Polish_PolandManager.questions.Length;
                    break;
            }
        }
    }
    public void setvalue()
    {
        PlayerPrefs.SetInt("Flag", 1);
    }
    public void OnNextBtnPress()
    {
        if (GameManager.Instance.SelectedPlayer == 0)
        {
            GameManager.Instance.SelectedPlayer = 1;
        }
    }

}
