using UnityEngine;
using System.Collections.Generic;
using TMPro;


//av K-J
public class ScoreManager : MonoBehaviour
{
    
    List<ScoreInfo> currentLeaderBoard = null; //data p� hur leader

    [Header("WriteName")]
    [SerializeField] GameObject writeNameParent = null;//parenten f�r all UI kopplat till att skriva sitt namn
    [SerializeField] TMP_InputField inputField; //inputfieldet som man skriver sitt spelarnamn i

    [Header("LeaderBoard")]
    [SerializeField] GameObject leaderboardParent = null;//parenten f�r all UI kopplat till leaderboarden
    [SerializeField] TextMeshProUGUI[] nameList = null; //lista p� alla namn som �r p� leaderboarden
    public string playerName = null; //namnet som spelaren har skrivit in sig som
    public int score = 0; //score

    public static ScoreManager current = null;
    private void Awake()
    {
        current = this;
        currentLeaderBoard = SaveSystem.Load().leaderBoard;
    }


    

    [Header("Text")]
    [SerializeField] TextMeshProUGUI scoreText = null; //texten som visar po�ngen
    [SerializeField] TextMeshProUGUI nameText = null; //texten som visar spelarens namn
    [SerializeField] GameObject enemyScorePrefab = null; //prefab som instatiatas n�r man skapar scoretext efter att fiende d�tt
    [SerializeField] float enemyScoreTime = 0f; //Hur l�nge texten "enemyScorePrefab" ska finnas innan den f�rst�rs

    public void TestButton(int sus)
    {
        AddScorePoints(sus, new Vector3(1, 0, 0));
    }

    public void TestShowLeaderBoard()
    {
        leaderboardParent.SetActive(true);
        NewContender();
    }

    /// <summary> L�gger till po�ng och �ndrar po�ng texten </summary>
    public void AddScorePoints(int points,Vector3 textPosition)
    {
        score += points;//l�gger till po�ng
        scoreText.text = score.ToString(); //�ndrar texten som visar all po�ng man har

        GameObject newText = Instantiate(enemyScorePrefab, textPosition, Quaternion.identity); //skapar text som visar hur mycket po�ng man fick n�r man skjutit en fiende.
        newText.GetComponent<SpawnedText>().ChangeText(points.ToString()); //�ndrar texten till r�tt m�ngd po�ng

        Destroy(newText, enemyScoreTime); //tar bort texten efter en viss tid
    }

    /// <summary> Uppdaterar leaderboarden </summary>
    public void UpdateLeaderboard()
    {
        for (int i = 0; i < currentLeaderBoard.Count; i++)
        {
            nameList[i].text = currentLeaderBoard[i].playerName + " : " + currentLeaderBoard[i].score;
        }
    }

    /// <summary> Kollar om den nuvarande spelaren kan komma upp p� leaderboarden </summary>
    public void NewContender()
    {
        if(currentLeaderBoard.Count == 5) //kollar om leaderBoarden har 5 spelare (annars l�ggs man till perautomatik)
        {
            if (currentLeaderBoard[4].score < score) //kollar om spelaren har mer po�ng en personen p� 5:e plats
            {
                currentLeaderBoard.RemoveAt(4); //tar bort 5:e plats
                ScoreInfo info = new ScoreInfo();
                info.playerName = playerName;
                info.score = score;
                currentLeaderBoard.Add(info); //l�gger till nya spelaren i leaderboarden
            }
            else return;
        }
        else
        {
            ScoreInfo info = new ScoreInfo();
            info.playerName = playerName;
            info.score = score;
            currentLeaderBoard.Add(info); //l�gger till nya spelaren i leaderboarden
        }

        currentLeaderBoard.Sort(SortLeaderBoard); //sorterar leaderboarden s� att alla hamnar i r�tt ordning

        UpdateLeaderboard();
    }
    private int SortLeaderBoard(ScoreInfo a, ScoreInfo b)
    {
        if (a.score > b.score)
        {
            return -1;//a l�ggs f�re b
        }
        else if(a.score < b.score)
        {
            return 1;//b l�ggs f�re a
        }
        else
        {
            return 0;//dem �r kvar
        }
    }//Funktion f�r att sortera lista

    public void OnChangedName()//n�r man skriver en karakt�r i input fieldet sker detta
    {
        playerName = inputField.text;
    }

    public void NameReady() //n�r man �r klar med sitt namn
    {
        nameText.text = playerName;
        writeNameParent.SetActive(false);
    }

    public void SaveLeaderboard()//sparar den nuvarande leaderboarden
    {
        Debug.Log("Leaderboard saved!");
        SaveData newSave = new SaveData();
        newSave.leaderBoard = currentLeaderBoard;
        SaveSystem.Save(newSave);
    }
}
