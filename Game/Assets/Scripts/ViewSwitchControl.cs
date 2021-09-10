using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSwitchControl : MonoBehaviour {

    public Animator anim;
    public bool td;
    
	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        td = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp("y"))
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Playermovement>().istopdown == true)
                GameObject.FindGameObjectWithTag("Player").GetComponent<Playermovement>().istopdown = false;
            else
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Playermovement>().istopdown = true;
            }
            if (td == false)
            {
                anim.SetTrigger("SD2TD");
                td = true;
                return;

            }
            else if (td == true)
            {
                anim.SetTrigger("TD2SD");
                td = false;
                return;
            }
        }
       
        
    }
}
