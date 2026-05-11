using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public Transform player;
    public PlayerHealth playerHealth;
    public ScoreManager scoreManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
            SaveSystem.SavePlayer(player, playerHealth);
    }
}




