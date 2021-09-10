using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTypeA : MonoBehaviour {

    public GameObject enemy_1;
    public GameObject enemy_2;
    public GameObject enemy_3;
    public Transform playertransform;
    public Transform spawn1;
    public Transform spawn2;
    private float timer = 6f;
    float speed = 0.1F;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-Vector3.forward * speed);
        /*timer -= Time.deltaTime;
        if(timer <= 0)
        {
            enemy_2.transform.Translate((Vector3.forward * speed)*2);
            print("Enemy moving!");
        }*/
    }
    void SpawnEnemy()
    {
            print("Enemies spawned");
            Instantiate(enemy_2);
            enemy_2.transform.position = spawn1.position;


            Instantiate(enemy_3);
            enemy_3.transform.position = spawn2.position;

            Vector3 vector3 = (spawn2.position - spawn1.position);
            Instantiate(enemy_1);
            enemy_1.transform.position = vector3;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("Player entered spawn collision");
            SpawnEnemy();   

        }
    }
}
