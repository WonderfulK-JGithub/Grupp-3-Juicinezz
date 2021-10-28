using UnityEngine;
using System.Collections.Generic;
using TMPro;


//av K-J
public class ScoreManager : MonoBehaviour
{
    
    List<ScoreInfo> currentLeaderBoard = null; //data på hur leader

    [Header("WriteName")]
    [SerializeField] GameObject writeNameParent = null;//parenten för all UI kopplat till att skriva sitt namn
    [SerializeField] TMP_InputField inputField = null; //inputfieldet som man skriver sitt spelarnamn i
    [SerializeField] int characterLimit = 0;//hur långt ett namn får vara

    [Header("LeaderBoard")]
    [SerializeField] GameObject leaderboardParent = null;//parenten för all UI kopplat till leaderboarden
    [SerializeField] TextMeshProUGUI[] nameList = null; //lista på alla namn som är på leaderboarden
    public string playerName = null; //namnet som spelaren har skrivit in sig som
    public int score = 0; //score

    public static ScoreManager current = null;
    public bool gameIsOngoing = false;

    Animator anim = null;

    private void Awake()
    {
        current = this;
        anim = GetComponent<Animator>();
        currentLeaderBoard = SaveSystem.Load().leaderBoard;

        
    }
    void Update()
    {
        inputField.Select();
    }

    [Header("Text")]
    [SerializeField] TextMeshProUGUI scoreText = null; //texten som visar poängen
    [SerializeField] TextMeshProUGUI nameText = null; //texten som visar spelarens namn
    [SerializeField] GameObject enemyScorePrefab = null; //prefab som instatiatas när man skapar scoretext efter att fiende dött
    [SerializeField] float enemyScoreTime = 0f; //Hur länge texten "enemyScorePrefab" ska finnas innan den förstörs

    public void TestButton(int sus)
    {
        AddScorePoints(sus, new Vector3(1, 0, 0));
    }

    public void TestShowLeaderBoard()
    {
        leaderboardParent.SetActive(true);
        NewContender();
    }

    public void TestDeleteTheThing()
    {
        SaveSystem.Delete();
        currentLeaderBoard = SaveSystem.Load().leaderBoard;
    }

    /// <summary> Lägger till poäng och ändrar poäng texten </summary>
    public void AddScorePoints(int points,Vector3 textPosition)
    {
        score += points;//lägger till poäng
        scoreText.text = score.ToString(); //Ändrar texten som visar all poäng man har

        GameObject newText = Instantiate(enemyScorePrefab, textPosition, Quaternion.identity); //skapar text som visar hur mycket poäng man fick när man skjutit en fiende.
        newText.GetComponent<SpawnedText>().ChangeText(points.ToString()); //ändrar texten till rätt mängd poäng

        Destroy(newText, enemyScoreTime); //tar bort texten efter en viss tid
    }

    /// <summary> Uppdaterar leaderboar texten </summary>
    public void UpdateLeaderboard()
    {
        for (int i = 0; i < currentLeaderBoard.Count; i++)
        {
            nameList[i].text = currentLeaderBoard[i].playerName + " : " + currentLeaderBoard[i].score;
            if (nameList[i].text == playerName) nameList[i].color = Color.green;//ens egna namn i leaderboarden är grön
        }
    }

    /// <summary> Kollar om den nuvarande spelaren kan komma upp på leaderboarden </summary>
    public void NewContender()
    {
        if(currentLeaderBoard.Count == 5) //kollar om leaderBoarden har 5 spelare (annars läggs man till perautomatik)
        {
            if (currentLeaderBoard[4].score < score) //kollar om spelaren har mer poäng en personen på 5:e plats
            {
                currentLeaderBoard.RemoveAt(4); //tar bort 5:e plats
                ScoreInfo info = new ScoreInfo();
                info.playerName = playerName;
                info.score = score;
                currentLeaderBoard.Add(info); //lägger till nya spelaren i leaderboarden
            }
            else return;
        }
        else
        {
            ScoreInfo info = new ScoreInfo();
            info.playerName = playerName;
            info.score = score;
            currentLeaderBoard.Add(info); //lägger till nya spelaren i leaderboarden
        }

        currentLeaderBoard.Sort(SortLeaderBoard); //sorterar leaderboarden så att alla hamnar i rätt ordning

        UpdateLeaderboard();
    }
    private int SortLeaderBoard(ScoreInfo a, ScoreInfo b)
    {
        if (a.score > b.score)
        {
            return -1;//a läggs före b
        }
        else if(a.score < b.score)
        {
            return 1;//b läggs före a
        }
        else
        {
            return 0;//dem är kvar
        }
    }//Funktion för att sortera lista

    public void OnChangedName()//när man skriver en karaktär i input fieldet sker detta
    {
        SoundManagerScript.PlaySound("Click");
        if (inputField.text.Length <= characterLimit)
        {
            playerName = inputField.text;
        }
        else
        {
            inputField.text = playerName;
        }
    }

    public void NameReady() //när man är klar med sitt namn
    {
        if (inputField.text.Length == 0) return;
        SoundManagerScript.PlaySound("Start");
        nameText.text = playerName;
        writeNameParent.SetActive(false);
        gameIsOngoing = true;
    }

    public void SaveLeaderboard()//sparar den nuvarande leaderboarden
    {
        Debug.Log("Leaderboard saved!");
        SaveData newSave = new SaveData();
        newSave.leaderBoard = currentLeaderBoard;
        SaveSystem.Save(newSave);
    }

    public void GameOver()//sker när spelet är över
    {
        anim.Play("Game_Over");
        NewContender();
        SaveLeaderboard();
        gameIsOngoing = false;
    }

    public void Restart()
    {
        SceneTransition.current.EnterScene(1);
    }
    public void MainMenu()
    {
        SceneTransition.current.EnterScene(0);
    }

    public void AnimSFX()
    {
        //animationen kallar detta
        SoundManagerScript.PlaySound("Click");
    }
}
