using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanFighting : MonoBehaviour
{
    AnimatorClipInfo[] m_CurrentClipInfo;
    public Animator fightingAnim;
    public bool isSliding = false;
    public bool isJumming = false;
    public float coolTime;
    public float coolTime2;
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        fightingAnim = gameObject.GetComponent<Animator>();
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && isSliding == false)
        {
            isSliding = true;
            fightingAnim.SetBool("Sliding", isSliding);
        }
        if (isSliding)
        {
            m_CurrentClipInfo = fightingAnim.GetCurrentAnimatorClipInfo(0);
            coolTime += Time.deltaTime;
            if (coolTime > m_CurrentClipInfo[0].clip.length)
            {
                coolTime = 0;
                isSliding = false;
                fightingAnim.SetBool("Sliding", isSliding);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && isJumming == false)
        {
            isJumming = true;
            fightingAnim.SetBool("Jump", isJumming);
        }
        if (isJumming)
        {
            m_CurrentClipInfo = fightingAnim.GetCurrentAnimatorClipInfo(0);
            coolTime2 += Time.deltaTime;
            if (coolTime2 > m_CurrentClipInfo[0].clip.length)
            {
                coolTime2 = 0;
                isJumming = false;
                fightingAnim.SetBool("Jump", isJumming);
            }
        }

    }
}
