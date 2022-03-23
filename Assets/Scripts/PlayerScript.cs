using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject bullet;
    private GameObject player;

    public AudioClip audioClip;
    private AudioSource audioSource;

    [SerializeField] AbilityModuleManager m_AbilityModuleManager = null;

    private int playerHP = 100;

    public UIManager uIManager;



    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("PlayerSprite");
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(m_AbilityModuleManager != null)
            {
                AbilityModule module = m_AbilityModuleManager.GetCurrentModule();
                if(module == null || module.GetName() == "Sprint")
                {
                    Instantiate(bullet, transform.position + new Vector3(1.6f * player.transform.localScale.x, 0.7f, 0f), transform.rotation);
                    audioSource.PlayOneShot(audioClip);
                }
            }
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if(playerHP > 0)
        {
            if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBullet")
            {
                playerHP -= 10;
                uIManager.UpdateHP(playerHP);

                if(playerHP > 0) Debug.Log("Žc‚èHP:" + playerHP);
                else Debug.Log("GameOver");
            }
            
        }

    }
}
