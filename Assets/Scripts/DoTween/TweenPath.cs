using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenPath : MonoBehaviour
{
    public Transform[] targets;
    public Vector3[] path;
    public PathMode pathMode;
    public PathType pathType;
    public float pathTime = 5f;
    public Color32 PathColor;
    public Transform unityChan;


    void Start()  // 처음 시작시 실행되는 함수입니다.
    {

        for (int i = 0; i < targets.Length; i++)
        {
            path[i] = targets[i].position;
        }

        transform.DOPath(path, pathTime,pathType,pathMode,10,PathColor).
            SetLookAt(unityChan,true);
    }

       
}
