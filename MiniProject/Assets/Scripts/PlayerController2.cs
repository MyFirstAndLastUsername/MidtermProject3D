using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : Player {

    private Animator animator;
    private bool facing;
    private bool onGround;
    private float playerweight;
    private float dashSpeed;
    public GameObject VTK;
  
    // Use this for initialization
    void Start () {
        onGround = false;
        facing = false;
        speed = 100f;
        jumpSpeed = 40f;
        arrowDamage = 5f;
        animator = GetComponent<Animator>();
        playerweight = 3f;
        dashSpeed = 400f;
        health = 200f;
        mana = 100f;
        fullmana = 100f;
        manaSkill1 = 20f;
        manaSkill2 = 50f;
        healthBar.GetComponent<HealthBarController>().setFullHeal(health);
        manaBar.GetComponent<HealthBarController>().setFullHeal(mana);
    }
	
	// Update is called once per frame
	void Update () {
        float moveX = Input.GetAxisRaw("player2")*speed;

        Vector2 movement = new Vector2(moveX*Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);
        GetComponent<Rigidbody2D>().velocity = movement;
        animator.SetFloat("Speed", Mathf.Abs(moveX));
        flip(moveX);
        manaBar.GetComponent<HealthBarController>().setFullHeal(fullmana);
        if (Input.GetKeyDown(KeyCode.W)){
            if (onGround)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpSpeed));
            }
            onGround = false;
        }
        if (Input.GetKeyDown(KeyCode.G)&&mana>manaSkill1)
        {
            animator.SetTrigger("Skill1");
            int tmp = -1;
            if (facing) tmp = 1;
            damage = 2f;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(tmp*dashSpeed, 0));
            getMana(manaSkill1);

        }
        if (Input.GetKeyDown(KeyCode.H)&&mana>manaSkill2)
        {
            animator.SetTrigger("Skill2");
            getMana(manaSkill2);
            Vector2 tmp = transform.position;
            GameObject ar;
            ar = Instantiate(VTK, transform.position, transform.rotation);
            if (!facing)
            {
                tmp.x -= playerweight;
                ar = Instantiate(VTK, tmp, transform.rotation);
                ar.GetComponent<VKTinit>().move(-1);
            }
            else
            {
                tmp.x += playerweight;
                ar = Instantiate(VTK, tmp, transform.rotation);
                ar.GetComponent<VKTinit>().move(1);
            }
            ar.GetComponent<VKTinit>().setDamage(arrowDamage);
            VTK.GetComponent<SpriteRenderer>().flipX = facing;

        }
        if(health <= 0)
        {
            animator.SetTrigger("Die");
            Destroy(gameObject, 1.2f);
            GetComponent<SceneController>().SetNextScene(3);
        }
        if (mana < fullmana)
        {
            mana += fullmana / 1000;
            getMana(-fullmana / 1000);
        }
    }

    public void getMana(float mn)
    {
        mana -= mn;
        manaBar.GetComponent<HealthBarController>().setValue(mana);
    }

    public void getHurt(float dm)
    {
        if (dm < 0) return;
        health -= dm;
        healthBar.GetComponent<HealthBarController>().getHurt(dm);
    }

    private void flip(float dir)
    {
        if ((dir < 0&&facing) ||(dir>0&&!facing))
        {

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            facing = !facing;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")|| collision.gameObject.CompareTag("Player"))
        {
            onGround = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            getHurt(collision.gameObject.GetComponent<Enemy>().getDamge());
        }
    }
}
