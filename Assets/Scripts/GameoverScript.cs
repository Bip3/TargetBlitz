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
	void Awake() {
		
	}
	void Start () {
		Advertisement.Initialize("1703491", true);
		if (PlayerPrefs.GetInt("GameOvers") >= gameOvers)
        {
            gameOvers = PlayerPrefs.GetInt("GameOvers");
        }
        gameOvers += 1;

        PlayerPrefs.SetInt("Gameovers", gameOvers);
        if (gameOvers >= 3)
        {
			Debug.Log ("Gameover");
            StartCoroutine(ShowAdWhenReady());
            PlayerPrefs.SetInt("Gameovers", gameOvers);
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

	IEnumerator ShowAdWhenReady()
	{
		while (!Advertisement.IsReady())
			yield return null;

		Advertisement.Show();
		gameOvers = 0;
	}

    public void restart()
    {
        SceneManager.LoadScene("StartScene");
    }

    
}
