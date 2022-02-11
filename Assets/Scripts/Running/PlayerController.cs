using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum JUMPSTATE
    {
        IDLE = 0,
        JUMP,   
        ARIWALK,
        DOWN,
        SLIDE,
        JUMPMORE,
        HIT,
        END
    }
    public float shakeTime;
    public Vector3 cameraOrigin;
    public Transform CameraPos;
    public JUMPSTATE jumpState;
    private Rigidbody rBody;


    public bool nodamage = false;
    public float jumpUSpeed = 10f;
    public float jumpDspeed = 13f;
    public float jumpLimit = 3f;

    public int jumpCnt = 0;
    public int jumpCntMax = 2;

    public int playerHp = 5;
    public int playerMaxHp = 5;
    public int itemCnt = 0;
    public int CoinCnt = 0;

    public int boosterCnt = 0;
    public int boosterMaxCnt = 10;
    public float boosterCurTime = 0;
    public float boosterCoolTime = 5;

    public bool isJump = false;
    public bool isSlide = false;

    public bool isBooster = false;
    public bool isGod = false; 
    public bool isDead = false;
    public bool isHit = false;
    public float hitCurTime = 0;
    public bool checksliding=false;

    public Animator unitChanAnim;

    public float AirWalkCoolTime;
    float AirWalkCurTime;
    float LimitCheck;
    public GameSpeedMgr gameSpeedMgr;
    public bool clickjump;

    public bool checkjump;

    public GameObject EndUI;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        //GameObject.Find("UIManager").GetComponent<UIManager>().SetHpBar();
        //GameObject.Find("UIManager").GetComponent<UIManager>().SetCoin();
        //
        jumpState = 0;
        unitChanAnim = GetComponentInChildren<Animator>();
        rBody = GetComponent<Rigidbody>();
        LimitCheck = jumpLimit;
        gameSpeedMgr = GameObject.Find("GameSpeedMgr").GetComponent<GameSpeedMgr>();
        //
        //GameObject.Find("UIManager").GetComponent<UIManager>().SetBoosterBar();
        cameraOrigin = GameObject.Find("Main Camera").transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JUMP();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Sliding_Down();
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Sliding_Up();

        }
        
        if (checkjump)
        {
            checkjump=false;
            if (jumpState == JUMPSTATE.HIT)
            {
                return;
            }
            else if (jumpState == JUMPSTATE.IDLE)
            {

                jumpState = JUMPSTATE.JUMP;
                jumpCnt++;
            }
            else if (jumpCnt < jumpCntMax && jumpCnt >= 1)
            {

                jumpLimit += transform.position.y;
                jumpCnt++;
                jumpState = JUMPSTATE.JUMPMORE;
            }
        }

        /* if (Input.GetKeyDown(KeyCode.Space) && jumpCnt < jumpCntMax && jumpCnt >= 1 && jumpState !=JUMPSTATE.HIT)
         {
             //JUMP();
             jumpLimit += transform.position.y;
             jumpCnt++;
             jumpState = JUMPSTATE.JUMPMORE;
         }*/
        switch (jumpState)
        {
            case JUMPSTATE.IDLE:
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                jumpCnt = 0;
                jumpLimit = LimitCheck;
                /*if (Input.GetKeyDown(KeyCode.Space))
                {
                    //JUMP();
                    jumpState = JUMPSTATE.JUMP;
                    jumpCnt++;
                }
                */
                if (checksliding)
                {
                jumpState = JUMPSTATE.SLIDE;
                }
                break;
            case JUMPSTATE.JUMP:
                transform.Translate(0, jumpUSpeed * Time.deltaTime, 0);

                if (transform.position.y > jumpLimit)
                {
                    jumpState = JUMPSTATE.ARIWALK;
                }
                break;
            case JUMPSTATE.ARIWALK:
                AirWalkCurTime += Time.deltaTime;
                if (AirWalkCurTime > AirWalkCoolTime)
                {
                    jumpState = JUMPSTATE.DOWN;
                    AirWalkCurTime = 0;
                }
                break;
            case JUMPSTATE.DOWN:
                transform.Translate(0, -jumpDspeed * Time.deltaTime, 0);
                if (transform.position.y < 0)
                {

                    jumpState = JUMPSTATE.IDLE;
                }
                break;
            case JUMPSTATE.JUMPMORE:
                transform.Translate(0, jumpUSpeed * Time.deltaTime, 0);

                if (transform.position.y > jumpLimit)
                {
                    jumpState = JUMPSTATE.ARIWALK;
                }

                break;
            case JUMPSTATE.SLIDE:
                if (checksliding == false)
                {
                    GetComponent<BoxCollider>().size = new Vector3(GetComponent<BoxCollider>().size.x, 0.8f, GetComponent<BoxCollider>().size.z);
                    GetComponent<BoxCollider>().center = new Vector3(GetComponent<BoxCollider>().center.x, 0, GetComponent<BoxCollider>().center.z);
                    isSlide = false;
                    jumpState = JUMPSTATE.IDLE;
                }
                else
                {
                    isSlide = true;
                    GetComponent<BoxCollider>().size = new Vector3(GetComponent<BoxCollider>().size.x, 0.4f, GetComponent<BoxCollider>().size.z);
                    GetComponent<BoxCollider>().center = new Vector3(GetComponent<BoxCollider>().center.x, -0.2f, GetComponent<BoxCollider>().center.z);
                    
                }
                    break;
            case JUMPSTATE.HIT:
                
    isHit = true;
                hitCurTime += Time.deltaTime;
                AnimatorClipInfo[] m_CurrentClipInfo;
                m_CurrentClipInfo = unitChanAnim.GetCurrentAnimatorClipInfo(0);
                transform.position = new Vector3(transform.position.x,0,transform.position.z);
                float randPosX = Random.Range(CameraPos.position.x - 0.1f, CameraPos.position.x + 0.1f);
                CameraPos.position = new Vector3(randPosX, CameraPos.position.y, CameraPos.position.z);
                shakeTime += Time.deltaTime;
                if (shakeTime > 1f)
                {
                    
                    CameraPos.position = cameraOrigin;
                }

                if (isDead == true && hitCurTime > 1f)
                {
                    EndUI.SetActive(true);
                    CameraPos.position = cameraOrigin;
                    //Time.timeScale = 0f;
                    shakeTime = 0f;
                    jumpState = JUMPSTATE.END;
                    break;
                }

                if (hitCurTime > m_CurrentClipInfo[0].clip.length)
                {
                    shakeTime = 0f;
                    gameSpeedMgr.isPause = false;
                    gameSpeedMgr.gameSpeed = 8f;
                    isHit = false;
                    hitCurTime = 0;
                    jumpState=JUMPSTATE.IDLE;
                    nodamage1(0.5f);
                }
                    break;
            default:
                break;
        }
        unitChanAnim.SetInteger("PlayerState", (int)jumpState);
        if (isBooster)
        {
            isGod = true;
            Time.timeScale = 3f;
            boosterCurTime += Time.deltaTime;
            if (boosterCurTime > boosterCoolTime)
            {
                Time.timeScale = 1f;
                isBooster = false;
                boosterCnt = 0;
                boosterCurTime = 0;
                isGod = false;
                GameObject.Find("UIManager").GetComponent<UIManager>().SetBoosterBar();
                nodamage1(0.8f);
            }
        }

    }
    public void Sliding_Down()
    {
        checksliding = true;

    }
    public void Sliding_Up()
    {
        checksliding = false;
    }
    public void JUMP()
    {
        checkjump = true;
        
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && isGod == false && jumpState != JUMPSTATE.HIT && nodamage == false)
        {
            gameSpeedMgr.isPause = true;
            gameSpeedMgr.gameSpeed = 0f;
            Destroy(other.gameObject);
            playerHp--;
            GameObject.Find("UIManager").GetComponent<UIManager>().SetHpBar();
            jumpState = JUMPSTATE.HIT;
            if (playerHp <= 0)
            {
                isDead = true;
                
            }
        }
        if (other.tag == "Coin")
        {
            CoinCnt++;
            GameObject.Find("UIManager").GetComponent<UIManager>().SetCoin();
            //print("Coin");
            //Destroy(other.gameObject);

        }
        if (other.tag == "Booster")
        {
            boosterCnt++;
            GameObject.Find("UIManager").GetComponent<UIManager>().SetBoosterBar();
            
            if (boosterCnt >= boosterMaxCnt)
            {
                isBooster = true;
            }
            //print("Booster");
            //Destroy(other.gameObject);

        }
        if (other.tag == "Item")
        {

            itemCnt++;
            playerHp++;
            GameObject.Find("UIManager").GetComponent<UIManager>().SetHpBar();
            if (playerHp > playerMaxHp)
            {
                playerHp = playerMaxHp;
            }
            //print("Item");
           // Destroy(other.gameObject);

        }
    }
    void nodamage1(float a)
    {
        nodamage = true;
        Invoke("nodamage2", a);
    }
    void nodamage2()
    {
        nodamage = false;
    }
}
