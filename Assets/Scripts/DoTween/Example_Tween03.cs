using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Example_Tween03 : MonoBehaviour
{
    public Ease ease;
    public LoopType loopType;
    public Vector3 targetPos;
    public float tweenDuration;
    public RectTransform rectTransform;

    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        rectTransform = GetComponent<RectTransform>();
        //transform.DOMove(targetPos, tweenDuration).SetLoops(-1, loopType).SetEase(ease);
        transform.DORotate(targetPos, tweenDuration).SetLoops(-1, loopType).SetEase(ease);
    }

    public void bRotate()
    {

        rectTransform.DORotate(new Vector3(0, 0, 350), 1f);

    }

    void Update() // 매 프레임마다 실행되는 함수입니다.
    {

    }
}
