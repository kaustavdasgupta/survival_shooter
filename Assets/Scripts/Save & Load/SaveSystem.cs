using UnityEngine;
using System.IO;

public class SaveSystem
{
    private static string savePath = Application.persistentDataPath + "/save.json";

    public static void SavePlayer(Transform player, PlayerHealth playerHealth)
    {
        SaveData data = new SaveData();
        data.position = player.position;
        data.health = playerHealth.CurrentHealth;
        data.score = ScoreManager.score;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Game Saved");
    }
}



