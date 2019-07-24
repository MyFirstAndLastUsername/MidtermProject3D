using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VKTinit : Weapon {
    private int cnt;
	// Use this for initialization
	void Start () {
        cnt = 0;
        lifetime = 30;
	}
    public void move(int dir)
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(350f * dir, 0));
    }

    // Update is called once per frame
    void Update () {
        cnt++;
        if (cnt == lifetime)
        {
            Destroy(gameObject);
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
