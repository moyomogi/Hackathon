using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitScript : MonoBehaviour
{
    public GameObject target;
    void Update()
    {
        Vector3 player = target.transform.position;
        float dis = Vector3.Distance(player, this.transform.position);
        if (dis < 1)
        {
            SceneManager.LoadScene("BossScene");
        }

    }
}
