using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    protected float health;
    protected float damage;
    protected float speed;
    protected HealthBarController healthBar;

    public void LevelUP(int level)
    {
        health += level*5f;
        damage += level*5f;
        if (speed+level*1f < 8f)
        {
            speed += level*1f;
        }
    }


    protected void collide(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            float dm = collision.gameObject.GetComponent<Weapon>().getDamage();
            health -= dm;
            healthBar.getHurt(dm);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            float dm = collision.gameObject.GetComponent<Player>().getDamge();
            health -= dm;
            healthBar.getHurt(dm);
        }
    }
    public float getDamge()
    {
        return damage;
    }

}
