using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public GameObject loadingscreen;
    public Slider _slider;
    public void levelLoad(int sceneindex)
    {
        StartCoroutine(loadasyncouronsly(sceneindex));
    }
    IEnumerator loadasyncouronsly(int sceneindex)
    {
        loadingscreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneindex);
        //loadingscreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            _slider.value = progress;
            //progresstext.text = progress * 100f + "%";
            yield return null;
        }
    }
}

