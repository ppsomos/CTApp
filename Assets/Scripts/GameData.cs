using UnityEngine;

[CreateAssetMenu(fileName = "GData", menuName = "GameData")]
public class GameData : ScriptableObject
{
    public bool isFirstTime;
    public bool isPlayFirstTime;
    public bool isSound;
    public bool isMusic;
    public bool isVibrate;
    public bool isMultiplayer;
    public int selectedLanguage;
    public int roomLockedIndex;
    public int MultiplayerroomUnlocked;
    public int selectedAvater;
    public bool IsSelectAvatar;
    public string playerName;
    public int SelectedLevel;
    public ManagersData ukData;
    public ManagersData belgiumData;
    public ManagersData greeceData;
    public ManagersData polandData;
    public int RightAnswer;
    public int FirstLevelScore;
    public int SceondLevelScore;
    public int ThirdtLevelScore;
    public int ForthLevelScore;
    public Player[] Multi_Player;
    public string LeaderBoardID;
    public string LeaderBoardName;
    public bool IsselectLeaderboard;

}

[System.Serializable]
public class ManagersData
{
    public int score;
    public int scoreItalian;
    public int completedHist;
    public int completedHistItalian;
    public int completedGeo;
    public int completedGeoItalian;
    public int completedHistpolish;
    public int completedHistGreek;
    public int completedGeoPolish;
    public int completedGeoGreek;
    public int scorepolish;
    public int scoreGreek;
}
[System.Serializable]
public class Player
{
    public string PlayerName;
    public int SelectedAvatar;
    public int RightAnswer;
    public int WrongAnswer;
    public int score;
    public int winMatch;
    public float TimeTaken;
}