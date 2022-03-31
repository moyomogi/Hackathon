using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject lv3Bullet;
    public GameObject lv5Bullet;
    private GameObject player;

    public AudioClip audioClip;
    public AudioClip damagedAudioClip;
    private AudioSource audioSource;
    public AudioClip gemAudioClip;

    [SerializeField] AbilityModuleManager m_AbilityModuleManager = null;

    private int playerHP = 100;

    public UIManager uIManager;

    [SerializeField]
    private Renderer _renderer;

    private Sequence _seq;

    public float mutekiFlag = 0;
    public float mutekiTime = 80;
    public float timeStep = 1;

    private bool isDead = false;
    public bool getIsDead() { return isDead; }

    //private int playerLevel = 1;

    //QuestpĎ
    [SerializeField] private QuestManagement questManagement = null;

    private int jumpCount = 0;
    private int slideCount = 0;
    private bool isCountSlide = true;
    private int destroyEnemyCount = 0;
    private int wallRunCount = 0;
    private bool isCountWallRun = true;
    //private int getGamCount = 0;

    private AbilityModule module = null;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("PlayerSprite");
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    private void Start()
    {
        lv5Bullet.transform.localScale = new Vector3(7f, 7f, 1.0f);
        jumpCount = 0;
        slideCount = 0;
        isCountSlide = true;
        destroyEnemyCount = 0;
        wallRunCount = 0;
        isCountWallRun = true;


        //Boss_SceneüÁ˝ŕxŰ

        uIManager.UpdatePlayerLevelUI(GameManager.instance.playerLevel);

        if (GameManager.instance.playerLevel == 2)
        {
            bullet.GetComponent<BulletScript>().SetBulletSpeed(50.0f);
            //uIManager.LevelUpExplainText("level 1 -> 2 BulletSpeed Up!!");
        }
        else if (GameManager.instance.playerLevel == 3)
        {
            bullet = lv3Bullet;
            bullet.GetComponent<BulletScript>().SetBulletDamage(2);
            bullet.GetComponent<BulletScript>().SetBulletSpeed(50.0f);
            //uIManager.LevelUpExplainText("level 2 -> 3 BulletDamage Up!!");
        }
        else if (GameManager.instance.playerLevel == 4)
        {
            bullet = lv3Bullet;
            bullet.GetComponent<BulletScript>().SetBulletDamage(2);
            bullet.GetComponent<BulletScript>().SetBulletSpeed(75.0f);
            //uIManager.LevelUpExplainText("level 3 -> 4 BulletSpeed Up!!");
        }
        else if (GameManager.instance.playerLevel == 5)
        {
            bullet = lv5Bullet;
            bullet.GetComponent<BulletScript>().SetBulletDamage(3);
            bullet.GetComponent<BulletScript>().SetBulletSpeed(75.0f);
            //uIManager.LevelUpExplainText("level 4 -> 5 BulletDamage Up!!");
        }
        else if (GameManager.instance.playerLevel == 6)//MAX
        {
            bullet = lv5Bullet;
            bullet.GetComponent<BulletScript>().SetBulletDamage(3);
            bullet.GetComponent<BulletScript>().SetBulletSpeed(75.0f);
            bullet.transform.localScale = new Vector3(10f, 10f, 1.0f);
            //uIManager.LevelUpExplainText("level 5 -> MAX BulletSize Up!!");
        }
    }
    private void Update()
    {
        if (m_AbilityModuleManager != null)
        {
            module = m_AbilityModuleManager.GetCurrentModule();
        }

        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Z))
        {
            if (m_AbilityModuleManager != null)
            {
                //AbilityModule module = m_AbilityModuleManager.GetCurrentModule();
                if (module == null || module.GetName() == "Sprint")
                {
                    Shot();
                }
                else if (module.GetName() == "Crouch" || module.GetName() == "Slide")
                {
                    CronchShot();
                }
            }
        }
        //_[WăĚłGÔXV
        if (mutekiFlag == 1)
        {
            mutekiTime -= timeStep;
            if (mutekiTime < 0)
            {
                mutekiFlag = 0;
                mutekiTime = 80;
            }
            //Debug.Log(mutekiTime);
        }

        //jumpťč
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_AbilityModuleManager != null)
            {
                //AbilityModule module = m_AbilityModuleManager.GetCurrentModule();
                if (module == null || module.GetName() == "WallRun" || module.GetName() == "WallSlide")
                {
                    jumpCount++;
                    Debug.Log("JumpCount: " + jumpCount);
                }
            }
        }


        //Slide,WallRunťč
        if (m_AbilityModuleManager != null)
        {
            //AbilityModule module = m_AbilityModuleManager.GetCurrentModule();
            if (module != null)
            {
                if (module.GetName() == "Slide")
                {
                    if (isCountSlide)
                    {
                        slideCount++;
                        //Debug.Log("slideCount: " + slideCount);
                        isCountSlide = false;
                    }
                }
                else if (module.GetName() == "WallRun")
                {
                    if (isCountWallRun)
                    {
                        wallRunCount++;
                        //Debug.Log("wallRunCount: " + wallRunCount);
                        isCountWallRun = false;
                    }
                }
                else
                {
                    isCountSlide = true;
                    isCountWallRun = true;
                }
            }
            else
            {
                isCountSlide = true;
                isCountWallRun = true;
            }

        }

        //Quest
        if (jumpCount >= 10 && !questManagement.IsQuestFlag(0))
        {
            questManagement.SetQuestFlag(0);
            Debug.Log(questManagement.GetQuest(0).GetInformation());
            LevelUp();
            //Debug.Log(playerLevel);
        }
        else if (GetEnemyCount() >= 1 && !questManagement.IsQuestFlag(1))
        {
            questManagement.SetQuestFlag(1);
            Debug.Log(questManagement.GetQuest(1).GetInformation());
            LevelUp();
            //Debug.Log(playerLevel);
        }
        else if (slideCount >= 3 && !questManagement.IsQuestFlag(2))
        {
            questManagement.SetQuestFlag(2);
            Debug.Log(questManagement.GetQuest(2).GetInformation());
            LevelUp();
            //Debug.Log(playerLevel);
        }
        else if (wallRunCount >= 3 && !questManagement.IsQuestFlag(3))
        {
            questManagement.SetQuestFlag(3);
            Debug.Log(questManagement.GetQuest(3).GetInformation());
            LevelUp();
            //Debug.Log(playerLevel);
        }
        //Quest4ĚRCĚ
        else if (GameManager.instance.gemsNum >= 5 && !questManagement.IsQuestFlag(4))
        {
            questManagement.SetQuestFlag(4);
            Debug.Log(questManagement.GetQuest(4).GetInformation());
            LevelUp();
        }


        //Debug
        if (Input.GetKeyDown(KeyCode.P))
        {
            LevelUp();
        }


    }


    private void OnCollisionEnter(Collision other)
    {
        if (playerHP > 0)
        {
            if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBullet")
            {
                if (mutekiFlag == 0)
                {
                    mutekiFlag = 1;

                    playerHP -= 10;
                    HitBlink();
                    uIManager.UpdateHP(playerHP);
                    audioSource.PlayOneShot(damagedAudioClip);

                    if (playerHP > 0)
                    {
                        Debug.Log("cčHP:" + playerHP);
                    }
                    else
                    {
                        isDead = true;
                        Debug.Log("GameOver");
                    }
                }

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Gem")
        {
            audioSource.PlayOneShot(gemAudioClip,0.3f);
        }
        
    }

    private void HitBlink()
    {
        _seq?.Kill();
        _seq = DOTween.Sequence();
        _seq.AppendCallback(() => _renderer.enabled = false);
        _seq.AppendInterval(0.15f);
        _seq.AppendCallback(() => _renderer.enabled = true);
        _seq.AppendInterval(0.15f);
        _seq.SetLoops(2);
        _seq.Play();
    }

    public void Shot()
    {
        Instantiate(bullet, transform.position + new Vector3(1.6f * player.transform.localScale.x, 0.4f, 0f), transform.rotation);
        audioSource.PlayOneShot(audioClip);
    }

    public void CronchShot()
    {
        Instantiate(bullet, transform.position + new Vector3(1.6f * player.transform.localScale.x, 0.2f, 0f), transform.rotation);
        audioSource.PlayOneShot(audioClip);
    }


    public void LevelUp()
    {
        if (GameManager.instance.playerLevel >= 6) return;
        GameManager.instance.playerLevel += 1;
        //řĘš&GtFNg
        uIManager.UpdatePlayerLevelUI(GameManager.instance.playerLevel);
        if (GameManager.instance.playerLevel == 2)
        {
            bullet.GetComponent<BulletScript>().SetBulletSpeed(50.0f);
            uIManager.LevelUpExplainText("level 1 -> 2 BulletSpeed Up!!");
        }
        else if (GameManager.instance.playerLevel == 3)
        {
            bullet = lv3Bullet;
            bullet.GetComponent<BulletScript>().SetBulletDamage(2);
            bullet.GetComponent<BulletScript>().SetBulletSpeed(50.0f);
            uIManager.LevelUpExplainText("level 2 -> 3 BulletDamage Up!!");
        }
        else if (GameManager.instance.playerLevel == 4)
        {
            bullet.GetComponent<BulletScript>().SetBulletSpeed(75.0f);
            uIManager.LevelUpExplainText("level 3 -> 4 BulletSpeed Up!!");
        }
        else if (GameManager.instance.playerLevel == 5)
        {
            bullet = lv5Bullet;
            bullet.GetComponent<BulletScript>().SetBulletDamage(3);
            bullet.GetComponent<BulletScript>().SetBulletSpeed(75.0f);
            uIManager.LevelUpExplainText("level 4 -> 5 BulletDamage Up!!");
        }
        else if (GameManager.instance.playerLevel == 6)//MAX
        {
            bullet.transform.localScale = new Vector3(10f, 10f, 1.0f);
            uIManager.LevelUpExplainText("level 5 -> MAX BulletSize Up!!");
        }

    }

    public void PlusEnemyCount()
    {
        destroyEnemyCount++;
        Debug.Log("EnemyCount: " + destroyEnemyCount);
    }

    public int GetEnemyCount()
    {
        return destroyEnemyCount;
    }


}
