using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Object : MonoBehaviour
{
    public GameObject target;
    public bool isActivated = false;
    public bool isFalling = false;
    public bool isRising = false;
    public int fall_distance;
    public float hit_distance;
    public float now_distance = 0;
    public float fallingSpeed = 0.035f;
    public float risingSpeed = 0.01f;



    void Update()
    {
        Vector3 cube = target.transform.position;
        float dis = Vector3.Distance(cube, this.transform.position);

        if (dis < hit_distance)
        {
            if (!isActivated)
            {
                isActivated = true;
                isFalling = true;
            }
        }
        if (isFalling)
        {
            Fall();
        }
        else if (isRising)
        {
            Rise();
        }
    }

    void Fall()
    {
        if (now_distance >= fall_distance)
        {
            isFalling = false;
            isRising = true;
            return;
        }
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        pos.y -= fallingSpeed;
        myTransform.position = pos;
        now_distance += fallingSpeed;
    }
    void Rise()
    {
        if (now_distance <= 0)
        {
            isRising = false;
            isActivated = false;
            return;
        }
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        pos.y += risingSpeed;
        myTransform.position = pos;
        now_distance -= risingSpeed;

    }
}