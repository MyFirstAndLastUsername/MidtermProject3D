using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowInit : Weapon {
    private int cnt = 0;
    private bool rot = false;
    private int di = 1;
    void Start () {
        lifetime = 120;
    }

    public void moveArrow(int dir)
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(700f*dir, 0));
    }

    public void upShoot(int dir)
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(200f * dir, 500f));
        rot = true;
        di = dir;
    }
	
	void Update () {
        cnt++;
        if (cnt == lifetime)
        {
            Destroy(gameObject);
        }
        if (rot)
        {
            Vector3 tmp = transform.eulerAngles;
            tmp.z -= di * 0.7f;
            transform.rotation = Quaternion.Euler(tmp);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        //if (collision.gameObject.CompareTag("Wall"))
        //{
        //    Destroy(gameObject);
        //}
    }
    public void setDamage(float dm)
    {
        damage = dm;
    }
}
