using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Example_Tween04 : MonoBehaviour
{
    public Transform targetCam;

    public float shakeDuration = 1f;
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        
    }

    public void shakeCamera()
    {
        //targetCam.DOShakePosition(shakeDuration,new Vector3(1,0,-10f),1f,90f,true);
    }
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        
    }
}
