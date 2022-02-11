using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Text goldtxt;
    public Slider hpBar;
    public Slider boosterBar;
    public PlayerController playerController;
   
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        playerController =GameObject.Find("Player").GetComponent<PlayerController>();
        goldtxt = GameObject.Find("CoinText").GetComponent<Text>();
        hpBar = GameObject.Find("Hp").GetComponent<Slider>();
        boosterBar = GameObject.Find("Bosster").GetComponent<Slider>();
        SetBoosterBar();
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {

    }
    public void SetHpBar()
    {
        hpBar.value = playerController.playerHp;
    }
    public void SetBoosterBar()
    {
        boosterBar.value = playerController.boosterCnt;

    }
    public void SetCoin()
    {
        goldtxt.text = playerController.CoinCnt.ToString();

    }
}
