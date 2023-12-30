using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageTextUpdate : MonoBehaviour
{
    private void OnEnable()
    {
        if (this.gameObject.activeInHierarchy == true && LocaleSelector.instance != null)
        {
            LocaleSelector.instance.ChangeLocale();
        }
    }
}
