using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    private int num;
    public InputField input;
    private string intNum;

    void Start()
    {

        // TextDisplay(CheckTime());
        // TextDisplay("오늘이 화요일이냐 ? " + (DayOfWeek.Tuesday == System.DateTime.Now.DayOfWeek));
        intNum = input.GetComponent<InputField>().text;
        
    }

    void Update()
    {
        
        intNum = input.GetComponent<InputField>().text;
        if (intNum.Length > 0 && Input.GetKeyDown(KeyCode.Return)) {
            TextDisplay(intNum);
            InputNum(intNum);
        }
        
        
    }

    public void InputNum(string input) {
        int.TryParse(input, out num);
        PowerNumber(num);
    }

    void PowerNumber(int i) {
        TextDisplay("입력한 값의 제곱은 : " + (i*i).ToString() + "입니다");
    }

    public void TextDisplay(string msg) {

        Debug.Log(msg);

    }

    public void ButtonClick(string msg) {
        Debug.Log(msg);
    }










    public string CheckTime() {
        return System.DateTime.Now.Day + "일 " 
        + System.DateTime.Now.Hour + "시 " 
        + System.DateTime.Now.Minute + "분 " 
        + System.DateTime.Now.Second + "초"
        + System.DateTime.Now.DayOfWeek
        ;
    }

}
