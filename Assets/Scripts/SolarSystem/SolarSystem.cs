using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SolarSystem : MonoBehaviour
{
    public Vector3 vector;
    public float SpeedDuration;
    public RotateMode rotateMode;
    public LoopType loopType;
    public Ease ease;
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        //transform.DORotate(vector, Speed, rotateMode).SetLoops(-1,loopType);
        transform.DORotate(vector, SpeedDuration, rotateMode)
                     .SetEase(ease)
                     .SetLoops(-1, loopType);

    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        
    }
}
