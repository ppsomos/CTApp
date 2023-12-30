using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public CountDown countDown;
    public void changescene()
    {

        SceneManager.LoadSceneAsync("Musem scene");

        countDown.timeRemaining = 300f;
        countDown.timerIsRunning = true;
        PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
        PlayerPrefs.Save();
    }
    public void Home()
    {

        SceneManager.LoadSceneAsync("Mainscene");
    
    }
}
