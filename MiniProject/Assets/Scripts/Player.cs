using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    protected float health;
    protected float no_arrows;
    protected float damage;
    protected float arrowDamage;
    public float speed;
    public float jumpSpeed;
    protected float fullmana;
    protected float mana;
    public GameObject healthBar;
    public GameObject manaBar;
    protected float manaSkill1;
    protected float manaSkill2;

    void Start () {
        damage = 0;
        health = 0;
        speed = 0;
        mana = 0;
	}
	
    public void LevelUP()
    {
        damage += 3f;
        if (speed < 1000)
        {
            speed += 100;
        }
        fullmana += 50f;
    }


    public float getDamge()
    {
        return damage;
    }
}
