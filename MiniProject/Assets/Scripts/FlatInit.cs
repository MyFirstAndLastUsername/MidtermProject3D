using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatInit : MonoBehaviour {
    public float speed = -0.004f;
	// Use this for initialization
	void Start () {
        speed = -0.01f;
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 tmp = transform.position;
        tmp.x += speed;
        transform.position = tmp;
        if(transform.position.x <= -10.0f)
        {
            Destroy(gameObject);
        }
	}
}
