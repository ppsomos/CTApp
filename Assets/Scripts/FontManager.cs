using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FontManager : MonoBehaviour
{
    public static FontManager Instance;
    public GameData GData;

    [Header("TMP")]
    public TMP_FontAsset EnglishFont;
    //public TMP_FontAsset ItalianFont;
    public TMP_FontAsset GreekFont;
    public TMP_FontAsset PolishFont;
  

    public List<TMP_Text> textObjects = new List<TMP_Text>();
   

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void RegisterTextObject(TMP_Text textObject)
    {
        textObjects.Add(textObject);
    }

    


    public void ChangeFontForLanguage(TMP_FontAsset font)
    {
        // Create a new list to store text objects without null references
        List<TMP_Text> validTextObjects = new List<TMP_Text>();

        // Iterate through the original list and filter out null references
        foreach (TMP_Text textObject in textObjects)
        {
            if (textObject != null)
            {
                validTextObjects.Add(textObject);
            }
        }

        // Update the original list with the filtered list
        textObjects = validTextObjects;

        // Set the font for each valid text object
        foreach (TMP_Text textObject in textObjects)
        {
            textObject.font = font;
        }
    }




    public void UpdateFont()
    {
       // print("update font");
        if (PlayerPrefs.GetInt("language") == 0)
        {
            ChangeFontForLanguage(EnglishFont);
            
        }
        //else if (PlayerPrefs.GetInt("language") == 1)
        //{
        //    ChangeFontForLanguage(ItalianFont);

        //}
        else if (PlayerPrefs.GetInt("language") == 2)
        {
            Debug.Log("greek Language");
            ChangeFontForLanguage(GreekFont);
            
        }
        else if (PlayerPrefs.GetInt("language") == 3)
        {
            ChangeFontForLanguage(PolishFont);
            
        }

    }
    public void DefaultFont()
    {
        ChangeFontForLanguage(EnglishFont);
        
    }
}
