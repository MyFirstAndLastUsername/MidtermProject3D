using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour {

    private Transform bar;
    private float fullHealth;
    private float damage;

    // Use this for initialization
    void Start () {
        bar = transform.Find("Bar");
        damage = 0f;
	}

    public void setFullHeal(float fh)
    {
        fullHealth = fh;
    }
	
    public void getHurt(float dm)
    {
        damage += dm;
        float tmp = fullHealth - damage;
        if (damage > fullHealth) tmp = 0;
        bar.localScale = new Vector3(tmp / fullHealth, 1f);
    }
    public void setValue(float value)
    {
        bar.localScale = new Vector3(value / fullHealth, 1f);
    }
}
