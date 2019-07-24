using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryEnemy : MonoBehaviour {
    public GameObject bear;
    public GameObject nbear;
    private int cnt;
    public int level;
    private int deltaTime;
    // Use this for initialization
    void Start () {
        cnt = 0;
        deltaTime = 1200;
        level = 1;
	}
    public void LevelUP()
    {
        if (deltaTime > 60)
        {
            deltaTime -= 100;
        }
        else
        {
            deltaTime = 60;
        }
        level++;
    }
    // Update is called once per frame
    void Update () {
		if (cnt >= deltaTime)
        {
            cnt = 0;
        }
        if(cnt == 0)
        {
            nbear=Instantiate(bear, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Debug.Log(nbear);
            nbear.GetComponent<BearInit>().LevelUP(level);
        }
        cnt++;
	}
}
