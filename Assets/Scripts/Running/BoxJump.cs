using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxJump : MonoBehaviour
{
    public enum JUMPSTATE
    {
        IDLE = 0,
        JUMP,
        AIRWALK,
        DoubleJUMP,
        KeyDown,
        Sliding,
        DOWN

    }
    public JUMPSTATE jumpState;
    public float jumpUSpeed;
    public float jumpDSpeed;
    public float jumpMinY;
    public float jumpLimit;
    public float jumpDoubleLimit;
    public float curTime;
    public float coolTime;
    public float nowposition;
    
    public int jumpCnt;
    public int jumpCntMax;

    bool gamestart = false;


    public Animator UnityChanAnim;

    void Start()
    {
        //UnityChanAnim = GameObject.Find("unitychan").GetComponent<Animator>();
        UnityChanAnim = GetComponentInChildren<Animator>();
        

        jumpCnt = 0;

    }

    void Update()


    {


        if (gamestart)
        {
            if (Input.GetKeyDown(KeyCode.Space) && jumpCnt < jumpCntMax)
            {
                jumpCnt++;
                nowposition = transform.position.y;
                jumpDoubleLimit = transform.position.y + jumpLimit;

                jumpState = JUMPSTATE.DoubleJUMP;

            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && jumpCnt >= 1)
            {

                jumpState = JUMPSTATE.KeyDown;

            }
            if (Input.GetKeyUp(KeyCode.DownArrow) && jumpCnt >= 1)
            {

                jumpState = JUMPSTATE.DOWN;

            }
            if (Input.GetKey(KeyCode.LeftControl) && jumpState == JUMPSTATE.IDLE)
            {
                // gameObject.transform.position = new Vector3(transform.position.x, -0.5f, transform.position.z);
                jumpState = JUMPSTATE.Sliding;
                
            }
            if (Input.GetKeyUp(KeyCode.LeftControl) && jumpState == JUMPSTATE.Sliding)
            {
                //gameObject.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                jumpState = JUMPSTATE.IDLE;

            }

            switch (jumpState)
            {
                case JUMPSTATE.IDLE:


                    UnityChanAnim.SetInteger("PlayerState", 0);

                    if (Input.GetKey(KeyCode.Space))
                    {
                        jumpState = JUMPSTATE.JUMP;
                        jumpCnt++;
                       
                    }
                    break;
                case JUMPSTATE.JUMP:
                    UnityChanAnim.SetInteger("PlayerState", 1);

                    if (transform.position.y < jumpMinY)
                    {

                        transform.Translate(0, jumpUSpeed * Time.deltaTime, 0);
                        break;
                    }
                    transform.Translate(0, jumpUSpeed * Time.deltaTime, 0);
                    if (!Input.GetKey(KeyCode.Space))
                    {


                        jumpState = JUMPSTATE.AIRWALK;

                        break;
                    }

                    if (transform.position.y > jumpLimit)
                    {
                        jumpState = JUMPSTATE.AIRWALK;

                    }


                    break;
                case JUMPSTATE.DoubleJUMP:
                    UnityChanAnim.SetInteger("PlayerState", 1);

                    if (transform.position.y < nowposition + jumpMinY)
                    {

                        transform.Translate(0, jumpUSpeed * Time.deltaTime, 0);
                        break;
                    }
                    transform.Translate(0, jumpUSpeed * Time.deltaTime, 0);
                    if (!Input.GetKey(KeyCode.Space))
                    {


                        jumpState = JUMPSTATE.AIRWALK;

                        break;
                    }


                    if (transform.position.y > jumpDoubleLimit)
                    {
                        jumpState = JUMPSTATE.AIRWALK;

                    }
                    break;

                case JUMPSTATE.AIRWALK:
                    UnityChanAnim.SetInteger("PlayerState", 1);
   
                    curTime += Time.deltaTime;
                    if (curTime > coolTime)
                    {
                        jumpState = JUMPSTATE.DOWN;
                        curTime = 0;
                    }
                    break;
                case JUMPSTATE.DOWN:
                    UnityChanAnim.SetInteger("PlayerState", 1);

                    transform.Translate(0, -jumpDSpeed * Time.deltaTime, 0);
                    if (transform.position.y < 0)
                    {

                        jumpState = JUMPSTATE.IDLE;
                        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                        jumpCnt = 0;
                    }

                    break;
                case JUMPSTATE.KeyDown:

                    transform.Translate(0, -jumpDSpeed * Time.deltaTime * 1.75f, 0);
                    if (transform.position.y < 0)
                    {

                        jumpState = JUMPSTATE.IDLE;
                        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                        jumpCnt = 0;
                    }
                    break;
                case JUMPSTATE.Sliding:
                    UnityChanAnim.SetInteger("PlayerState", 2);
                    break;
                default:
                    break;
            }
        }
        else
        {
            if (transform.position.z < 1)
            {
                gameObject.transform.Translate(0, 0, Time.deltaTime * 2f);
                return;
            }
            
                gamestart = true;
                gameObject.transform.position = new Vector3(0, 0, 1);
            
        }

        


    }

    
}
