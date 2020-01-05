using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour {
    public GameObject circle;
    public GameObject square;
    public GameObject hex;
    public GameObject miss;
    public GameObject oneUp;
    Vector3 spawnPoint;
    Quaternion randomRotation;
    Vector3 missPos;
    Quaternion missRotation;

    private float globalTimer = 0;

    [SerializeField]
    private float spawnRate = 1;
    private float obstructionTimer = 0;
    private float spawnTimer = 0;

    float floatSeconds = 0;
    public static int seconds = 0;
    public static int minutes = 0;
    public static int hours = 0;
    public static int ScoreInt = 0;
    public static int lives = 3;
    public static int highScore;

    public bool oneUpEnabled = false;
    public float oneUpTimer = 0;
    public int oneUpNumberR = 0;

    public Text score;
    public Text timer;
    public Text livesText;
	// Use this for initialization
	void Start () {
        ScoreInt = 0;
        lives = 5;
        livesText.text = "Lives: " + lives;
        if (PlayerPrefs.GetInt("HighScore") > 0)
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }

        seconds = 0;
        minutes = 0;
        hours = 0;
    }

    // Update is called once per frame
    void Update() {
        if (lives <= 0)
        {
            SceneManager.LoadScene("Gameover");
        }
        livesText.text = "Lives: " + lives;
        missPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        globalTimer += Time.deltaTime;
        spawnTimer += Time.deltaTime;
        obstructionTimer += Time.deltaTime;
        oneUpTimer += Time.deltaTime;
        if (obstructionTimer >= 2)
        {
            spawnSquare();
            obstructionTimer = 0;
        }
        if (globalTimer >= 1)
        {
            if (spawnRate >= .45)
            {
                spawnRate -= .01f;
            }
            globalTimer = 0;
        }

        if (spawnTimer >= spawnRate)
        {
            spawnCircle();
            spawnTimer = 0;
        }

        floatSeconds += Time.deltaTime;
        if (floatSeconds >= 1)
        {
            seconds += 1;
            floatSeconds = 0;
        }
        if (seconds >= 60)
        {
            minutes += 1;
            seconds = 0;
        }
        if (minutes >= 60)
        {
            hours += 1;
            minutes = 0;
        }

        timer.text = "Timer: " + hours + ":" + minutes + ":" + seconds;
        score.text = "Score: " + ScoreInt;

        if (Input.GetButtonDown("Fire1"))
        {
            missRotation = new Quaternion(transform.rotation.x, transform.rotation.y, Random.rotation.z, transform.rotation.w);
            Instantiate(miss, Camera.main.ScreenToWorldPoint(missPos), missRotation);
        }

        if (oneUpTimer >= 40 && oneUpEnabled == false)
        {
            oneUpEnabled = true;
            oneUpTimer = 0;
        }

        if (oneUpEnabled == true)
        {
            if (oneUpTimer >= 5)
            {
                oneUpNumberR = Random.Range(1, 5);
                if (oneUpNumberR == 4)
                {
                    spawnPoint = new Vector3(Random.Range(-2.3f, 2.3f), Random.Range(-4.5f, 4f), transform.position.z);
                    Instantiate(oneUp, spawnPoint, transform.rotation);
                }
                oneUpTimer = 0;
                

                
            }
        }

    }

    void spawnCircle ()
    {
        spawnPoint = new Vector3(Random.Range(-2.3f, 2.3f), Random.Range(-4.5f, 4f), transform.position.z);
        Instantiate(circle, spawnPoint, transform.rotation);
    }

    void spawnSquare()
    {
        int randomObj;
        spawnPoint = new Vector3(Random.Range(-2.3f, 2.3f), Random.Range(-4.5f, 4f), transform.position.z);
        randomRotation = new Quaternion(transform.rotation.x, transform.rotation.y, Random.rotation.z, 1);

        randomObj = Random.Range(1, 3);
        
        if (randomObj == 1)
        {
            Instantiate(square, spawnPoint, randomRotation);
        }
        else if (randomObj == 2)
        {
            Instantiate(hex, spawnPoint, randomRotation);

        }
    }
}
