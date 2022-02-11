using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotSpeed = 120f;
    public Animator UnityChanAnim;
    public Transform unityChan;
    public GameObject asd;
    
    // Start is called before the first frame update
    void Start()
    {
        UnityChanAnim = GetComponentInChildren<Animator>();
        //unityChan = GetComponentInChildren<Transform>();
        unityChan = transform.GetChild(0).transform;
        asd = GameObject.Find("unitychan");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityChanAnim.GetCurrentAnimatorStateInfo(0).IsName("Sliding"))
        {
            transform.Translate(0, 0, +moveSpeed * Time.deltaTime * 1.2f);

            
            unityChan.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) && UnityChanAnim.GetCurrentAnimatorStateInfo(0).IsName("Sliding") == false)
        {
            transform.Translate(0, 0, -moveSpeed * Time.deltaTime * 0.25f);
            UnityChanAnim.SetBool("Back", true);
           // asd.transform.localEulerAngles = new Vector3(0, 270, 0);
            //GameObject.Find("unitychan").transform.localEulerAngles = new Vector3(0, 270, 0);
            
            //unityChan.localEulerAngles = new Vector3(0, 180, 0);

        }
        else if (Input.GetKey(KeyCode.UpArrow) && UnityChanAnim.GetCurrentAnimatorStateInfo(0).IsName("Sliding") == false)
        { 

            transform.Translate(0, 0, +moveSpeed * Time.deltaTime);
            
            UnityChanAnim.SetBool("Run", true);
            unityChan.localEulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            UnityChanAnim.SetBool("Run", false);
            UnityChanAnim.SetBool("Back", false);
            unityChan.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && UnityChanAnim.GetCurrentAnimatorStateInfo(0).IsName("Sliding") == false )
        {
            UnityChanAnim.SetTrigger("Refresh");
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -rotSpeed * Time.deltaTime, 0);


        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, +rotSpeed * Time.deltaTime, 0);

        }
    }
}
