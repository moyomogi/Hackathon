using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Unity Tutorial | Coin Pickups https://youtu.be/XnKKaL5iwDM
        // other: gameObject, Transform Ç key Ç…éùÇ¬
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.gemsNum++;
            GameManager.instance.obtainedGemNames.Add(gameObject.name);
            Debug.Log(GameManager.instance.gemsNum);
            // GameManager.instance.obtainedGemNames.forEach(Debug.Log);
            // Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
