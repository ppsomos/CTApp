using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance = null;
    public MultiPlayerManager MP;
    public GameObject Mainmenupanal;
    public GameObject flagpanal;
    public static int currentindex;
    public GameData GData;
    public GameObject MainLanguageSettingPanal;
    public GameObject MainSettingDropDown;
    public GameObject SettingDropDown;
    public AudioClipsSource source;
    //-------------For Level Locking------------

    public GameObject[] _button;
    //int levelunlocked = 0;


    private void Awake()
    {
        instance = this;

    }
    private void Start()
    {
        // CheckForFirstTime();
        DataReset();
        if (PlayerPrefs.HasKey("Flag"))
        {
            int val = PlayerPrefs.GetInt("Flag");
            if (val == 1)
            {
                Debug.Log("12345");
                Mainmenupanal.SetActive(false);
                flagpanal.SetActive(true);
               // PlayerPrefs.SetInt("Flag", 0);
            }
        }
        StartLanguageSetting();
        Invoke("ResetData", 2f);
        RoomUnlocking();
       



    }
    public void RoomUnlocking()
    {
        if (!GameManager.Instance.isMultiplayer)
        {
            for (int i = 0; i < 4; i++)
            {
                Debug.Log("locked room");
                //GData.RoomLockedIndex
                bool Istrue = i <= GData.roomLockedIndex;
                _button[i].GetComponent<Button>().interactable = Istrue;
                if (Istrue == true)
                {
                    _button[i].transform.GetChild(1).gameObject.SetActive(false);
                }
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                Debug.Log("Unlocked room");
                //GData.RoomLockedIndex
                bool Istrue = i <= GData.MultiplayerroomUnlocked;
               _button[i].GetComponent<Button>().interactable = Istrue;
                if (Istrue == true)
                {
                    _button[i].transform.GetChild(1).gameObject.SetActive(false);
                }
            }
        }
    }
    public void onMul_Btn_Click()
    {
        GameManager.Instance.isMultiplayer = true;
        Invoke("RoomUnlocking", 0.5f);
    }
    public void ResetData()
    {
        MP.playerNo = 0;
        MP.PlayerName_InputField.GetComponent<TMP_InputField>().text = null;
        MP.Player1Avatar.transform.GetChild(0).gameObject.SetActive(false);
        MP.Player2Avatar.transform.GetChild(0).gameObject.SetActive(false);
        MP.Player1Text.SetActive(true);
        MP.Player2Text.SetActive(false);
        GameManager.Instance.isMultiplayer = false;
        GameManager.Instance.SelectedPlayer = 0;
        for (int i = 0; i < GData.Multi_Player.Length; i++)
        {
            GData.Multi_Player[i].PlayerName = null;
            GData.Multi_Player[i].SelectedAvatar = 0;
            GData.Multi_Player[i].RightAnswer = 0;
            GData.Multi_Player[i].WrongAnswer = 0;
            GData.Multi_Player[i].score = 0;
            GData.Multi_Player[i].winMatch = 0;
            GData.Multi_Player[i].TimeTaken = 0;
            PersistentDataManager.instance.SaveData();
        }
       
    }
    public void CheckForFirstTime()
    {
        if (GData.isFirstTime)
        {
           
            GData.isFirstTime = false;
            ActiveMainMeuLanguageSetting();
            PersistentDataManager.instance.SaveData();
        }
        else
        {
            Debug.Log("123");
            CloseMainMeuLanguageSettingPanal();
        }
        DataReset();
    }
    public void StartLanguageSetting()
    {
        Debug.Log("1212");
        MainSettingDropDown.GetComponent<TMP_Dropdown>().value = PlayerPrefs.GetInt("language");
        SettingDropDown.GetComponent<TMP_Dropdown>().value = PlayerPrefs.GetInt("language");
    }
    public void ActiveMainMeuLanguageSetting()
    {
        Mainmenupanal.SetActive(false);
        MainLanguageSettingPanal.SetActive(true);
    }
    public void SetMainSetingSlider()
    {
        //PlayerPrefs.SetInt("language")
        //GData.selectedLanguage = MainSettingDropDown.GetComponent<TMP_Dropdown>().value;
        if(MainSettingDropDown.GetComponent<TMP_Dropdown>().value == 2)
        {
            GData.selectedLanguage = 0;
            PlayerPrefs.SetInt("language", MainSettingDropDown.GetComponent<TMP_Dropdown>().value);
        }
        else
        {
            GData.selectedLanguage = MainSettingDropDown.GetComponent<TMP_Dropdown>().value;
            PlayerPrefs.SetInt("language", MainSettingDropDown.GetComponent<TMP_Dropdown>().value);
        }
       // SettingDropDown.GetComponent<TMP_Dropdown>().value = GData.selectedLanguage;
        PersistentDataManager.instance.SaveData();
        LocaleSelector.instance.ChangeLocale();
    }
   
    public void SetSetingSlider()
    {
        if (SettingDropDown.GetComponent<TMP_Dropdown>().value == 2)
        {
            GData.selectedLanguage = 2;
            PlayerPrefs.SetInt("language", SettingDropDown.GetComponent<TMP_Dropdown>().value);
        }
        else
        {
            GData.selectedLanguage = SettingDropDown.GetComponent<TMP_Dropdown>().value;
            PlayerPrefs.SetInt("language", SettingDropDown.GetComponent<TMP_Dropdown>().value);
        }
       
        LocaleSelector.instance.ChangeLocale();
        PersistentDataManager.instance.SaveData();
    }
    public void CloseMainMeuLanguageSettingPanal()
    {
        Debug.Log(23344);
        SettingDropDown.GetComponent<TMP_Dropdown>().value = PlayerPrefs.GetInt("language");
        Mainmenupanal.SetActive(true);
        MainLanguageSettingPanal.SetActive(false);
    }
    
    public void DataReset()
    {
        GData.ukData.score = 0;
        GData.ukData.scoreItalian = 0;
        GData.ukData.scoreGreek = 0;
        GData.ukData.scorepolish = 0;
        GData.ukData.completedHist = 0;
        GData.ukData.completedHistItalian = 0;
        GData.ukData.completedHistGreek = 0;
        GData.ukData.completedHistpolish = 0;
        GData.ukData.completedGeo = 0;
        GData.ukData.completedGeoItalian = 0;
        GData.ukData.completedGeoGreek = 0;
        GData.ukData.completedGeoPolish = 0;


        GData.belgiumData.score = 0;
        GData.belgiumData.scoreItalian = 0;
        GData.belgiumData.scoreGreek = 0;
        GData.belgiumData.scorepolish = 0;
        GData.belgiumData.completedHist = 0;
        GData.belgiumData.completedHistItalian = 0;
        GData.belgiumData.completedHistGreek = 0;
        GData.belgiumData.completedHistpolish = 0;
        GData.belgiumData.completedGeo = 0;
        GData.belgiumData.completedGeoItalian = 0;
        GData.belgiumData.completedGeoGreek = 0;
        GData.belgiumData.completedGeoPolish = 0;

        GData.greeceData.score = 0;
        GData.greeceData.scoreItalian = 0;
        GData.greeceData.scoreGreek = 0;
        GData.greeceData.scorepolish = 0;
        GData.greeceData.completedHist = 0;
        GData.greeceData.completedHistItalian = 0;
        GData.greeceData.completedHistpolish = 0;
        GData.greeceData.completedHistGreek = 0;
        GData.greeceData.completedGeo = 0;
        GData.greeceData.completedGeoItalian = 0;
        GData.greeceData.completedGeoGreek = 0;
        GData.greeceData.completedGeoPolish = 0;

        GData.polandData.score = 0;
        GData.polandData.scoreItalian = 0;
        GData.polandData.scoreGreek = 0;
        GData.polandData.scorepolish = 0;
        GData.polandData.completedHist = 0;
        GData.polandData.completedHistItalian = 0;
        GData.polandData.completedHistGreek = 0;
        GData.polandData.completedHistpolish = 0;
        GData.polandData.completedGeo = 0;
        GData.polandData.completedGeoItalian = 0;
        GData.polandData.completedGeoGreek = 0;
        GData.polandData.completedGeoPolish = 0;
        PersistentDataManager.instance.SaveData();

    }

    public void ChangeLevelPos(int index)
    {
        currentindex = index;
        PlayerPrefs.SetInt("levelcurrent", currentindex);
    }
}
