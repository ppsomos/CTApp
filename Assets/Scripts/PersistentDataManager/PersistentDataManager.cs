using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentDataManager : MonoBehaviour
{
    public GameData gameData;

    #region Singleton
    public static PersistentDataManager instance;
    void Awake()
    {
        GetInstance();
    }

    void GetInstance()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    void Start()
    {
        LoadData();
        // PlayerPrefs.DeleteAll();
    }

    void OnApplicationQuit()
    {
        SaveData();
    }

    public void SaveData()
    {
        string gameDataString = JsonConvert.SerializeObject(gameData);
        PlayerPrefs.SetString("GameData", gameDataString);
        print("GameData Saved In PlayerPrefs: " + PlayerPrefs.GetString("GameData"));
    }

    public void LoadData()
    {
        string gameDataString = PlayerPrefs.GetString("GameData");
        GameData gameDataFromPlayerPrefs = JsonConvert.DeserializeObject<GameData>(gameDataString);
        if (gameDataFromPlayerPrefs == null)
        {
            print("Game is played first time. No GameData found.");
            return;
        }
        print("GameData Loaded From PlayerPrefs");

        // Set Local GameData Variables Here - Start
        //gameData.coins = gameDataFromPlayerPrefs.coins;
        gameData.isFirstTime = gameDataFromPlayerPrefs.isFirstTime;
        gameData.isSound = gameDataFromPlayerPrefs.isSound;
        gameData.isMusic = gameDataFromPlayerPrefs.isMusic;
        gameData.isVibrate = gameDataFromPlayerPrefs.isVibrate;
        gameData.selectedLanguage = gameDataFromPlayerPrefs.selectedLanguage;
        gameData.roomLockedIndex = gameDataFromPlayerPrefs.roomLockedIndex;
        gameData.selectedAvater = gameDataFromPlayerPrefs.selectedAvater;
        gameData.playerName = gameDataFromPlayerPrefs.playerName;

        gameData.ukData.score = 0;
        gameData.ukData.scoreItalian = 0;
        gameData.ukData.completedHist = 0;
        gameData.ukData.completedHistItalian = 0;
        gameData.ukData.completedGeo = 0;
        gameData.ukData.completedGeoItalian = 0;
        
        gameData.belgiumData.score = 0;
        gameData.belgiumData.scoreItalian = 0;
        gameData.belgiumData.completedHist = 0;
        gameData.belgiumData.completedHistItalian = 0;
        gameData.belgiumData.completedGeo = 0;
        gameData.belgiumData.completedGeoItalian = 0;
        
        gameData.greeceData.score = 0;
        gameData.greeceData.scoreItalian = 0;
        gameData.greeceData.completedHist = 0;
        gameData.greeceData.completedHistItalian = 0;
        gameData.greeceData.completedGeo = 0;
        gameData.greeceData.completedGeoItalian = 0;
        
        gameData.polandData.score = 0;
        gameData.polandData.scoreItalian = 0;
        gameData.polandData.completedHist = 0;
        gameData.polandData.completedHistItalian = 0;
        gameData.polandData.completedGeo = 0;
        gameData.polandData.completedGeoItalian = 0;

       
        //for(int i = 0; i < gameData.AllVehicles.Length; i++)
        //{
        //    gameData.AllVehicles[i] = gameDataFromPlayerPrefs.AllVehicles[i];
        //}
        // Set Local GameData Variables Here - End
    }
}
