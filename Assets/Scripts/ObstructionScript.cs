using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstructionScript : MonoBehaviour {
    private AudioSource bip;
    bool shrinking = false;
    bool Enabled = true;
    private SpriteRenderer me;
    private Collider2D myCollider;

    float deathTimer = .5f;


    private void Start()
    {
        me = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<Collider2D>();
        bip = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Enabled == false)
        {
            deathTimer -= Time.deltaTime;
            me.enabled = false;
            myCollider.enabled = false;

            if (deathTimer <= 0)
            {
                Destroy(this.gameObject);
            }
        }

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
            Destroy(this.gameObject);
        }
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bip.Play();
            Spawner.lives -= 1;
            Enabled = false;
        }
    }

}
