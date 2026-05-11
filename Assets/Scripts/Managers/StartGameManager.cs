using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class StartGameManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public Transform player;
    public PlayerHealth playerHealth;
    public Button continueButton;
    public GameObject HUDCanvas;

    private string savePath;

    void Start()
    {
        savePath = Application.persistentDataPath + "/save.json";
        Time.timeScale = 0f;
        HUDCanvas.SetActive(false);
        menuCanvas.SetActive(true);
        continueButton.interactable = File.Exists(savePath);
    }

    public void NewGame()
    {
        Time.timeScale = 1f;
        HUDCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }

    public void ContinueGame()
    {
        if (File.Exists(savePath))
        {
            SaveSystem.LoadPlayer(player, playerHealth);
            Time.timeScale = 1f;
            HUDCanvas.SetActive(true);
            menuCanvas.SetActive(false);
        }
        else
        {
            Debug.Log("No Save Found");
        }
    }
}


