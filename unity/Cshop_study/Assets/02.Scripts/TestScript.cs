using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        TextDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TextDisplay() {
        Debug.Log("Hello Unity");

        // Debug.Log(2000000000);
        // Debug.Log(2000000000 * 10); // 그냥 숫자로 쓰는경우 integer 32비트 값으로 처리하기때문에 20억이 넘는경우 에러남
        // Debug.Log(20000000000); // 크기가 커지면 자동으로 integer 64비트 값으로 처리
        // int32 = int
        // int64 = log

        Debug.Log('힣'- '가' + 1);

    }
}
