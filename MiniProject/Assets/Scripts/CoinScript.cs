using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {
    private int cnt ;
	// Use this for initialization
	void Start () {
        cnt = 0;
	}
	
	// Update is called once per frame
	void Update () {
        cnt++;
        if (cnt >= 300)
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
