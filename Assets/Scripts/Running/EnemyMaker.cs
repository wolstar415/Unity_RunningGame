using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float curTime;
    public float coolTime;
    public float minCoolTime;
    public float maxCoolTime;
    public int enemyCnt;
    

    void Start()
    {
        coolTime = Random.Range(minCoolTime, maxCoolTime);
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > coolTime)
        {
            
            GameObject enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.transform.position = gameObject.transform.position;
            enemy.transform.rotation = gameObject.transform.rotation;
            enemy.name = "Enemy";
            curTime = 0;
            
            RandomCoolTime();
        }
    }

    void RandomCoolTime()
    {
        coolTime = Random.Range(minCoolTime, maxCoolTime);

    }
}
