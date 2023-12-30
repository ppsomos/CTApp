using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    public GameData GData;
   // public GameObject vibrateOn;
   // public GameObject vibrateOff;
    public GameObject SoundOn;
    public GameObject SoundOff;
    public GameObject MusicOn;
    public GameObject MusicOff;
    public AudioClipsSource Source;
    // Start is called before the first frame update
    void Start()
    {
        StartSoundSetting();
        StartMusciSetting();
       // StartVibrateSetting();
    }

    public void StartSoundSetting()
    {
        if (GData.isSound)
        {
            SoundOff.SetActive(false);
            SoundOn.SetActive(true);
            SoundManager.instance.MusicVolume = 1;

        }
        else
        {
            SoundOff.SetActive(true);
            SoundOn.SetActive(false);
            SoundManager.instance.MusicVolume = 0;
        }
    }
    public void StartMusciSetting()
    {
        if (GData.isMusic)
        {
            MusicOff.SetActive(false);
            MusicOn.SetActive(true);
            SoundManager.instance.EffectsVolume = 1;

        }
        else
        {
            MusicOff.SetActive(true);
            MusicOn.SetActive(false);
            SoundManager.instance.EffectsVolume = 0;
        }
    }
    //public void StartVibrateSetting()
    //{
    //    if (GData.isVibrate)
    //    {
    //        vibrateOff.SetActive(false);
    //        vibrateOn.SetActive(true);
    //        // SoundManager.instance.EffectsVolume = 1;

    //    }
    //    else
    //    {
    //        vibrateOff.SetActive(true);
    //        vibrateOn.SetActive(false);
    //        //SoundManager.instance.EffectsVolume = 0;
    //    }
    //}
    public void GenaricBtn()
    {
        SoundManager.instance.PlayEffect(Source.Btn_Sound);

    }
    public void SoundSettingBtn()
    {
        if (GData.isSound)
        {
            SoundOff.SetActive(true);
            SoundOn.SetActive(false);
            SoundManager.instance.MusicVolume = 0;
            GData.isSound = false;
        }
        else
        {
            SoundOff.SetActive(false);
            SoundOn.SetActive(true);
            SoundManager.instance.MusicVolume = 1;
            GData.isSound = true;
        }
        PersistentDataManager.instance.SaveData();
    }
    public void MuasicSettingBtn()
    {
        if (GData.isMusic)
        {
            MusicOff.SetActive(true);
            MusicOn.SetActive(false);
            SoundManager.instance.EffectsVolume = 0;
            GData.isMusic = false;
        }
        else
        {
            MusicOff.SetActive(false);
            MusicOn.SetActive(true);
            GData.isMusic = true;
            SoundManager.instance.EffectsVolume = 1;

        }
        PersistentDataManager.instance.SaveData();
    }
    //public void VibrateBtn()
    //{
    //    if (GData.isVibrate)
    //    {
    //        vibrateOff.SetActive(true);
    //        vibrateOn.SetActive(false);
    //        GData.isVibrate = false;
    //    }
    //    else
    //    {
    //        vibrateOff.SetActive(false);
    //        vibrateOn.SetActive(true);
    //        GData.isVibrate = true;
    //    }
    //    PersistentDataManager.instance.SaveData();
    //}
}
