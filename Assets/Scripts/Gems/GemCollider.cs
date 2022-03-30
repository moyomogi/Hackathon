using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GemCollider : MonoBehaviour
{
    //private AudioSource audioSource;
    //[SerializeField] private AudioClip gemAudioClip;

    void OnTriggerEnter(Collider other)
    {
        // Unity Tutorial | Coin Pickups https://youtu.be/XnKKaL5iwDM
        // other: gameObject, Transform Ç key Ç…éùÇ¬
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.gemsNum++;
            Debug.Log(GameManager.instance.gemsNum);
            Destroy(gameObject);
        }
    }
}
