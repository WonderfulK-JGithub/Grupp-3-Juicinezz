using UnityEngine;
using System.Collections.Generic;
using TMPro;


//av K-J
public class ScoreManager : MonoBehaviour
{
    
    List<ScoreInfo> currentLeaderBoard = null; //data p� hur leader

    [Header("LeaderBoard")]
    [SerializeField] GameObject leaderboardParent = null;
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
    [SerializeField] GameObject enemyScorePrefab = null; //prefab som instatiatas n�r man skapar scoretext efter att fiende d�tt
    [SerializeField] float enemyScoreTime = 0f; //Hur l�nge texten "enemyScorePrefab" ska finnas innan den f�rst�rs

    public void TestButton(int sus)
    {
        AddScorePoints(sus, new Vector3(1, 0, 0));
    }

    public void TestShowLeaderBoard()
    {

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
            nameList[i].text = currentLeaderBoard[i].name + " : " + currentLeaderBoard[i].score;
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
                info.name = playerName;
                info.score = score;
                currentLeaderBoard.Add(info); //l�gger till nya spelaren i leaderboarden
            }
        }
        else
        {
            ScoreInfo info = new ScoreInfo();
            info.name = playerName;
            info.score = score;
            currentLeaderBoard.Add(info); //l�gger till nya spelaren i leaderboarden
        }
    }
    

}
