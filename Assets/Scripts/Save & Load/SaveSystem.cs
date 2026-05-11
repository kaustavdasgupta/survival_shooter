using UnityEngine;
using System.IO;

public class SaveSystem
{
    private static string savePath = Application.persistentDataPath + "/save.json";

    public static void SavePlayer(Transform player, PlayerHealth playerHealth)
    {
        if (playerHealth.CurrentHealth <= 0)
            return;

        SaveData data = new SaveData();
        data.position = player.position;
        data.health = playerHealth.CurrentHealth;
        data.score = ScoreManager.score;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Game Saved");
    }
    public static void LoadPlayer(Transform player, PlayerHealth playerHealth)
    {
        if (playerHealth.CurrentHealth <= 0)
            return;
        
        ResetEnemies();

        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            player.position = data.position;
            playerHealth.SetHealth(data.health);

            ScoreManager.score = data.score;
            Debug.Log("Game Loaded");
        }
    }

    private static void ResetEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
            Object.Destroy(enemy);
    }
}



