using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CountDown : MonoBehaviour
{
    public float timeRemaining = 900f;
    public bool timerIsRunning = false;
    public TMP_Text timeText;

    public GameObject tryagain_panal;
    public GameObject quiz_panal;
    public GameObject moveCanvas;
    public GameObject MainCanvas;
    public GameObject Quizcamera;
    public GameObject quizCanvas;
  
    
    
    private void Start()
    {
        if(PlayerPrefs.GetFloat("TimeRemaining") == 0)
        {
            PlayerPrefs.SetFloat("TimeRemaining", timeRemaining);
            PlayerPrefs.Save();
        }
        else
        {
            timeRemaining = PlayerPrefs.GetFloat("TimeRemaining");
        }

        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                PlayerPrefs.SetFloat("TimeRemaining", timeRemaining);
                PlayerPrefs.Save();

                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                tryagain_panal.SetActive(true);
                moveCanvas.SetActive(false);
                quiz_panal.SetActive(false);
                quizCanvas.SetActive(false);
                Quizcamera.SetActive(false);
                MainCanvas.SetActive(true);
            }
        }
    }

   


    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}