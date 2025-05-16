using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public ParticleSystem cartridge; // 정적 연결

    private ParticleSystem muzzleFlash;

    void Start()
    {
        muzzleFlash = firePos.GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        muzzleFlash.Play();
        Instantiate(bullet, firePos.position, firePos.rotation);
        cartridge.Play();
    }
}