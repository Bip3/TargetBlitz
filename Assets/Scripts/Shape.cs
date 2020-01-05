using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {
    bool shrinking = false;
    private ParticleSystem explosion;
    bool Enabled = true;
    float deathTimer = 1.2f;
    private AudioSource blip;
    private Collider2D circleCollider;
    private SpriteRenderer thisSprite;

	// Use this for initialization
	void Start () {
        blip = gameObject.GetComponent<AudioSource>();
        explosion = GetComponent<ParticleSystem>();
        circleCollider = gameObject.GetComponent<Collider2D>();
        thisSprite = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Enabled)
        {

            if (shrinking == false)
            {
                transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime, transform.localScale.y + Time.deltaTime, transform.localScale.z + Time.deltaTime);
            }
            if (shrinking == true)
            {
                transform.localScale = new Vector3(transform.localScale.x - Time.deltaTime / 4, transform.localScale.y - Time.deltaTime / 4, transform.localScale.z - Time.deltaTime / 4);
            }
            if (shrinking == false && transform.localScale.x >= 1)
            {
                shrinking = true;
            }

            if (transform.localScale.x <= 0)
            {
                Spawner.lives -= 1;
                Destroy(this.gameObject);
            }
        }

        if (Enabled == false)
        {
            circleCollider.enabled = false;
            thisSprite.enabled = false;
            deathTimer -= Time.deltaTime;
            if (deathTimer <= 0)
            {
                Destroy(this.gameObject);
            }
        }
	}
    void OnMouseOver()  
    {
        if (Input.GetMouseButtonDown(0) && Enabled)
        {
            Spawner.ScoreInt += 1;
            explosion.Play();
            blip.Play();
            Enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Square") || collision.gameObject.CompareTag("Square"))
        {
            Destroy(collision.gameObject);
        }
    }
}
