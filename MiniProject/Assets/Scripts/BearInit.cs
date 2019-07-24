using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearInit : Enemy
{
    // Use this for initialization
    void Start()
    {
        //health = 5f;
        //speed = 0.5f;
        //damage = 10f;
        healthBar = GetComponentInChildren<HealthBarController>();
        healthBar.setFullHeal(health);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GetComponent<Animator>().SetTrigger("Die");
            Destroy(gameObject,1.2f);
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
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
