using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyScript : MonoBehaviour
{
    public int enemyHp = 1;
    private GameObject player;

    public float shotSpan = 1.5f;
    public float bulletSpeed = 10.0f;
    private float currentTime = 0f;

    [SerializeField] private GameObject enemyBullet;

    [SerializeField]
    private Renderer _renderer;

    [SerializeField] private AudioClip dieSE;


    private Sequence _seq;

    float dis = 0.0f;

    private Collider coll;

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Bullet"))
    //     {
    //         Destroy(other.gameObject);
    //         enemyHp -= 1;
    //         if (enemyHp <= 0)
    //         {
    //             Destroy(gameObject);
    //         }
    //     }
    // }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dis = Vector3.Distance(player.transform.position, transform.position);
        coll = this.GetComponent<Collider>();
    }

    private void Update()
    {
        dis = Vector3.Distance(player.transform.position, transform.position);
        currentTime += Time.deltaTime;
        if (currentTime > shotSpan)
        {
            if (dis <= 30.0f)
            {
                // Shot(); // アニメーションで制御することにした
            }
            currentTime = 0f;
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            enemyHp -= other.gameObject.GetComponent<BulletScript>().GetBulletDamage();
            Destroy(other.gameObject);


            if (enemyHp <= 0)
            {
                player.gameObject.GetComponent<PlayerScript>().PlusEnemyCount();
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>().PlayOneShot(dieSE);
                Destroy(gameObject);
            }
            else
            {
                HitBlink();
            }
        }
        // else if (other.gameObject.CompareTag("Player"))
        // {
        //     StartCoroutine("Blow");
        // }


    }

    // https://sunagitsune.com/unitycollisionvector2d/
    IEnumerator Blow()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.03f);
            player.transform.Translate((player.transform.position - this.transform.position).normalized.x / 2, 0, 0);
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

    public void Shot()
    {

        var pos = this.gameObject.transform.position;

        if (dis <= 30.0f)
        {
            GameObject obj = Instantiate(enemyBullet) as GameObject;
            obj.transform.position = pos;
            Vector3 vec = Vector3.Scale((player.transform.position - this.gameObject.transform.position), new Vector3(1, 1, 0)).normalized;

            obj.GetComponent<Rigidbody>().velocity = vec * bulletSpeed;
        }
    }

}
