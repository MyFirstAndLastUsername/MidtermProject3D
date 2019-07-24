using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryFlyEnemy : MonoBehaviour {
    public GameObject bee;
    public GameObject nbee;
    public int level;
    private int deltaTime;
    private int cnt;
	// Use this for initialization
	void Start () {
        cnt = 200;
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
        if (cnt == 0)
        {
            nbee=Instantiate(bee, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            nbee.GetComponent<BeeInit>().LevelUP(level);
        }
        cnt++;
    }
}
