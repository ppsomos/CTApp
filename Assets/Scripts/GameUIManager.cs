using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;
    public DataBaseHandler dataBaseHandler;
    public GameData GData;
    //public GameObject TimeHandler;
    public GameObject ScorePanal;
    //public GameObject End_MatchBtn;
    //public GameObject RestartBtn;
    //public GameObject HomeBtn;
    public TMP_Text Player1NameText;
    public TMP_Text Player1RightAnserText;
    public TMP_Text Player1WrongAnserText;
    public TMP_Text Player1ScoreText;
    //public TMP_Text Player1TimeText;
    public TMP_Text Player2NameText;
    public TMP_Text Player2RightAnserText;
    public TMP_Text Player2WrongAnserText;
    public TMP_Text Player2ScoreText;
   // public TMP_Text Player2TimeText;
    public GameObject MatchDraw;
    public GameObject Player1WinBadg;
    public GameObject Player2WinBadg;
    public GameObject[] Player1Avatars;
    public GameObject[] Player2Avatars;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCompetitionComplete()
    {
        Debug.Log(GData.Multi_Player[0].PlayerName);
        Debug.Log(GData.Multi_Player[1].PlayerName);
        Player1Avatars[GData.Multi_Player[0].SelectedAvatar - 1].SetActive(true);
        Player2Avatars[GData.Multi_Player[1].SelectedAvatar - 1].SetActive(true);
        Player1NameText.text = GData.Multi_Player[0].PlayerName;
        Player1RightAnserText.text = ": " + GData.Multi_Player[0].RightAnswer.ToString();
        Player1WrongAnserText.text = ": " + GData.Multi_Player[0].WrongAnswer.ToString();
        Player1ScoreText.text = ": " + (GData.Multi_Player[0].RightAnswer * 5).ToString();
        GData.Multi_Player[0].score = int.Parse((GData.Multi_Player[0].RightAnswer * 5).ToString());
        // DisplayPlayer1Time(GData.Multi_Player[0].TimeTaken);
        Player2NameText.text = GData.Multi_Player[1].PlayerName;
        Player2RightAnserText.text = ": " + GData.Multi_Player[1].RightAnswer.ToString();
        Player2WrongAnserText.text = ": " + GData.Multi_Player[1].WrongAnswer.ToString();
        Player2ScoreText.text = ": " + (GData.Multi_Player[1].RightAnswer * 5).ToString();
        GData.Multi_Player[1].score = int.Parse((GData.Multi_Player[1].RightAnswer * 5).ToString());
        //  DisplayPlayer2Time(GData.Multi_Player[1].TimeTaken);
        if (GData.Multi_Player[0].RightAnswer > GData.Multi_Player[1].RightAnswer)
        {
            Player1WinBadg.SetActive(true);
            GData.Multi_Player[0].winMatch = 1;
        }
        else if (GData.Multi_Player[0].RightAnswer < GData.Multi_Player[1].RightAnswer)
        {
            Player2WinBadg.SetActive(true);
            GData.Multi_Player[1].winMatch = 1;
        }
        else if (GData.Multi_Player[0].RightAnswer == GData.Multi_Player[1].RightAnswer)
        {
            GData.Multi_Player[0].winMatch = 0;
            GData.Multi_Player[1].winMatch = 0;
            MatchDraw.SetActive(true);
        }
        dataBaseHandler.SUbmitButton();
        ScorePanal.SetActive(true);
    }
}
