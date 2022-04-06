using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointScript : MonoBehaviour
{
    public AudioClip saveClip;
    Vector3 basePos;
    AudioSource audioSource;
    float theta = 0.0f;

    void Start()
    {
        // tag が AudioManager
        audioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.Log("audioSource が見つかりませんでした");
        }
        basePos = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        // もし other の tag が Player なら
        if (other.tag == "Player")
        {
            Debug.Log("(SavePoint)");
            audioSource.PlayOneShot(saveClip);
            SaveManager.Save();
        }
    }
    private void FixedUpdate()
    {
        theta += 0.1f;
        gameObject.transform.position = new Vector3(basePos.x, basePos.y + Mathf.Sin(theta) * 0.5f, basePos.z);
    }
}
