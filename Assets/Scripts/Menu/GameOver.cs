using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    int gameoverScore = Stats.score;
        
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Your Score: " + gameoverScore.ToString();
    }

    public void BackToMainmenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
