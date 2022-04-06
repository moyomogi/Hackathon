using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class BossScript : MonoBehaviour
{
    public int bossHp = 1;
    private GameObject player;

    public float shotSpan = 1.5f;
    public float bulletSpeed = 20.0f;
    private float currentTime = 0f;

    [SerializeField] private GameObject enemyBullet;

    [SerializeField]
    private Renderer _renderer;

    //public GameObject playerSprite;


    private Sequence _seq;

    float dis = 0.0f;

    private Collider coll;

    public BossUIManager bossUIManager;

    private bool isBossDead = false;

    private Animator bossAnimator;

    public AudioClip bossDieSE;

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            enemyHp -= 1;
            if (enemyHp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }*/

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //playerSprite = GameObject.FindGameObjectWithTag("PlayerSprite");
        dis = Vector3.Distance(player.transform.position, transform.position);
        coll = this.GetComponent<Collider>();
        bossAnimator = GetComponent<Animator>();

        shotSpan = 1.5f;
        bulletSpeed = 20.0f;
    }

    private void Update()
    {
        dis = Vector3.Distance(player.transform.position, transform.position);
        currentTime += Time.deltaTime;
        if (currentTime > shotSpan)
        {
            if (dis <= 30.0f && bossHp >= 0)
            {
                Shot();
            }
            currentTime = 0f;
        }

        if (bossHp <= 75)
        {
            bulletSpeed = 30.0f;
        }

        if (bossHp <= 50)
        {
            shotSpan = 1.0f;
        }


    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            bossHp -= other.gameObject.GetComponent<BulletScript>().GetBulletDamage();
            bossUIManager.UpdateBossHP(bossHp);
            Destroy(other.gameObject);


            if (bossHp <= 0)
            {
                player.gameObject.GetComponent<PlayerScript>().PlusEnemyCount();
                bossAnimator.SetTrigger("IsDead");
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>().PlayOneShot(bossDieSE);
                Invoke("Destory", 2.5f);
            }
            else
            {
                HitBlink();
            }
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine("Blow");
        }


    }

    //Invoke—p
    public void Destory()
    {
        Destroy(gameObject);
        Time.timeScale = 0;
        isBossDead = true;
    }


    //https://sunagitsune.com/unitycollisionvector2d/


    IEnumerator Blow()
    {
        int i = 0;
        while (i < 5)
        {
            yield return new WaitForSeconds(0.03f);
            player.transform.Translate(
                (player.transform.position - this.transform.position).normalized.x / 2,
                0,
                0
            );

            i++;
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
        bossAnimator.SetTrigger("Shot");
        var pos = this.gameObject.transform.position;

        if (dis <= 30.0f)
        {
            var t = Instantiate(enemyBullet) as GameObject;
            t.transform.position = pos;
            Vector3 vec = Vector3.Scale((player.transform.position - pos), new Vector3(1, 1, 0)).normalized;
            t.GetComponent<Rigidbody>().velocity = vec * bulletSpeed;

            var t2 = Instantiate(enemyBullet) as GameObject;
            var pos2 = pos + new Vector3(0.0f, -1.5f, 0.0f);
            t2.transform.position = pos2;
            Vector3 vec2 = Vector3.Scale((player.transform.position - pos2), new Vector3(1, 1, 0)).normalized;
            t2.GetComponent<Rigidbody>().velocity = vec2 * bulletSpeed * 0.7f;


            if (bossHp <= 50)
            {
                var pos1 = player.transform.position + new Vector3(0.0f, 7.0f, 0.0f);
                var t1 = Instantiate(enemyBullet) as GameObject;
                t1.transform.position = pos1;
                Vector3 vec1 = Vector3.Scale((player.transform.position - pos1), new Vector3(1, 1, 0)).normalized;

                t1.GetComponent<Rigidbody>().velocity = vec1 * bulletSpeed * 0.15f;
            }
            else if (bossHp <= 25)
            {
                var pos3 = player.transform.position + new Vector3(2.0f, 7.0f, 0.0f);
                var t3 = Instantiate(enemyBullet) as GameObject;
                t3.transform.position = pos3;
                Vector3 vec3 = Vector3.Scale((player.transform.position - pos3), new Vector3(1, 1, 0)).normalized;

                t3.GetComponent<Rigidbody>().velocity = vec3 * bulletSpeed * 0.3f;

                var pos4 = player.transform.position + new Vector3(-2.0f, 7.0f, 0.0f);
                var t4 = Instantiate(enemyBullet) as GameObject;
                t4.transform.position = pos4;
                Vector3 vec4 = Vector3.Scale((player.transform.position - pos4), new Vector3(1, 1, 0)).normalized;

                t4.GetComponent<Rigidbody>().velocity = vec4 * bulletSpeed * 0.3f;
            }
        }

    }

    public bool IsBossDead()
    {
        return isBossDead;
    }



}
