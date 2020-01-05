using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameoverScript : MonoBehaviour {
    public Text thisScore;
    public Text thisTimer;
    
    public Text highScore;

    public static int gameOvers = 0;

	// Use this for initialization
	void Start () {
        Advertisement.Initialize("1703491", true);
        gameOvers += 1;
        if (gameOvers >= 1)
        {
            StartCoroutine(ShowAdWhenReady());
            gameOvers = 0;
        }
        if (Spawner.ScoreInt >= Spawner.highScore)
        {
            Spawner.highScore = Spawner.ScoreInt; 
        }
        thisScore.text = "Score: " + Spawner.ScoreInt;
        thisTimer.text = "Time: " + Spawner.hours + ":" + Spawner.minutes + ":" + Spawner.seconds;
        highScore.text = "High Score: " + Spawner.highScore;

        PlayerPrefs.SetInt("HighScore", Spawner.highScore);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void restart()
    {
        SceneManager.LoadScene("StartScene");
    }

    IEnumerator ShowAdWhenReady()
    {
        while (!Advertisement.IsReady())
            yield return null;

        Advertisement.Show();
    }
}
