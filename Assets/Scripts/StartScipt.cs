using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScipt : MonoBehaviour {

	// Use this for initialization
	void Start () {
        

    }

    void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Update is called once per frame
    void Update () {
		
	}
    public void start()
    {
        SceneManager.LoadScene("main");
    }
    public void back()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void help()
    {
        SceneManager.LoadScene("HelpScene");

    }
    public void credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
