using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : Player
{
    public bool onGround = false;
    private float playerweight=1.5f;
    public GameObject arrow;
    public Animator animator;
    private bool facing;
    // Use this for initialization
    void Start()
    {
        facing = true;
        speed = 200f;
        jumpSpeed = 400f;
        onGround = false;
        playerweight = 1.5f;
        health = 100f;
        no_arrows = 3f;
        damage = 1f;
        fullmana = 100f;
        mana = 100f;
        manaSkill1 = 20f;
        manaSkill2 = 30f;
        animator = GetComponent<Animator>();
        healthBar.GetComponent<HealthBarController>().setFullHeal(health);
        manaBar.GetComponent<HealthBarController>().setFullHeal(mana);
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("player1") * speed;

        Vector2 movement = new Vector2(moveX * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);
        GetComponent<Rigidbody2D>().velocity = movement;
        animator.SetFloat("Speed", Mathf.Abs(moveX));
        flip(moveX);
        manaBar.GetComponent<HealthBarController>().setFullHeal(fullmana);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (onGround)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpSpeed));
            }
            onGround = false;
        }

        if (Input.GetKeyDown("[1]")&&mana>manaSkill1)
        {
            animator.SetTrigger("Skill");
            getMana(manaSkill1);
                Vector2 tmp = transform.position;
                GameObject ar;
                ar = Instantiate(arrow, transform.position, transform.rotation);
                if (!facing)
                {
                    tmp.x -= playerweight;
                    ar = Instantiate(arrow, tmp, transform.rotation);
                    ar.GetComponent<ArrowInit>().moveArrow(-1);
                }
                else
                {
                    tmp.x += playerweight;
                    ar = Instantiate(arrow, tmp, transform.rotation);
                    ar.GetComponent<ArrowInit>().moveArrow(1);
                }
                ar.GetComponent<ArrowInit>().setDamage(damage);
                arrow.GetComponent<SpriteRenderer>().flipX = facing;
            
        }

            if (Input.GetKeyDown("[2]") &&mana>manaSkill2)
        {

            animator.SetTrigger("Skill");
            getMana(manaSkill2);
            Vector2 tmp = transform.position;
                GameObject ar;
                if (!facing)
                {
                    tmp.x -= playerweight;
                    ar = Instantiate(arrow, tmp, Quaternion.Euler(new Vector3(0, 0, -40f)));
                    ar.GetComponent<ArrowInit>().upShoot(-1);
                }
                else
                {
                    tmp.x += playerweight;
                    ar = Instantiate(arrow, tmp, Quaternion.Euler(new Vector3(0, 0, 40f)));
                    ar.GetComponent<ArrowInit>().upShoot(1);
                }
                ar.GetComponent<ArrowInit>().setDamage(damage);
                arrow.GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        }

        if (health <= 0)
        {
            animator.SetTrigger("Die");
            Destroy(gameObject,1.2f);
            GetComponent<SceneController>().SetNextScene(3);
        }
        if (mana < fullmana)
        {
            mana += (fullmana * 0.001f) ;
            getMana((-fullmana * 0.001f));
        }

    }
    private void flip(float dir)
    {
        if ((dir < 0 && facing) || (dir > 0 && !facing))
        {

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            facing = !facing;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {
            onGround = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            getHurt(collision.gameObject.GetComponent<Enemy>().getDamge());
        }
    }
}