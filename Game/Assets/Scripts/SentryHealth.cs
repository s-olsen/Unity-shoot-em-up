using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryHealth : MonoBehaviour {
    public int sentryhealth = 2;
    int damage = 1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (sentryhealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            sentryhealth -= damage;
            print("sentry hit "+sentryhealth);
        }
    }
}
