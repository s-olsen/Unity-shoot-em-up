using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public Rigidbody bullet;
    // Use this for initialization
    void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, 3f);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
        /*if (col.gameObject.tag == "MainCamera")
        {
            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
        }*/
    }

}
