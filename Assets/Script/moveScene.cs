using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class moveScene : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player = target.transform.position;
        float dis = Vector3.Distance(player, this.transform.position);
        if(dis < 1){  
             SceneManager.LoadScene("Boss_Battle");
        }
        
    }
}
