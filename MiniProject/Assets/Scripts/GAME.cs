using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAME : MonoBehaviour {
    public int level;
    private int levelCNT;
    private int levelUPcnt;
    private int cnt;
    private Transform player1,player2,fenemy,ffenemy,fff;
	// Use this for initialization
	void Start () {
        level = 0;
        levelCNT = 600;
        levelUPcnt = 600;
        cnt = 0;
        player1 = transform.Find("Player");
        player2 = transform.Find("Player2");
        fenemy = transform.Find("BearObject");
        ffenemy = transform.Find("FlyEnemyObject");
        fff = transform.Find("FlyFlatObject");
	}
	
	// Update is called once per frame
	void Update () {
        cnt++;
        if (cnt >= levelCNT)
        {
            level++;
            fenemy.GetComponent<FactoryEnemy>().LevelUP();
            ffenemy.GetComponent<FactoryFlyEnemy>().LevelUP();
            fff.GetComponent<FactoryFlyFlat>().LevelUP();
            player1.GetComponent<PlayerController>().LevelUP();
            player2.GetComponent<PlayerController2>().LevelUP();
            levelCNT += levelUPcnt;
            cnt = 0;
        }
	}
}
