using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AvatarSelectionHandler : MonoBehaviour
{
    public GameData GData;
    public TMP_InputField PlayerName;
    public TextMeshProUGUI MisingText;
    public GameObject AvaterSlectionObj;
    public GameObject[] PlayerAvatar;
    public GameObject[] mainmauAvatar;
    public GameObject EnterName;
    public TMP_InputField PlayerNameText;
    public Text PlayerNameTextColor;
    public GameObject displaytext;
    public GameObject MainMeNuPanel;
    // Start is called before the first frame update
    void Start()
    {
        if (GData.isPlayFirstTime)
        {
            Debug.Log("00000");
            AvaterSlectionObj.SetActive(true);
            MainMeNuPanel.SetActive(false);
            PersistentDataManager.instance.SaveData();
        }
        else
        {
            int val = PlayerPrefs.GetInt("Flag");
            if (val == 1)
            {
                Debug.Log("111111");
                MainMeNuPanel.SetActive(false);
                PlayerPrefs.SetInt("Flag", 0);
            }
            else
            {
                Debug.Log("22222");
                AvaterSlectionObj.SetActive(false);
                MainMeNuPanel.SetActive(true);
                AvaterSelection(GData.selectedAvater);
                displaytext.GetComponent<Text>().text = GData.playerName;
            }
          
        }
    }
    public void AvaterSelection(int sel)
    {


            GData.selectedAvater = sel;

            for (int i = 0; i < PlayerAvatar.Length; i++)
            {
                PlayerAvatar[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            PlayerAvatar[sel].transform.GetChild(0).gameObject.SetActive(true);
            GData.IsSelectAvatar = true;
            for (int i = 0; i < mainmauAvatar.Length; i++)
            {
                mainmauAvatar[i].SetActive(false);
            }
            mainmauAvatar[GData.selectedAvater].SetActive(true);
            PersistentDataManager.instance.SaveData();
        
    }
    public void StoreName()
    {
        GData.isPlayFirstTime = false;
        
        if (string.IsNullOrEmpty(PlayerNameText.text) )
        {
            MisingText.text = "Please Enter Name";
            MisingText.color = Color.red;
            EnterName.SetActive(false);
            StartCoroutine(RemoveText());
           
        }
        else if (GData.IsSelectAvatar == false)
        {
            for (int i = 0; i < PlayerAvatar.Length; i++)
            {
                PlayerAvatar[i].transform.GetChild(0).gameObject.SetActive(true);
            }
            StartCoroutine(RemoveAvtar());
        }
        else
        {
            GData.playerName = PlayerNameText.text;
            PersistentDataManager.instance.SaveData();
            displaytext.GetComponent<Text>().text = GData.playerName;
            AvaterSlectionObj.SetActive(false);
            MainMeNuPanel.SetActive(true);
        }

       
    }
    IEnumerator RemoveText()
    {
        yield return new WaitForSeconds(0.5f);
        MisingText.text = "";
        MisingText.color = Color.white;
        EnterName.SetActive(true);
    }
    IEnumerator RemoveAvtar()
    {
        yield return new WaitForSeconds(0.5f);
       
        for (int i = 0; i < PlayerAvatar.Length; i++)
        {
            PlayerAvatar[i].transform.GetChild(0).gameObject.SetActive(false);
        }
        
    }
    public void EditProfiel()
    {
        MainMeNuPanel.SetActive(false);
        AvaterSlectionObj.SetActive(true);
        PlayerNameText.GetComponent<Text>().text = GData.playerName;
        for (int i = 0; i < PlayerAvatar.Length; i++)
        {
            PlayerAvatar[i].transform.GetChild(0).gameObject.SetActive(false);
        }
        PlayerAvatar[GData.selectedAvater].transform.GetChild(0).gameObject.SetActive(true);
    }

}
