using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class FirstLoadingHandler : MonoBehaviour
{
    [Header("Game Data")]
    public GameData GData;
    [Header("Loading Screens")]
    public GameObject loadingScreen;
    public Slider loadingSlider;
    public TMP_Text progressText;
    public TMP_Text showDescription;
    public string[] Descriptions;
    public Button NextButton;
    public GameObject PopupScreen;
    private int CurrentDescription;

    void Start()
    {
        CurrentDescription = 0;
        Invoke(nameof(CheckForFirstTime), 0f);
    }
    public void CheckForFirstTime()
    {
        if (GData.isFirstTime)
        {
            GData.isFirstTime = false;
            GData.RightAnswer = 0;
            GData.IsselectLeaderboard = false;
            GData.FirstLevelScore = 0;
            GData.SceondLevelScore =0;
            GData.ThirdtLevelScore =0;
            GData.ForthLevelScore =0;

            GData.isMusic = true;
            GData.isSound = true;
            GData.isVibrate = true;
            GData.selectedLanguage = 0;
            GData.roomLockedIndex = 0;
            GData.isPlayFirstTime = true;
            GData.selectedAvater = 0;
            GData.playerName = null;
              
            GData.ukData.score = 0;
            GData.ukData.scoreItalian = 0;
            GData.ukData.completedHist = 0;
            GData.ukData.completedHistItalian = 0;
            GData.ukData.completedGeo = 0;
            GData.ukData.completedGeoItalian = 0;
        
            GData.belgiumData.score = 0;
            GData.belgiumData.scoreItalian = 0;
            GData.belgiumData.completedHist = 0;
            GData.belgiumData.completedHistItalian = 0;
            GData.belgiumData.completedGeo = 0;
            GData.belgiumData.completedGeoItalian = 0;
        
            GData.greeceData.score = 0;
            GData.greeceData.scoreItalian = 0;
            GData.greeceData.completedHist = 0;
            GData.greeceData.completedHistItalian = 0;
            GData.greeceData.completedGeo = 0;
            GData.greeceData.completedGeoItalian = 0;
        
            GData.polandData.score = 0;
            GData.polandData.scoreItalian = 0;
            GData.polandData.completedHist = 0;
            GData.polandData.completedHistItalian = 0;
            GData.polandData.completedGeo = 0;
            GData.polandData.completedGeoItalian = 0;

            GData.IsSelectAvatar = false;
            NextButton.onClick.RemoveAllListeners();
            NextButton.onClick.AddListener(() => DescriptionsFunc());

            PopupScreen.SetActive(true);
            loadingScreen.SetActive(false);
            showDescription.text = Descriptions[CurrentDescription];

            PersistentDataManager.instance.SaveData();
        }
        else
        {
            GData.isPlayFirstTime = false;
            loadingScreen.SetActive(true);
            PopupScreen.SetActive(false);
            GData.RightAnswer = 0;
            PersistentDataManager.instance.SaveData();
            StartCoroutine(LoadAsyncOperation(1));
        }

    }
    public void DescriptionsFunc()
    {
        CurrentDescription++;
        if (CurrentDescription == 3)
        {
            PopupScreen.SetActive(false);
            StartCoroutine(LoadAsyncOperation(1));

            return;
        }

        showDescription.text = Descriptions[CurrentDescription];

    }

    private IEnumerator LoadAsyncOperation(int SceneIndex)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneIndex);
        loadingScreen.SetActive(true);

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);  // Normalize the progress value
            loadingSlider.value = progress;
            progressText.text = (progress * 100f).ToString("F0") + "%";

            yield return null;
        }

        loadingScreen.SetActive(false);
    }
}
