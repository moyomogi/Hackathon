using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private GameObject player;
    




    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerSprite");

        Rigidbody rb = GetComponent<Rigidbody>();



        Destroy(gameObject, 5);
    }



    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("hit");

        string tag = other.gameObject.tag;

        Debug.Log(tag);
        
        if (other.gameObject.tag != "Enemy")
        {
            //Debug.Log("hit");

            //Debug.Log(other.gameObject.tag);
            Destroy(gameObject);

            /*if (other.gameObject.tag != "EnemyBullet")
            {
                Debug.Log(other.gameObject.tag);
                Destroy(gameObject);
            }*/
        }
    }
}
