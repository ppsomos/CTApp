using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardsElement : MonoBehaviour
{
    public string id;
    public Text nameText;
    public Text IDText;
    public Button buttons;
    public GameData Gdata;
    public static LeaderBoardsElement selectedElement; // Track the currently selected element

    public DataBaseHandler dataBaseHandler;

    public string ID { get; private set; }

    public void NewLElement(string _Lname, string _ID )
    {
        nameText.text = _Lname;
        IDText.text = _ID.ToString();
        ID = _ID;
    }
    private void Awake()
    {
        dataBaseHandler = FindObjectOfType<DataBaseHandler>();
    }
    public void ButtonSelect()
    {
        // If another element was previously selected, deselect it
        if (selectedElement != null)
        {
            selectedElement.buttons.transform.GetChild(0).gameObject.SetActive(false);
        }

        // Activate the button of the current element
        buttons.transform.GetChild(0).gameObject.SetActive(true);

        // Set the current element as the selected element
        selectedElement = this;
        // Save the selected ID in your game data manager or wherever you want
        Gdata.LeaderBoardID= ID;
        Gdata.LeaderBoardName = nameText.text;

        dataBaseHandler.ScoreBoardLoadButton();
        Gdata.IsselectLeaderboard = true;

    }
}
