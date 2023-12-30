
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LocalizedTextUpdater : MonoBehaviour
{

    public TMP_Text[] textComponents;
    public LocalizedString myLocalizedString;

    [SerializeField]
    private LocaleIdentifier specificLanguage;
    [SerializeField]
    private LocaleIdentifier specificLanguage2;


    private bool isAutoUpdateEnabled = true;
    private bool isAutoUpdateEnabled1 = true;


    private void Start()
    {
        // Find all TMP_Text components in the scene
        textComponents = FindObjectsOfType<TMP_Text>();
    }

    private void OnEnable()
    {
        LocalizationSettings.SelectedLocaleChanged += OnLanguageChanged;

        // int temp = PlayerPrefs.GetInt("currentlanguage", 0);
        //Debug.Log(PlayerPrefs.GetInt("currentlanguage", 0));
        //LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[temp];
    }

    private void OnDisable()
    {
        LocalizationSettings.SelectedLocaleChanged -= OnLanguageChanged;
    }

    public void OnLanguageChanged(Locale newLocale)
    {

        bool isSpecificLanguage = newLocale.Identifier.ToString().Equals(specificLanguage.ToString());
        bool isSpecificLanguage2 = newLocale.Identifier.ToString().Equals(specificLanguage2.ToString());

        //Debug.Log(newLocale.Identifier.ToString());
        //Debug.Log("Selected Language is : " + isSpecificLanguage);
        // Enable or disable auto-update based on the selected language
        isAutoUpdateEnabled = !isSpecificLanguage;
        isAutoUpdateEnabled1 = !isSpecificLanguage2;

        // Update the localized text
        UpdateLocalizedText();
    }

    public void UpdateLocalizedText()
    {
        // Find all TMP_Text components in the scene
        //if(PlayerPrefs.GetInt("currentlanguage")==3 || PlayerPrefs.GetInt("currentlanguage") == 5)
        //{
        // Iterate through all TMP_Text components and update their text
        foreach (TMP_Text textComponent in textComponents)
        {
            // Find the LocalizedTextUpdater component on the same game object or its parent
            LocalizedTextUpdater textUpdater = textComponent.GetComponentInParent<LocalizedTextUpdater>();

            if (textUpdater != null && textUpdater.myLocalizedString != null)
            {
                //if (PlayerPrefs.GetInt("currentlanguage") == 3 || PlayerPrefs.GetInt("currentlanguage") == 5)
                //{
                //    // Update the text component with the localized string for the current locale
                //    textComponent.text = ArabicFixer.Fix(textUpdater.myLocalizedString.GetLocalizedString());
                //}
                //else
                //{
                //    print("not fix");
                //}

            }
        }
        //}


       if (isAutoUpdateEnabled && isAutoUpdateEnabled1)
        {

            // Enable auto-update for other languages
            this.GetComponent<TextMeshProUGUI>().text = myLocalizedString.GetLocalizedString();
            ApplyFontOption(GetFontOptionForLanguage(LocalizationSettings.SelectedLocale.Identifier.ToString()));
        }
        else
        {
            // Disable auto-update for the specific language
           // this.GetComponent<TextMeshProUGUI>().text = GetLocalizedTextForSpecificLanguage();
            ApplyFontOption(GetFontOptionForLanguage(LocalizationSettings.SelectedLocale.Identifier.ToString()));
        }
    }

    //private string GetLocalizedTextForSpecificLanguage()
    //{
    //    // Access the localized text from the LocalizedString
    //    string localizedText = myLocalizedString.GetLocalizedString();

    //    // Return the desired localized text for the specific language
    //    // return ArabicFixer.Fix(localizedText);
    //}

    private FontOption GetDefaultFontOption()
    {
        // Find the default font option from the list (e.g., by using a default flag or identifier)
        return LocaleSelector.instance.fontOptions[0];
    }

    private FontOption GetFontOptionForLanguage(string language)
    {

        // Find the font option for the specified language from the list (e.g., by matching language or identifier)
        foreach (FontOption option in LocaleSelector.instance.fontOptions)
        {
            if (option.languageIdentifier.ToString().Equals(language))
            {
                return option;
            }
        }

        // If no specific font option is found, return the default font option
        return GetDefaultFontOption();
    }

    private void ApplyFontOption(FontOption fontOption)
    {
        this.GetComponent<TextMeshProUGUI>().font = fontOption.font;
        // Apply other font-related settings if necessary (e.g., font size, style, etc.)
    }

}
