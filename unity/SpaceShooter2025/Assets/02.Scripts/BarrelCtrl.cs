using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    public GameObject expEffect;
    public Mesh[] meshes;
    public Texture[] textures;
    public GameObject fireEffect;
    public GameObject smokeEffect;
    public Transform firePivot;

    public float darknessAmount = 0.3f;
    private int hitCount = 0;
    private Rigidbody rb;
    private MeshFilter mf;
    private MeshRenderer mr;
    private float expRadius = 10f;
    private bool expChk = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mf = GetComponent<MeshFilter>();
        mr = GetComponent<MeshRenderer>();

        // 마지막 텍스쳐 제외하고 랜덤 텍스쳐 적용
        mr.material.mainTexture = textures[Random.Range(0, textures.Length - 1)];

    }
    private void OnCollisionEnter(Collision collision)
    {
        // 총알 맞았을경우
        if (collision.collider.CompareTag("BULLET"))
        {
            if (++hitCount == 1)
            {
                // 연기 이펙트 생성
                GameObject smoke = Instantiate(smokeEffect, firePivot.position, Quaternion.identity);
                smoke.transform.parent = firePivot;
            }
            if (hitCount == 2) {
                // 불 이펙트 생성
                GameObject fire = Instantiate(fireEffect, firePivot.position, Quaternion.identity);
                fire.transform.parent = firePivot;
            }
            else if (hitCount == 3) {
                // 3초뒤 폭발
                Invoke("ExpBarrel", 3f);
            }
            else if (hitCount == 5)
            {
                // 즉시 폭발
                ExpBarrel();
            }
        }
    }

    public void ExpBarrel()
    {
        // 이미 폭발한 경우 진입금지
        if (expChk) return;

        expChk = true;

        // 자식 객체들 (연기, 불 이펙트) 일정시간 후 삭제. 단 0번 인덱스는 자식이 아니라 본인 객체이므로 제외
       Transform[] effects = GetComponentsInChildren<Transform>();
        for (int i = 1; i < effects.Length; i++)
        {

            Destroy(effects[i].gameObject, 10f);
        }

        // 폭발 이펙트 생성
        Instantiate(expEffect, transform.position, Quaternion.identity);

        //// 무게 가볍게하고 위로 날리기
        //rb.mass = 1f;
        //rb.AddForce(Vector3.up * 1000.0f);

        // 폭발 연산
        IndirectDamage(transform.position);

        // 모양 바꾸기
        ChangeShape();

        // 색상 바꾸기
        //ChangeColor();


    }

    private void IndirectDamage(Vector3 pos)
    {
        // 8번 layer만 주변 범위로 탐색 collider 객체 배열 획득
        Collider[] colls = Physics.OverlapSphere(pos, expRadius, 1 << 8);
        foreach (var item in colls)
        {
            // 폭발 영역에 있는 객체들 연산
            var _rb = item.GetComponent<Rigidbody>();
            _rb.mass = 1.0f;
            // 날려버리기 (파워, 폭발중심점, 반지름, 수직파워)
            _rb.AddExplosionForce(1200f, pos, expRadius, 1000f);

            BarrelCtrl barrelCtrl = item.GetComponent<BarrelCtrl>();
            if (!barrelCtrl.expChk)
            barrelCtrl.ExpBarrelChild();
        }

    }

    private void ExpBarrelChild ()
    {
        // 연기 이펙트 생성
        GameObject smoke = Instantiate(smokeEffect, firePivot.position, Quaternion.identity);
        smoke.transform.parent = firePivot;
        // 불 이펙트 생성
        GameObject fire = Instantiate(fireEffect, firePivot.position, Quaternion.identity);
        fire.transform.parent = firePivot;

        // 난수 생성후 3~9초 후 폭발
        int countDown = Random.Range(3, 10);
        // 3초뒤 폭발
        Invoke("ExpBarrel", countDown);

    }
    private void ChangeShape()
    {
        // 매쉬 갯수만큼 난수 생성
        int idx = Random.Range(0, meshes.Length);

        // 부셔진 매쉬형태로 변경
        mf.sharedMesh = meshes[idx];

        // 마지막 텍스쳐(용암) 으로 변경
        mr.material.mainTexture = textures[textures.Length - 1];
    }

    private void ChangeColor()
    {
        //// 원래 색상 가져오기
        //Color originalColor = mr.material.color;
        //// 어둡게 만든 색상
        //Color darkenedColor = originalColor * darknessAmount;
        //// 적용
        //mr.material.color = darkenedColor;
    }
}
