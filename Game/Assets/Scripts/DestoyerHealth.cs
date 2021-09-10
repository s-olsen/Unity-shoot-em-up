using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyerHealth : MonoBehaviour {
    public int destroyerhealth = 3;
    int damage = 1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (destroyerhealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            destroyerhealth -= damage;
            print("destroyer hit "+ destroyerhealth);
        }
    }
}
