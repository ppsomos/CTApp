using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MultplayerLevelUnlock : MonoBehaviour
{
    public GameData GData;
    public MultiPlayerManager MP;
    // Start is called before the first frame update
    void Start()
    {
       Invoke("ResetData", 2f);
        //levelunlock();
    }

   public void levelunlock()
    {
        
    }
    public void ResetData()
    {
        MP.playerNo = 0;
        MP.PlayerName_InputField.GetComponent<InputField>().text = null;
        MP.Player1Avatar.transform.GetChild(0).gameObject.SetActive(false);
        MP.Player2Avatar.transform.GetChild(0).gameObject.SetActive(false);
        MP.Player1Text.SetActive(true);
        MP.Player2Text.SetActive(false);
        GameManager.Instance.isMultiplayer = false;
        for (int i = 0; i < GData.Multi_Player.Length; i++)
        {
            GData.Multi_Player[i].PlayerName = null;
            GData.Multi_Player[i].SelectedAvatar = 0;
            GData.Multi_Player[i].RightAnswer = 0;
            GData.Multi_Player[i].WrongAnswer = 0;
            GData.Multi_Player[i].TimeTaken = 0;
            PersistentDataManager.instance.SaveData();
        }
       
    }
}
