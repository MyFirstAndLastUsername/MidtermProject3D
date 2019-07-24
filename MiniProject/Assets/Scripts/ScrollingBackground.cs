using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    Material material;
    Vector2 offset;

    public float speed = 0.5f;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        offset = new Vector2(speed, 0);
        material.mainTextureOffset += offset * Time.deltaTime;
	}
}
