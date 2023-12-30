using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Linq;
using System;
using EasyMobile;
using UnityEngine.InputSystem;
using Firebase.Extensions;
using TMPro;

public class DataBaseHandler : MonoBehaviour
{
   // public static DataBaseHandler Instance;

    public DatabaseReference DbReference;
    public GameObject scoreElement;
    public Transform scoreboardContent;
    public GameObject scoreLElement;
    public Transform scoreboardLContent;
    public int RankPlayer = 1;
    public GameObject ScoreBoardPanel;
    public GameObject LeaderBoardPanel;
    public GameObject MainMenuPanel;
    public GameObject CreatePanel;
    private bool isScoreboardLoaded = false;
    private List<GameObject> instantiatedElements = new List<GameObject>();
    [Header("PLayer1Data")]
    public InputField NameField;
    public InputField IDField;
    public static bool gameComplete;
    public GameData GData;
    public GameObject MessageText;
    [SerializeField]
    private GameObject searchandCreateMessage;
    [SerializeField]
    private GameObject searchMessage;
    public TextMeshProUGUI LeaderboardNameText;
    public TextMeshProUGUI LeaderboardIDText;
    public InputField SearchIDField;

    //private void Awake()
    //{
    //    //Singleton method
    //    if (Instance == null)
    //    {
    //        //First run, set the instance
    //        Instance = this;
    //        DontDestroyOnLoad(gameObject);

    //    }
    //    else if (Instance != this)
    //    {
    //        //Instance is not the same as the one we have, destroy old one, and reset to newest one
    //        Destroy(Instance.gameObject);
    //        Instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //}
    //private void Awake()
    //{
    //    // Instance= this; 
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    // Start is called before the first frame update
    void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                InitializeFirebase();

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });

    }

    void InitializeFirebase()
    {
        DbReference = FirebaseDatabase.DefaultInstance.RootReference;
       // UpdateData();
    }

    public void UpdateData()
    {
        if (gameComplete)
        {
            gameComplete = false;
        }
    }

    [ContextMenu("called")]
    public void SUbmitButton()
    {
        print("called");
        StartCoroutine(CheckIfPlayerExistsAndUpdate(GData.Multi_Player[0].PlayerName, (exists, playerData) =>
        {
            if (exists)
            {
                // Player exists, do something with the data
                Debug.Log($"Player exists! PlayerName: {playerData.name}, Score: {playerData.score}");

                playerData.score += GData.Multi_Player[0].score;
                playerData.winning += GData.Multi_Player[0].winMatch;
                playerData.totalMatch += 1;
                StartCoroutine(UpldatePlayerData(playerData.name, playerData.winning, playerData.score, playerData.totalMatch));
            }
            else
            {
                // Player does not exist
                Debug.Log("Player does not exist");
                StartCoroutine(CreatePlayer(GData.Multi_Player[0].PlayerName, GData.Multi_Player[0].winMatch, GData.Multi_Player[0].score, 1));
            }
        }));
        StartCoroutine(CheckIfPlayerExistsAndUpdate(GData.Multi_Player[1].PlayerName, (exists, playerData) =>
        {
            if (exists)
            {
                // Player exists, do something with the data
                Debug.Log($"Player exists! PlayerName: {playerData.name}, Score: {playerData.score}");

                playerData.score += GData.Multi_Player[1].score;
                playerData.winning += GData.Multi_Player[1].winMatch;
                playerData.totalMatch += 1;
                StartCoroutine(UpldatePlayerData(playerData.name, playerData.winning, playerData.score, playerData.totalMatch));
            }
            else
            {
                // Player does not exist
                Debug.Log("Player does not exist");
                StartCoroutine(CreatePlayer(GData.Multi_Player[1].PlayerName, GData.Multi_Player[1].winMatch, GData.Multi_Player[1].score, 1));
            }
        }));

    }
    public void ScoreBoardLoadButton()
    {
        StartCoroutine(LoadScoreboardData());

    }
 
    public void CreateLeaderBoard()
    {
        StartCoroutine(UpdateLname(int.Parse(IDField.text), NameField.text));
        //StartCoroutine(UpdateIDLBoard(int.Parse(IDField.text)));
    }
    private IEnumerator UpdateLname(int id ,string _Lname)
    {
        LeaderBoard leaderBoard = new LeaderBoard(id,_Lname);
        // Convert the leaderboard object to JSON
        string json = JsonUtility.ToJson(leaderBoard);
        ////Set the currently logged in user username in the database
        Task DBTask = DbReference.Child("LeaderBoards").Child(id.ToString()).SetRawJsonValueAsync(json);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database username is now updated
        }

        MainMenuPanel.SetActive(true);
        CreatePanel.SetActive(false);
    }

    public void loadscoreBoard()
    {
        print("enter");
        if (!isScoreboardLoaded)
        {
            print("load");
            StartCoroutine(LoadScoreboards());
           // isScoreboardLoaded = true; // Set the flag to true after initiating the loading
        }
        else
        {
            Debug.Log("data is allready loaded");
          
        }
    }
   
    private IEnumerator LoadScoreboards()
    {
        searchandCreateMessage.SetActive(true);
        //Get all the users data ordered by Score amount
        Task<DataSnapshot> DBTask = DbReference.Child("LeaderBoards").GetValueAsync();
        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Data has been retrieved
            DataSnapshot snapshot = DBTask.Result;
            //Destroy any existing scoreboard elements
            foreach (Transform child in scoreboardContent.transform)
            {
                Destroy(child.gameObject);
            }


            // Loop through every user's UID
            foreach (DataSnapshot childSnapshot in snapshot.Children.Reverse<DataSnapshot>())
            {
                // Extract user data
                string Lname = childSnapshot.Child("name").Value.ToString();
                string ID = childSnapshot.Child("id").Value.ToString();

                // int score = int.Parse(childSnapshot.Child("Score").Value.ToString());

                // Instantiate new scoreboard elements
                GameObject scoreboardLElement = Instantiate(scoreLElement, scoreboardLContent);
                scoreboardLElement.GetComponent<LeaderBoardsElement>().NewLElement(Lname, ID);
                scoreboardLElement.GetComponent<LeaderBoardsElement>().id = ID;
                instantiatedElements.Add(scoreboardLElement);
                scoreboardLElement.SetActive(false);
            }

        }


    }
    private void ClearInstantiatedElements()
    {
        // Destroy each instantiated element and clear the list
        foreach (var element in instantiatedElements)
        {
            Destroy(element);
        }
        instantiatedElements.Clear();
        SearchIDField.text = string.Empty;

    }
    public void ClosePanel()
    {
        // Clear the list of instantiated elements
        ClearInstantiatedElements();
        searchandCreateMessage.SetActive(false);
        searchMessage.SetActive(false);
        // Additional code to close the panel
    }
    public void LeaderboardButtonClick()
    {
        if(GData.IsselectLeaderboard)
        {
            ScoreBoardLoadButton();
            ScoreBoardPanel.SetActive(true);
            MainMenuPanel.SetActive(false);
        }
        else
        {
            loadscoreBoard();
            LeaderBoardPanel.SetActive(true);
            MainMenuPanel.SetActive(false);
        }
    }

    private IEnumerator CreatePlayer(string UserName, int Winning, int Score, int TotalMatch)
    {

        // Create a Player object with the provided data
        Player player = new Player(UserName, Winning, Score, TotalMatch);

        // Convert the Player object to JSON
        string json = JsonUtility.ToJson(player);

        // Generate a custom key (e.g., using the UserName)
        string key = UserName;

        // Create a reference with the custom key
        DatabaseReference playerRef = DbReference.Child("LeaderBoards").Child(GData.LeaderBoardID).Child("users").Child(key);

        // Set the data at the custom key in the database
        Task setTask = playerRef.SetRawJsonValueAsync(json);

        yield return new WaitUntil(() => setTask.IsCompleted);

        if (setTask.Exception != null)
        {
            Debug.LogWarning($"Failed to create player with key {key}: {setTask.Exception}");
        }
        else
        {
            Debug.Log($"Player created successfully with key {key}");
        }
    }

    private IEnumerator UpldatePlayerData(string UserName, int Winning, int Score, int TotalMatch)
    {
        Player player = new Player(UserName, Winning, Score, TotalMatch);

        string json = JsonUtility.ToJson(player);
        //Set the currently logged in user username in the database
        Task DBTask = DbReference.Child("LeaderBoards").Child(GData.LeaderBoardID).Child("users").Child(UserName).SetRawJsonValueAsync(json);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database username is now updated
        }

    }

    private IEnumerator LoadScoreboardData()
    {
        print("load scoreboard data");
        LeaderboardNameText.text = GData.LeaderBoardName;
        LeaderboardIDText.text = GData.LeaderBoardID;
        //Get all the users data ordered by Score amount
        Task<DataSnapshot> DBTask = DbReference.Child("LeaderBoards").Child(GData.LeaderBoardID).Child("users").GetValueAsync();
        // Task<DataSnapshot> DBTask = DbReference.Child("users").OrderByChild("WinMatch").GetValueAsync();
        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Data has been retrieved
            DataSnapshot snapshot = DBTask.Result;
            //Destroy any existing scoreboard elements
            foreach (Transform child in scoreboardContent.transform)
            {
                Destroy(child.gameObject);
            }
            if (!snapshot.HasChildren)
            {
                // No records found, display a message
                Debug.Log("No records found in the database.");
                MessageText.SetActive(true);
                ScoreBoardPanel.SetActive(true);
                LeaderBoardPanel.SetActive(false);
               
            }
            else
            {
                List<PlayerData> playerList = new List<PlayerData>();

                // Loop through every user's UID
                foreach (DataSnapshot childSnapshot in snapshot.Children.Reverse<DataSnapshot>())
                {
                    // Extract user data
                    string username = childSnapshot.Child("name").Value.ToString();
                    int winMatch = int.Parse(childSnapshot.Child("winning").Value.ToString());
                    int score = int.Parse(childSnapshot.Child("score").Value.ToString());
                    int Matchplay = int.Parse(childSnapshot.Child("totalMatch").Value.ToString());
                    // Create a new PlayerData instance
                    PlayerData player = new PlayerData
                    {
                        Username = username,
                        WinMatch = winMatch,
                        Score = score,
                        MatchPlayed = Matchplay
                    };

                    // Add player data to the list
                    playerList.Add(player);
                }

                // Sort the player list using the custom comparison logic
                playerList.Sort();

                // Instantiate new scoreboard elements
                RankPlayer = 1;
                foreach (PlayerData player in playerList)
                {
                    // Instantiate new scoreboard elements
                    GameObject scoreboardElement = Instantiate(scoreElement, scoreboardContent);
                    scoreboardElement.GetComponent<Element>().NewScoreElement(player.Username, player.WinMatch, player.Score, RankPlayer, player.MatchPlayed);
                    RankPlayer++;
                }
                
                MessageText.SetActive(false);
                ScoreBoardPanel.SetActive(true);
                LeaderBoardPanel.SetActive(false);
            }

        }

    }


    public void SearchingLeaderBoard(InputField leaderBoardId)
    {
        // Check if the input field is empty
        if (string.IsNullOrEmpty(leaderBoardId.text))
        {
            // If the input field is empty, set all elements to be inactive
            for (int i = 0; i < instantiatedElements.Count; i++)
            {
                instantiatedElements[i].SetActive(false);
            }

            // Optionally, hide UI elements or perform other actions here
            searchMessage.SetActive(false);
            searchandCreateMessage.SetActive(true);

            // Log a message or perform other actions if needed
            Debug.Log("Input field is empty");
            return; // Exit the method since there's no need to proceed with the search
        }

        for (int i = 0; i < instantiatedElements.Count; i++)
            {
            instantiatedElements[i].SetActive(false);
            }
            string searchText = leaderBoardId.text.ToLower(); // Convert the search text to lowercase for case-insensitive search

            List<string> matchingItems = new List<string>();

            for (int i = 0; i < instantiatedElements.Count; i++)
            {
                if (instantiatedElements[i].GetComponent<LeaderBoardsElement>().id.ToLower().Contains(searchText))
                {
                    matchingItems.Add(instantiatedElements[i].GetComponent<LeaderBoardsElement>().id);
                }
            }

            if (matchingItems.Count > 0)
            {
                //Debug.Log("Items found: " + Join(", ", matchingItems));
                for (int i = 0; i < instantiatedElements.Count; i++)
                {
                    for (int j = 0; j < matchingItems.Count; j++)
                    {
                        if (instantiatedElements[i].GetComponent<LeaderBoardsElement>().id == matchingItems[j])
                        {
                         print("12345");
                        searchMessage.SetActive(false);
                        searchandCreateMessage.SetActive(false);
                        instantiatedElements[i].SetActive(true);
                        }

                    }

                }
            }
            else
            {
              searchandCreateMessage.SetActive(false);
              searchMessage.SetActive(true);
              Debug.Log("No matching items found");
            for (int i = 0; i < instantiatedElements.Count; i++)
            {
                instantiatedElements[i].SetActive(false);
            }

        }



        ////Get all the users data ordered by Score amount
        //Task<DataSnapshot> DBTask = DbReference.Child("LeaderBoards").GetValueAsync();
        //yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        //if (DBTask.Exception != null)
        //{
        //    Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        //}
        //else
        //{
        //    //Data has been retrieved
        //    DataSnapshot snapshot = DBTask.Result;

        //    // Loop through every user's UID
        //    foreach (DataSnapshot childSnapshot in snapshot.Children)
        //    {
        //        // Extract user data
        //        string Lname = childSnapshot.Child("name").Value.ToString();
        //        string ID = childSnapshot.Child("id").Value.ToString();
        //        if(ID == leaderBoardId.text)
        //        {
        //            print($"ID Matched {ID}");
        //        }
        //        else
        //        {
        //            print($"ID not Matched {leaderBoardId}");
        //        }

        //    }

        //}
        
        }
    private IEnumerator CheckIfPlayerExistsAndUpdate(string playerName, Action<bool, Player> callback)
    {
        // Check if the player exists in the database
 
        Task<DataSnapshot> checkTask = DbReference.Child("LeaderBoards").Child(GData.LeaderBoardID).Child("users").Child(playerName).GetValueAsync();
        yield return new WaitUntil(() => checkTask.IsCompleted);

        if (checkTask.Exception != null)
        {
            Debug.LogWarning($"Failed to check player existence with {checkTask.Exception}");
            callback?.Invoke(false, null);  // Invoke callback with false in case of an error
            yield break;
        }

        DataSnapshot snapshot = checkTask.Result;

        // Check if the player exists
        bool playerExists = snapshot.Exists;

        if (playerExists)
        {
            // Player exists, retrieve data
            Player playerData = new Player(); // Assume you have a PlayerData class

            // Deserialize data from the snapshot
            string jsonData = snapshot.GetRawJsonValue();
            JsonUtility.FromJsonOverwrite(jsonData, playerData);

            // Invoke the callback with the result of player existence and retrieved data
            callback?.Invoke(true, playerData);
        }
        else
        {
            // Player does not exist
            callback?.Invoke(false, null);
        }
    }

    public class PlayerData : IComparable<PlayerData>
    {
        public string Username { get; set; }
        public int WinMatch { get; set; }
        public int Score { get; set; }
        public int MatchPlayed { get; set; }
        public int CompareTo(PlayerData other)
        {
            // Compare first by WinMatch
            int winMatchComparison = other.WinMatch.CompareTo(WinMatch);
            if (winMatchComparison != 0)
            {
                return winMatchComparison;
            }

            // If WinMatch is the same, compare by Score
            return other.Score.CompareTo(Score);
        }
    }

    public class LeaderBoard
    {
        public int id;
        public string name;

        public LeaderBoard(int ID, string Name)
        {
            id = ID;
            name = Name;
        }
    }
    public class Player
    {
        public string name;
        public int winning;
        public int score;
        public int totalMatch;

        public Player(string Name, int Winning, int Score, int TotalMatch)
        {
            name = Name;
            winning = Winning;
            score = Score;
            totalMatch = TotalMatch;
        }
        public Player()
        {

        }
    }
}
