using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRolling : MonoBehaviour
{
    GameObject asdasd;

    public Vector3 originPos;
    public float speed;
    public float limitZ;
    public GameSpeedMgr gameSpeedMgr;
    // Start is called before the first frame update
    void Start()
    {
    gameSpeedMgr = GameObject.Find("GameSpeedMgr").GetComponent<GameSpeedMgr>();


        

        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameSpeedMgr.isPause == false)
        {

        transform.Translate(0, 0, -speed * Time.deltaTime);
        if (transform.position.z < -limitZ)
        {
            transform.position = originPos;
        }
        }
    }
}
