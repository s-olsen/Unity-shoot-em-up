using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyerbehaviour : MonoBehaviour {
    public int BulletsShot;
    public float BulletsSpread;
    public Rigidbody Bullet;
    public Transform gun;
    private float timer = 2f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            Fire();
            timer = 8f;
        };
            

    }
    public void Fire()
    {
        float TotalSpread = BulletsSpread / BulletsShot;
        for (int i = 0; i < BulletsShot; i++)
        {
            float n = (Random.value);
            float spreadA = TotalSpread * (i + n);
            float spreadB = BulletsSpread / 2f;
            float spread = spreadB - spreadA + TotalSpread / 2;
            float angle = transform.eulerAngles.y;

           
            gun.rotation = Quaternion.Euler(new Vector3( spread + angle ,spread + angle, spread + angle));
           
            Rigidbody newbullet = Instantiate(Bullet);
            newbullet.position = transform.position;
            newbullet.rotation = gun.rotation;
            newbullet.AddForce(-gun.forward * 50);
        }
    }
}
