using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour {

    

    public float speed = 0.07F;
    public bool istopdown = true;
    private Rigidbody bullet;
  public  Rigidbody newbullet;
    public Transform gun;
    float firerate = 1f;
    float nextfire;

    public AudioSource Pew;

    
    // Use this for initialization
    void Start () {
        
    }
	
    void Fire()
    {
       
       Rigidbody bullet = (Rigidbody) Instantiate(newbullet, gun.position, gun.rotation);
        Pew.Play();
    }


    // Update is called once per frame
    void Update() {
        if (istopdown == true)
        {
            if (Input.GetButton("w"))
            {
                transform.Translate(Vector3.forward * speed);
            }
            if (Input.GetButton("a"))
            {
                transform.Translate(Vector3.left * speed);
            }
            if (Input.GetButton("s"))
            {
                transform.Translate(Vector3.back * speed);
            }
            if (Input.GetButton("d"))
            {
                transform.Translate(Vector3.right * speed);
            }

        }
        else {
            if (Input.GetButton("w"))
            {
                transform.Translate(Vector3.up * speed);
            }
            if (Input.GetButton("a"))
            {
                transform.Translate(Vector3.back * speed);
            }
            if (Input.GetButton("s"))
            {
                transform.Translate(Vector3.down * speed);
            }
            if (Input.GetButton("d"))
            {
                transform.Translate(Vector3.forward * speed);
            }

        }
         if(Input.GetButtonUp("u") && Time.time > nextfire)
         {
            nextfire = Time.time + firerate;
            Fire();

         }
    }


}
