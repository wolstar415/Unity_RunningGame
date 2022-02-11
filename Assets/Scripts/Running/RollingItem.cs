using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingItem : MonoBehaviour
{
    
    public float Speed = 250f;
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        transform.Rotate(new Vector3(0, Speed*Time.deltaTime, 0));

    }
}
