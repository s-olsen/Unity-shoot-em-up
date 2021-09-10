using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Summary: This code allows for one bullet to be fired every 5 seconds, by attatching the script to multiple empty objects we can set up a simple bullet pattern.
public class scoutbehaviour : MonoBehaviour {
    public Rigidbody bullet;
    private Rigidbody newbullet;
    public Transform bulletspawn;
    private float timer = 5f;

    private void Update()
    {
        Fire();
    }
    void Fire()
    {
        timer -= Time.deltaTime;
        if (timer <=0)
        {
                Quaternion rotation = Quaternion.Euler(new Vector3(0, 90, 0));

                Rigidbody newbullet = Instantiate(bullet);
                newbullet.transform.position = bulletspawn.position;
                newbullet.transform.rotation = rotation;
                newbullet.AddForce(bulletspawn.up * 50);

             
                timer = 5f;
          
        }
 
     
    }
  
}
