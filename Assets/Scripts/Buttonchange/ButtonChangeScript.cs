using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChangeScript : MonoBehaviour
{
    public Sprite SoundOnImage;
    public Sprite SoundOffImage;
    private bool IsOn = true;
    public Button _button;
    void Start()
    {
        SoundOnImage = _button.image.sprite;
    }

   public void buttonclicked()
    {
        if (IsOn)
        {
            _button.image.sprite = SoundOffImage;
            IsOn = false;
        }
        else
        {
            _button.image.sprite = SoundOnImage;
            IsOn = true;
        }

    }
}
