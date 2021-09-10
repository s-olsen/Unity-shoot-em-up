using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Newplayerhealthsystem : MonoBehaviour
{
    public int playerhealth = 3;
    int damage = 1;
    float timer = 2f;
   
    bool dead = false;
    private void Update()
    {
        if(playerhealth <= 0)
        {
            Destroy(gameObject);
            dead = true;
            gameOver();
        }

       
    }

    private void OnCollisionEnter(Collision _collision)
    {
        if (_collision.gameObject.tag == "Enemy" || _collision.gameObject.tag == "EnemyBullet")
        {
            playerhealth -= damage;
            print("hit " + playerhealth);
        }
    }
   
    public void gameOver()
    {

            Debug.Log("game over");
            LoadByIndex(2);

    }

    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
