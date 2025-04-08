using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        TextDisplay(CheckTime());

        TextDisplay("오늘이 화요일이냐 ? " + (DayOfWeek.Tuesday == System.DateTime.Now.DayOfWeek));
        
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    string CheckTime() {
        return System.DateTime.Now.Day + "일 " 
        + System.DateTime.Now.Hour + "시 " 
        + System.DateTime.Now.Minute + "분 " 
        + System.DateTime.Now.Second + "초"
        + System.DateTime.Now.DayOfWeek
        ;
    }

    void TextDisplay(string msg) {

        Debug.Log(msg);

    }
}
