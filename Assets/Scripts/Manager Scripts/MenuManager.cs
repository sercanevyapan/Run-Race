using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public InputField playerName;

    public Text currentLevelText, nextLevelText;
    void Start()
    {
        currentLevelText.text = PlayerPrefs.GetInt("Level", 1).ToString();
        nextLevelText.text = PlayerPrefs.GetInt("Level",1) + 1 + "";
    }

  
    public void StartGame()
    {
        if (playerName.text == "")
            PlayerPrefs.SetString("PlayerName", "Player");
        else
            PlayerPrefs.SetString("PlayerName", playerName.text);

        SceneManager.LoadScene(PlayerPrefs.GetInt("Level", 1));
    }
}
