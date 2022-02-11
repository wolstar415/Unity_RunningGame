using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public GameObject Player;
    public float MoveSpeed;
   
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        Player = gameObject;
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        if (Input.GetKey(KeyCode.LeftArrow) && Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack") == false && Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack 1") == false && Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack 0") == false)
        {
            Player.transform.localEulerAngles = new Vector3(0, 180, 0);
            Player.transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
            
            Player.GetComponent<Animator>().SetBool("Run", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack") == false && Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack 1") == false && Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack 0") == false)
        {
            Player.transform.localEulerAngles = new Vector3(0, 0, 0);
            Player.transform.Translate(+MoveSpeed * Time.deltaTime, 0, 0);
           // Player.transform.localEulerAngles = new Vector3(0, 0, 0);
            Player.GetComponent<Animator>().SetBool("Run", true);
        }
        
        else
        {
            Player.GetComponent<Animator>().SetBool("Run", false);
        }
        if (Input.GetKey(KeyCode.Space) && Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack") == false && Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack 1") == false && Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack 0") == false )
        {
            Player.GetComponent<Animator>().SetBool("Attack", true);
        }
        else
        {
            Player.GetComponent<Animator>().SetBool("Attack", false);
        }
    }
}
