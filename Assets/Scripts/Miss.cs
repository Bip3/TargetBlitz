using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miss : MonoBehaviour
{
    SpriteRenderer me;

    // Use this for initialization
    void Start()
    {
        me = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        me.color = new Color(me.color.r, me.color.g, me.color.b, me.color.a - Time.deltaTime);

        if (me.color.a <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}