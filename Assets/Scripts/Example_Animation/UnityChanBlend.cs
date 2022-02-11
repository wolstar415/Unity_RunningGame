using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanBlend : MonoBehaviour
{
    public Animator unityChan;
    public float moveSpeed =2f;
    public float rotSpeed ;
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {

        unityChan = GetComponent<Animator>();
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        unityChan.SetFloat("Horizontal", h);
        unityChan.SetFloat("Vertical", v);
        if (v > 0)
        {
        transform.Translate(0, 0, v * moveSpeed * Time.deltaTime);

        }
        else
        {
            transform.Translate(0, 0, v * moveSpeed *0.25f * Time.deltaTime);

        }


            transform.Rotate(0, h * rotSpeed * Time.deltaTime,0);

        //print("H ::::: "+h);
        //print("V ::::: "+v);

    }
}
