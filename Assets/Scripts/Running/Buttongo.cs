using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttongo : MonoBehaviour
{
    public BoxJump Ch;
    public Slider Sliderz;
    // Start is called before the first frame update
    void Start()
    {

        Sliderz = GameObject.Find("Slider").GetComponent<Slider>();
        Ch = GameObject.Find("Player").GetComponent<BoxJump>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Sliderz.value = Sliderz.value - 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Sliderz.value = Sliderz.value + 1;
        }
    }

    // Update is called once per frame
    public void Slidercheck()
    {
        Ch.jumpCntMax= (int)Sliderz.value;
    }
    public void Buttonup()
    {
        Ch.jumpCntMax++;
    }
    public void Buttondown()
    {
        Ch.jumpCntMax--;
        if (Ch.jumpCntMax <= 1)
        {
            Ch.jumpCntMax = 1;
        }
    }
}
