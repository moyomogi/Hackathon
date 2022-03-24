using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //https://hiyotama.hatenablog.com/entry/2015/06/16/090000

    private GameObject player;
    private float bulletSpeed = 50.0f;



    private void Start()
    {


        player = GameObject.FindGameObjectWithTag("PlayerSprite");

        Rigidbody rb = GetComponent<Rigidbody>();



        rb.velocity = new Vector3(bulletSpeed * player.transform.localScale.x, 0, 0);

        Vector3 tmp = transform.localScale;
        tmp.x = player.transform.localScale.x;
        transform.localScale = tmp;

        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Player") 
        {
            Debug.Log(other.gameObject.tag);
            Destroy(gameObject);
        }
    }
}
