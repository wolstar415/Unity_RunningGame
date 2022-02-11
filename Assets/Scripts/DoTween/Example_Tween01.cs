using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Example_Tween01 : MonoBehaviour
{
    public Ease ease;
    public LoopType loopType;
    public Vector3 targetPos;
    public float tweenDuration;

   
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        transform.DOMove(targetPos, tweenDuration).SetLoops(-1,loopType).SetEase(ease);
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        
    }
}
