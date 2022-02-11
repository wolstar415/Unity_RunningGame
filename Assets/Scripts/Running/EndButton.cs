using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour
{
   
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        
    }
    public void StartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("02_Main");
        //Time.timeScale = 1f;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("01_Intro");
    }
}
