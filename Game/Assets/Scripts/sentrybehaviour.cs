using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sentrybehaviour : MonoBehaviour {
    public Rigidbody bullet;
    private Rigidbody newbullet;
    public Transform gun;
    private float timer = 2f;
    public GameObject player;
    Quaternion newRotation;
    


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 shoot_angle = (gun.position - player.position);
       newRotation = Quaternion.LookRotation(player.transform.position - gun.position);
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            //Quaternion rotation = Quaternion.Euler(shoot_angle);
            gun.rotation = Quaternion.RotateTowards(newRotation,transform.rotation,Time.deltaTime*15);

            Rigidbody newbullet = Instantiate(bullet);
            newbullet.position = gun.position;
            newbullet.rotation = gun.rotation;
            newbullet.AddForce(gun.forward * 70);
            timer = 1.7f;
        }
        
        //Fire();
    }
    /*void Fire()
    {
            for (int i = 0; i < 3; i++)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    
                    Quaternion rotation = Quaternion.Euler(new Vector3(player, 0, 0));

                    Rigidbody newbullet = Instantiate(bullet);
                    newbullet.transform.position = gun.position;
                    newbullet.transform.rotation = rotation;
                    newbullet.AddForce(gun.up * 50);


                timer = 8f;
                };
            }
          
    }*/
}
