using UnityEngine;
using UnityEngine.UI;

public class AudioClipsSource : MonoBehaviour
{
    [Header("Music Clips")]
    public AudioClip Btn_Sound;
    public AudioClip BG_Sound;

    public AudioSource MusicSource;
    public AudioSource ButtonSource;


    public Slider MusicSlider;
    public Slider ButtonSlider;

    private void Start()
    {
        // Initialize the slider value with the current music volume
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        ButtonSlider.value = PlayerPrefs.GetFloat("ButtonVolume", 1f);
    }

    public void SetMusicVolume()
    {
        // Update the music volume based on the slider value
        MusicSource.volume = MusicSlider.value;
        // Save the current volume setting in PlayerPrefs to persist it across scenes/restarts
        PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
    }
    public void SetButtonVolume()
    {
        // Update the music volume based on the slider value
        ButtonSource.volume = ButtonSlider.value;
        // Save the current volume setting in PlayerPrefs to persist it across scenes/restarts
        PlayerPrefs.SetFloat("ButtonVolume", ButtonSlider.value);
    }
}
