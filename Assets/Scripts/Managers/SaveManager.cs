using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public Transform player;
    public PlayerHealth playerHealth;
    public ScoreManager scoreManager;

    private void Update()
    {
        if (Time.timeScale == 0f)
            return;

        if (Input.GetKeyDown(KeyCode.F5))
            SaveSystem.SavePlayer(player, playerHealth);
        else if (Input.GetKeyDown(KeyCode.F9))
            SaveSystem.LoadPlayer(player, playerHealth);
    }

    public void AutoSave()
    {
        if (Time.timeScale == 0f || playerHealth.CurrentHealth <= 0)
            return;

        SaveSystem.SavePlayer(player, playerHealth);
        Debug.Log("Auto Saved");
    }
}




