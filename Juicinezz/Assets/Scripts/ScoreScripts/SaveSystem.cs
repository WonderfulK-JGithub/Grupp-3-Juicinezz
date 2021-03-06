using System.Collections.Generic;
using UnityEngine;
using System.IO;

//av K-J
public static class SaveSystem //eftersom allt detta ?r static slipper jag l?gga detta script p? ett object
{
    /// <summary> Vart sparfilen ska sparas</summary>
    static string fileLocation = Application.persistentDataPath + "ButMyHopeWillNeverDaaaaie.sus";

    /// <summary> Sparar data i en sparfil</summary>
    public static void Save(SaveData data)
    {
        string jsonString = JsonUtility.ToJson(data); //g?r om spardatan till en JSON string
        Debug.Log(jsonString);
        File.WriteAllText(fileLocation, jsonString); //sparar stringen p? en sparfil
    }

    /// <summary> Laddar sparfilen och skickar tillbaka datan</summary>
    public static SaveData Load()
    {
        if(File.Exists(fileLocation)) //kollar om filen finns
        {
            string jsonString = File.ReadAllText(fileLocation); //Sparar filens text i en string (stringens information ?r i JSON)
            SaveData data = JsonUtility.FromJson<SaveData>(jsonString); //g?r om json stringen till information med datatypen SaveData

            return data;
        }
        else
        {
            Debug.Log("Ingen sparfil :(");
            SaveData data = new SaveData();//skapar en ny default data(tom)

            return data;
        }
    }

    public static void Delete()
    {
        File.Delete(fileLocation);
    }
}


public class SaveData
{
    public List<ScoreInfo> leaderBoard = null; //Yeah, ett leaderboard
    public SaveData()
    {
        leaderBoard = new List<ScoreInfo>();
    }
}

[System.Serializable]
public class ScoreInfo
{
    public string playerName; //namnet p? spelaren som st?r p? leaderboarden
    public int score; //antal po?ng den spelaren fick
}