using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameSpeedMgr gameSpeedMgr;
    public float enemySpeed;
    public GameObject[] effects;
    // Start is called before the first frame update
    void Start()
    {
        gameSpeedMgr = GameObject.Find("GameSpeedMgr").GetComponent<GameSpeedMgr>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<PlayerController>().isHit == false)
        {

            transform.Translate(0, 0, -gameSpeedMgr.gameSpeed * Time.deltaTime);
        
        if (transform.position.z < -7)
        {
            //Destroy(gameObject);
        }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            switch (gameObject.tag)
            {
                case "Item":
                    Destroy( Instantiate(effects[0],transform.position,transform.rotation),1f);
                    break;
                case "Booster":
                    Destroy( Instantiate(effects[1],transform.position,transform.rotation),1f);
                    break;
                case "Coin":
                    Destroy( Instantiate(effects[2],transform.position,transform.rotation),1f);
                    break;
                case "Enemy":
                    
                    if (GameObject.Find("Player").GetComponent<PlayerController>().isGod)
                    {
                        GameObject.Find("Player").GetComponent<PlayerController>().CoinCnt++;
                        GameObject.Find("UIManager").GetComponent<UIManager>().SetCoin();
                        Destroy(Instantiate(effects[4], transform.position, transform.rotation), 1f);
                    }
                    else if (GameObject.Find("Player").GetComponent<PlayerController>().nodamage)
                    {
                        GameObject.Find("Player").GetComponent<PlayerController>().CoinCnt++;
                        GameObject.Find("UIManager").GetComponent<UIManager>().SetCoin();
                        Destroy(Instantiate(effects[5], transform.position, transform.rotation), 1f);
                    }
                    else
                    {
                        Destroy(Instantiate(effects[3], transform.position, transform.rotation), 1f);
                    }
                        break;
                default:
                    break;
                        

            }
            Destroy(gameObject);
        }
    }
}
