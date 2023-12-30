using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    public static LocaleSelector instance { get; private set; }
    private bool _active = false;
    public TMP_Dropdown dropdown;
    public TMP_Dropdown dropdown1;
    //public SetArabicText arabicTextObj;
    public FontOption[] fontOptions;

    // The key for saving/loading the selected language
    private const string SelectedLanguageKey = "SelectedLanguage";

    private void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        StartCoroutine(SetLocale());
    }

    

    public void ChangeLocale()
    {

        if (_active)
        {
            return;
        }
        StartCoroutine(SetLocale());
    }

    private IEnumerator SetLocale()
    {
        _active = true;

        yield return LocalizationSettings.InitializationOperation;


        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[PlayerPrefs.GetInt("language")];

        // Check if the selected locale has a valid table reference in the LocalizedString component
        LocalizedTextUpdater[] textUpdaters = FindObjectsOfType<LocalizedTextUpdater>();

        foreach (LocalizedTextUpdater textUpdater in textUpdaters)
        {
            //LocalizedString localizedString = textUpdater.GetComponent<LocalizedString>();

            if (textUpdater != null && textUpdater.myLocalizedString.GetLocalizedString() != null)
            {
                textUpdater.OnLanguageChanged(LocalizationSettings.SelectedLocale);
            }
        }

        _active = false;
    }

    public void SelectLanguage(int index)
    {
        TMP_Dropdown temp;

        if (index == 0)
        {
            temp = dropdown;
        }
        else
        {
            temp = dropdown1;
        }

        int value = temp.value;
        Debug.Log("Selected Value: " + value);

        switch (value)
        {
            case 0:
                Debug.Log("000");
                PlayerPrefs.SetInt("currentlanguage", value);
                PlayerPrefs.Save();
                break;
            case 1:
                Debug.Log("Came");
                PlayerPrefs.SetInt("currentlanguage", value);
                PlayerPrefs.Save();
                break;
            case 2:
                PlayerPrefs.SetInt("currentlanguage", value);
                PlayerPrefs.Save();
                break;
            case 3:
                PlayerPrefs.SetInt("currentlanguage", value);
                PlayerPrefs.Save();
                break;
            case 4:
                PlayerPrefs.SetInt("currentlanguage", value);
                PlayerPrefs.Save();
                break;
            case 5:
                PlayerPrefs.SetInt("currentlanguage", value);
                PlayerPrefs.Save();
                break;
            case 6:
                PlayerPrefs.SetInt("currentlanguage", value);
                PlayerPrefs.Save();
                break;
            case 7:
                PlayerPrefs.SetInt("currentlanguage", value);
                PlayerPrefs.Save();
                break;
            case 8:
                PlayerPrefs.SetInt("currentlanguage", value);
                PlayerPrefs.Save();
                break;
            case 9:
                PlayerPrefs.SetInt("currentlanguage", value);
                PlayerPrefs.Save();
                break;
        }

        Debug.Log(PlayerPrefs.GetInt("currentlanguage"));

        ChangeLocale();

    }



}
[System.Serializable]
public class FontOption
{
    public LocaleIdentifier languageIdentifier;
    public TMP_FontAsset font;
}