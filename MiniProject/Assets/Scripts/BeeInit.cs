using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeInit : Enemy {
    // Use this for initialization
    private float rangeFly;
    private float fly;
    private float flySpeed;
    private int up;
    void Start()
    {
        //health = 2f;
        //speed = 0.5f;
        //damage = 5f;
        healthBar = GetComponentInChildren<HealthBarController>();
        healthBar.setFullHeal(health);
        rangeFly = 3f;
        fly = 0f;
        up = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 tmp = transform.position;
        float move = up * speed/20;
        fly += move;
        if(fly>rangeFly)
        {
            up = -1;
        }
        if (fly < 0)
        {
            up = 1;
        }
        tmp.y -= move;
        transform.position = tmp;
        if (health <= 0)
        {
            GetComponent<Animator>().SetTrigger("Die");
            Destroy(gameObject, 1.2f);
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(-speed/2, 0);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "LeftWall")
        {
            Destroy(gameObject);
        }
        collide(collision);
    }

}
