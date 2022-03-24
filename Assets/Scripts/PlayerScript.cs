using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerScript : MonoBehaviour
{
    public GameObject bullet;
    private GameObject player;

    public AudioClip audioClip;
    private AudioSource audioSource;

    [SerializeField] AbilityModuleManager m_AbilityModuleManager = null;

    private int playerHP = 100;

    public UIManager uIManager;

    [SerializeField]
    private Renderer _renderer;

    private Sequence _seq;

    private bool isDead = false;
    public bool getIsDead() { return isDead; }


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
                HitBlink();
                uIManager.UpdateHP(playerHP);

                if (playerHP > 0)
                {
                    Debug.Log("Žc‚èHP:" + playerHP);
                }
                else
                {
                    isDead = true;
                    Debug.Log("GameOver");
                }
            }
        }

    }

    private void HitBlink()
    {
        _seq?.Kill();
        _seq = DOTween.Sequence();
        _seq.AppendCallback(() => _renderer.enabled = false);
        _seq.AppendInterval(0.05f);
        _seq.AppendCallback(() => _renderer.enabled = true);
        _seq.AppendInterval(0.05f);
        _seq.SetLoops(2);
        _seq.Play();
    }
}
