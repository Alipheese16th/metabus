using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAnim
{
    // 애니메이션 컴포넌트의 애니메이션s 배열에 클립들 할당
    public AnimationClip idle;
    public AnimationClip runF;
    public AnimationClip runB;
    public AnimationClip runL;
    public AnimationClip runR;
}

public class PlayerCtrl : MonoBehaviour
{
    private float h = 0.0f;
    private float v = 0.0f;
    private Transform tr;
    public float moveSpeed = 10f;
    private Vector3 dir;
    private float r;
    public float rotationSpeed = 300f;
    public PlayerAnim playerAnim;
    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        tr = transform;
        anim = GetComponent<Animation>();
        anim.clip = playerAnim.idle;
        anim.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        // update 라이프사이클에서 객체를 계속 새로 만드는 코드를 작성하면 메모리를 계속 할당하기때문에 비효율적임.
        // new Vector3() 이런식으로 이동시키는거보다 Vector3.right 같은 정적(static) 속성을 사용하는게 훨씬 최적화가 좋다

        // 사용자 키 입력 받기기
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        // 이동벡터 계산 0 ~ 1
        dir = (Vector3.right * h) + (Vector3.forward * v);

        // 대각선 이동 속도 최대 1 제한
        dir = dir.sqrMagnitude > 1 ? dir.normalized : dir;

        // 플레이어 이동동
        tr.Translate(dir * Time.deltaTime * moveSpeed);
        //tr.position += new Vector3(h, 0, v) * moveSpeed * Time.deltaTime;

        // 플레이어 회전
        tr.Rotate(Vector3.up * r * Time.deltaTime * rotationSpeed);
        

        // 플레이어 이동간 애니메이션 변경 (CrossFade 함수 사용시 애니메이션간 자연스러운 보간 모션 적용)
        if (v > 0.1f)
        {
            anim.CrossFade(playerAnim.runF.name, 0.3f);
        }
        else if (v < -0.1f)
        {
            anim.CrossFade(playerAnim.runB.name, 0.3f);
        }
        else if (h > 0.1f)
        {
            anim.CrossFade(playerAnim.runR.name, 0.3f);
        }
        else if (h < -0.1f)
        {
            anim.CrossFade(playerAnim.runL.name, 0.3f);
        }
        else
        {
            anim.CrossFade(playerAnim.idle.name, 0.3f);
        }


    }

    private void FixedUpdate()
    {
    }


}
