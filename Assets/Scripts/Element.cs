using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour
{
    public Text usernameText;
    public Text WinText;
    public Text ScoreText;
    public Text RankText;
    public Text MatchPlayedText;
    public void NewScoreElement(string _username, int _Win, int _Score, int _rank,int _MatchPlayed)
    {
        usernameText.text = _username;
        WinText.text = _Win.ToString();
        ScoreText.text = _Score.ToString();
        RankText.text = _rank.ToString();
        MatchPlayedText.text = _MatchPlayed.ToString();
    }
}
