using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMaker : MonoBehaviour
{
    public GameObject boosterPrefab;
    public GameObject coinPrefab;
    public GameObject itemPrefab;
    public GameObject[] itemsPrefab;

    public float curTime;
    public float coolTime;
    public int boosterPer; // 부스터 나올 확률
    public Transform[] itemPos;
    public GameSpeedMgr gameSpeedMgr;
    void Start()
    {
        gameSpeedMgr = GameObject.Find("GameSpeedMgr").GetComponent<GameSpeedMgr>();
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > coolTime)
        {
            RandomPosiotion();
            int itemRnd = Random.Range(0, 100);
            if (itemRnd < boosterPer)
            {
                GameObject booster = Instantiate(boosterPrefab) as GameObject;
                booster.name = "Booster";
                booster.transform.position = gameObject.transform.position;
                booster.transform.rotation = gameObject.transform.rotation;
            }
            else
            {
                int rndItem = Random.Range(0, 100);
                if (rndItem > 10)
                {
                    GameObject coin = Instantiate(coinPrefab) as GameObject;
                    coin.name = "Coin";
                    coin.transform.position = gameObject.transform.position;
                    coin.transform.rotation = gameObject.transform.rotation;
                }
                else
                {
                    GameObject item = Instantiate(itemPrefab) as GameObject;
                    item.name = "Item";
                    item.transform.position = gameObject.transform.position;
                    item.transform.rotation = gameObject.transform.rotation;
                }
            }
            curTime = 0;

        }

        

    }
    void RandomPosiotion()
    {
        int rnd = Random.Range(0, itemPos.Length);
        transform.position = itemPos[rnd].position;
    }
}
