using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutHealth : MonoBehaviour {
    public int scouthealth;
    int damage = 1;
	// Use this for initialization
	void Start () {
        scouthealth = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(scouthealth <= 0)
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            scouthealth -= damage;
            print("scout hit");
        }
    }
}
