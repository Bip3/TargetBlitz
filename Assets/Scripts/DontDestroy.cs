using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DontDestroy : MonoBehaviour {
	Scene currentScene;
	private AudioSource music;
	void start()
	{
		music = gameObject.GetComponent<AudioSource> ();

		Scene currentScene = SceneManager.GetActiveScene ();

		if (currentScene.name == "Credits" || currentScene.name == ("HelpScene") || currentScene.name == ("StartScene")) {
			music.volume = .1f;
		} else if (currentScene.name == ("GameOver")) {
			music.volume = 0;
		} else if (currentScene.name == ("main")) {
			music.volume = .5f;
		}
	}
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        if(objs.Length >1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        

    }
}
