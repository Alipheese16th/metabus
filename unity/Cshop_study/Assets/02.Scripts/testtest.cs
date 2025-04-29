using System.Collections.Generic;
using UnityEngine;

public class testtest : MonoBehaviour
{

    public delegate void TestDelegateA(); // 델리게이트를 명시할때 리턴타입과 파라미터를 미리 정해둔다
    public delegate int TestDelegateB(int n); 

    void Start()
    {

        TestDelegateA dele1, dele11, dele111; // 얜 void 함수이고 파라미터가 없는 경우의 함수만 저장이 가능함
        TestDelegateB dele2; 

        dele1 = testFunctionA;
        dele11 = testFunctionC;
        dele111 = dele1 + dele11; // 순선대로 실행됨
        dele2 = testFunctionB;

        dele111 -= dele11; // 빼면 그 함수는 실행안됨
        dele111 -= dele11;
        
        dele111();


        
    }


    void testFunctionA() {
        Debug.Log("Test Delegate A !!");
    }
    
    int testFunctionB(int n) {
        return n * n;
    }

    void testFunctionC() {
        Debug.Log("Hello Unity !!");
    }

}
