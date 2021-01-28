using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public Text highScoreText;
    public GameObject restartButton;


    public void OnClickRestart()
    {

        int highScore = PlayerPrefs.GetInt("High Score", 0);
        int currentScore = player.GetScore();

        if(currentScore > highScore)
        {
            PlayerPrefs.SetInt("High Score", player.GetScore());
            PlayerPrefs.Save();
        }

        Time.timeScale = 1;
        player.Restart();
    }

    public void ShowRestartButton(bool _active)
    {
        restartButton.SetActive(_active);
    }
    // Start is called before the first frame update
    void Start()
    {
        ShowRestartButton(false);

        int highScore = PlayerPrefs.GetInt("High Score", 0);
        highScoreText.text = string.Format("Hi : {0}", highScore.ToString("D8"));
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = player.GetScore().ToString("D8");
    }
}
