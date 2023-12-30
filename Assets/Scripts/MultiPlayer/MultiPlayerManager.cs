using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MultiPlayerManager : MonoBehaviour
{
    public TMP_InputField PlayerName_InputField;
    public GameObject Player1Avatar;
    public GameObject Player1Text;
    public GameObject Player2Text;
    public GameObject Player2Avatar;
    public Button OkButton;
    public GameData GameData;
    public GameObject Multiplayer_Page;
    public GameObject SelectLevel_Page;
    public int playerNo;

    private void Start()
    {
        Player1Text.SetActive(true);
        playerNo = 0;

        OkButton.onClick.RemoveAllListeners();
        OkButton.onClick.AddListener(OkButtonPressed);

        Player1Avatar.GetComponent<Button>().onClick.RemoveAllListeners();
        Player1Avatar.GetComponent<Button>().onClick.AddListener(() => SelecAvatar(1));

        Player2Avatar.GetComponent<Button>().onClick.RemoveAllListeners();
        Player2Avatar.GetComponent<Button>().onClick.AddListener(() => SelecAvatar(2));
    }

    private void OkButtonPressed()
    {
        if (string.IsNullOrEmpty(PlayerName_InputField.text))
        {
            switch (GameData.selectedLanguage)
            {
                case 0:
                    PlayerName_InputField.text = "Please Input Name";
                    break;
                case 1:
                    PlayerName_InputField.text = "Παρακαλώ εισάγετε Όνομα";
                    break;
            }

            PlayerName_InputField.textComponent.color = Color.red;
            StartCoroutine(NormalizedText());
            return;
        }
        
       if (GameData.Multi_Player[playerNo].SelectedAvatar==0)
        {
            Debug.Log("red");
            Player1Avatar.transform.GetChild(1).GetComponent<Image>().color = Color.red;
            Player2Avatar.transform.GetChild(1).GetComponent<Image>().color = Color.red;
            StartCoroutine(NormalizedColor());
            return;
        }

        GameData.Multi_Player[playerNo].PlayerName = PlayerName_InputField.text;
        playerNo++;
        Player1Text.SetActive(false);
        Player2Text.SetActive(true);
        ClearAllFields();
        PersistentDataManager.instance.SaveData();

        if (playerNo == 2)
        {
            Multiplayer_Page.SetActive(false);
            SelectLevel_Page.SetActive(true);
        }
    }
    private void SelecAvatar(int index)
    {
        if (index == 1)
        {
            Player1Avatar.transform.GetChild(0).gameObject.SetActive(true);
            Player2Avatar.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            Player1Avatar.transform.GetChild(0).gameObject.SetActive(false);
            Player2Avatar.transform.GetChild(0).gameObject.SetActive(true);
        }
        GameData.Multi_Player[playerNo].SelectedAvatar = index;
    }

    private IEnumerator NormalizedText()
    {
        yield return new WaitForSeconds(1f);
        PlayerName_InputField.text = string.Empty;
        PlayerName_InputField.textComponent.color = Color.white;
    }
    private IEnumerator NormalizedColor()
    {
        yield return new WaitForSeconds(1f);
        Player1Avatar.transform.GetChild(1).GetComponent<Image>().color = Color.white;
        Player2Avatar.transform.GetChild(1).GetComponent<Image>().color = Color.white;
    }

    private void ClearAllFields()
    {
        PlayerName_InputField.text = string.Empty;
        Player1Avatar.transform.GetChild(0).gameObject.SetActive(false);
        Player2Avatar.transform.GetChild(0).gameObject.SetActive(false);
    }


}


