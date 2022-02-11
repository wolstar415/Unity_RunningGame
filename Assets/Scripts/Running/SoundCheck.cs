using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCheck : MonoBehaviour
{
    public AudioSource BGM;
    public GameObject BGMIcon;
    public GameObject BGMIcon2;
    public bool BGMBool;

    public void BGMCheck()
    {
        
    if (BGMBool == true)
        {
            AudioListener.volume = 0;
            BGMBool = false;
            BGMIcon.SetActive(true);
            BGMIcon2.SetActive(false);
            //BGM.mute = false;
        }
        else
        {
            AudioListener.volume = 1;
            BGMBool = true;
            BGMIcon.SetActive(false);
            BGMIcon2.SetActive(true);
            //BGM.mute = true;
        }
    }

    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        if (AudioListener.volume == 0)
        {
            BGMBool = false;
            BGMIcon.SetActive(true);
            BGMIcon2.SetActive(false);
            //BGM.mute = false;
        }
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        
    }
}
