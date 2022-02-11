using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelGo : MonoBehaviour
{
    public float cooltime;
    public float curltime;
    public GameObject[] enemyPrefab;
    public PlayerController playerc;
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        //enemyPrefab[0] = GameObject.Find("Level1 -");
        //InvokeRepeating("check", 0, 2.4f);
        GameObject enemy = Instantiate(enemyPrefab[Random.Range(0,enemyPrefab.Length)]) as GameObject;
        enemy.transform.position = new Vector3(-6f,0,35);
        Destroy(enemy, 15f);
        //check();
        //Invoke("check", 5f);
        playerc = GameObject.Find("Player").GetComponent<PlayerController>();
        GameObject enemy2 = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)]) as GameObject;
        enemy2.transform.position = new Vector3(-6f, 0, 58);
        Destroy(enemy2, 15f);
    }

    void check()
    {

    }
    void Update() // 매 프레임마다 실행되는 함수입니다.
    { 
        if (playerc.isHit == false)
        {

        curltime += Time.deltaTime;
        if (curltime > cooltime)
        {
                curltime = 0;
            GameObject enemy = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)]) as GameObject;
            enemy.transform.position = new Vector3(-6f, 0, 58);
            Destroy(enemy, 15f);
        }
        }
        
    }
}
