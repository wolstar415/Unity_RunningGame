using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
   
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene("02_Main");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
