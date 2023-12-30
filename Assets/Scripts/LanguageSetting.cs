using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSetting : MonoBehaviour
{
    private TMP_Text textComponent;

    private void Start()
    {
        
    }
    private void OnEnable()
    {
        if (gameObject.GetComponent<TMP_Text>() != null)
        {
            textComponent = GetComponent<TMP_Text>();
            FontManager.Instance.RegisterTextObject(textComponent);
            FontManager.Instance.UpdateFont();
        }       
    }

    private void Update()
    {
      //  updateFont();
    }
    public void updateFont()
    {
        if (gameObject.GetComponent<TMP_Text>() != null)
        {
            textComponent = GetComponent<TMP_Text>();
            FontManager.Instance.RegisterTextObject(textComponent);
            FontManager.Instance.UpdateFont();
        }
    }
}
