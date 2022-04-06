using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStoneScript : MonoBehaviour
{
    public GameObject target;
    private bool isActivated = false;
    private bool isFalling = false;
    private bool isRising = false;
    private int fallDistance = 8;
    private float hitDistance = 13;
    private float nowDistance = 0;
    public float fallingSpeed = 0.035f;
    public float risingSpeed = 0.01f;

    void Update()
    {
        Vector3 cube = target.transform.position;
        float dis = Vector3.Distance(cube, this.transform.position);

        if (dis < hitDistance)
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
        if (nowDistance >= fallDistance)
        {
            isFalling = false;
            isRising = true;
            return;
        }
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        pos.y -= fallingSpeed;
        myTransform.position = pos;
        nowDistance += fallingSpeed;
    }
    void Rise()
    {
        if (nowDistance <= 0)
        {
            isRising = false;
            isActivated = false;
            return;
        }
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        pos.y += risingSpeed;
        myTransform.position = pos;
        nowDistance -= risingSpeed;
    }
}
