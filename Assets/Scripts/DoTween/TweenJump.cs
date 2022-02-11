using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TweenJump : MonoBehaviour
{
    public Vector3 curPos;
    public Vector3 jumpPos;
    public float jumpPower;
    public int jumpLimit;
    public float jumpDuration;


    public void Jump()
    {
        curPos = transform.position;
        jumpPos = new Vector3(0, 1, 0);
        transform.DOJump(jumpPos, jumpPower, jumpLimit, jumpDuration);
    }
   
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}
