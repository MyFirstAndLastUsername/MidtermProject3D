using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryFlyFlat : MonoBehaviour {
    public GameObject flyflat,flyflat2,flyflat3,flyflat4;
    private int cnt;
    private int level;
    // Use this for initialization
    void Start () {
        cnt = 400;
        level = 1;
	}

    public void LevelUP()
    {
        if (level < 4)
        {
            level += 1;
        }
    }

	// Update is called once per frame
	void Update () {
        if (cnt >= 1200)
        {
            cnt = 0;
        }
        if (cnt == 0)
        {
            int randomNumber = Random.Range(0,  level);
            switch (randomNumber) {
                case 1:
                    Instantiate(flyflat, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    break;
                case 2:
                    Instantiate(flyflat4, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    break;
                case 3:
                    Instantiate(flyflat2, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    break;
                case 4:
                    Instantiate(flyflat3, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    break;
            }
            
        }
        cnt++;
    }
}
