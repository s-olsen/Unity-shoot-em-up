using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenemove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    float speed = 0.05f;
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed);
	}
}
