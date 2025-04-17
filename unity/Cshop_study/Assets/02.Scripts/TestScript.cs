using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public GameObject inputFieldObject;
    private InputField inputField;

    // List<string> product = new List<string>();
    // List<int> numList = new List<int>();
    // List<char> first = new List<char>();
    // List<char> second = new List<char>();

    public int chance = 7;
    public int result;

    void Start()
    {
        // TextDisplay(CheckTime());
        // TextDisplay("오늘이 화요일이냐 ? " + (DayOfWeek.Tuesday == System.DateTime.Now.DayOfWeek));
        if (inputFieldObject != null)
        {
            inputField = inputFieldObject.GetComponent<InputField>();
        }

        // product.Add("apple");
        // product.Add("Carrot");
        // product.Add("potato");
        // product.Add("tomato");
        // product.Add("banana");

        // product.ForEach(x=> Debug.Log(x+" / "));

        // product.Remove("Carrot");
        // product.RemoveAt(1);

        // product.ForEach(x=> Debug.Log(x+" / "));

        // string[] sList = {"a", "b", "c"};
        // Debug.Log(sList.Length);
        // Debug.Log(sList.Count());
        // Debug.Log(product.Count);
        // Debug.Log(product.Count());

        // HanGeul();

        // numList.Add(1);
        // numList.Add(2);
        // numList.Add(3);
        // numList.Add(4);
        // numList.Add(5);
        // numList.Add(6);
        // numList.Add(7);
        // numList.Add(8);
        // numList.Add(9);

        // DisplayNumber();

        // TextDisplay(Random.Range(1f, 2f).ToString());
        // TextDisplay(Random.Range(1, 10).ToString());

        // first.Add('갑');
        // first.Add('을');
        // first.Add('병');
        // first.Add('정');
        // first.Add('무');
        // first.Add('기');
        // first.Add('경');
        // first.Add('신');
        // first.Add('임');
        // first.Add('계');

        // second.Add('자');
        // second.Add('축');
        // second.Add('인');
        // second.Add('묘');
        // second.Add('진');
        // second.Add('사');
        // second.Add('오');
        // second.Add('미');
        // second.Add('신');
        // second.Add('유');
        // second.Add('술');
        // second.Add('해');

        result = Random.Range(10, 100);



    }

    void Update()
    {

        if (inputField != null && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            string inputText = inputField.text;
            InputNum(inputText);
        }
        
    }

    void Ex2 (int num) {

        if (num > result) {
            chance--;
            TextDisplay("입력한 값("+ num +")보다 작습니다. 남은 기회 : " + chance);
        } else if (num < result) {
            chance--;
            TextDisplay("입력한 값("+ num +")보다 큽큽니다. 남은 기회 : " + chance);
        } else {
            TextDisplay("정답입니다 :" + result);
        }

        if (chance == 0) {
            TextDisplay("실패입니다 정답은 :" + result);
        }

    }
    public void InputNum(string input) {
        bool tmp = int.TryParse(input, out int num);
        if (tmp) {
            Ex2(num);
        } else {
            TextDisplay("숫자를 입력하세요");
        }
    }




    // void Ganzi(int num) {
    //     int tmp = num - 4;

    //     if (tmp < 0) {
    //         Debug.Log(first[tmp%10 + 10]);
    //         Debug.Log(second[tmp%12 + 12]);
    //     } else {
    //         Debug.Log(first[tmp%10]);
    //         Debug.Log(second[tmp%12]);
    //     }
        
    // }

    // void DisplayNumber() {
    //     for (int i = 0; i < numList.Count; i++)
    //     {
    //         if (numList[i]%3==0) {
    //         numList.RemoveAt(i--);
    //         }
    //         TextDisplay(numList[i] + " / ");
    //     }
    // }

    // void HanGeul () {
    //     int count = 0;
    //     for (int i = '가'; i <='힣'; i++)
    //     {
    //         Debug.Log((char)i + " / " + i);
    //         count++;
    //     }
    //     Debug.Log(count);
        
    // }

    // void PowerNumber(int i) {
    //     if (i > 0) {
    //         TextDisplay("입력한 값의 팩토리얼은 : " + Factorial(i).ToString() + "입니다");
    //     } else {
    //         TextDisplay("1 이상을 입력하세요 ");
    //     }
    // }

    // public int Factorial (int num) {
    //     if (num > 1) {
    //         return num * Factorial(num-1);
    //     } else {
    //         return 1;
    //     }
    // }

    public void TextDisplay(string msg) {

        Debug.Log(msg);

    }

    // public void ButtonClick(string msg) {
    //     Debug.Log(msg);
    // }



    public string CheckTime() {
        return System.DateTime.Now.Day + "일 " 
        + System.DateTime.Now.Hour + "시 " 
        + System.DateTime.Now.Minute + "분 " 
        + System.DateTime.Now.Second + "초"
        + System.DateTime.Now.DayOfWeek
        ;
    }

}
