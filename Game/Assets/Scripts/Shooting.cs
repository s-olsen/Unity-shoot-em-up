using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public float velocityX = 5f;
    public float velocityY = 0f;
    public float velocityZ = 0f;
    public Rigidbody rbBulletFire;
        
    
    // Use this for initialization
	void Start () {
        rbBulletFire = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rbBulletFire.velocity = new Vector3(velocityX, velocityY, velocityZ);
        Destroy(gameObject, 2f);
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
            
        
    }

}




