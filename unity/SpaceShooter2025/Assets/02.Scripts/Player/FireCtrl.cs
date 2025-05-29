using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public ParticleSystem cartridge; // 장전 이펙트 정적 연결
    private ParticleSystem muzzleFlash; // 발사 이펙트
    public float fireDelay = 0.1f; // 초당 10발 (1초 / 10 = 0.1초)
    private float nextFireTime = 0f;

    [System.Serializable]
    public struct PlayerSFX
    {
        public AudioClip[] fire;
        public AudioClip[] reload;
    }
    public PlayerSFX playerSFX;
    private AudioSource _audio;

    public enum WeaponType
    {
        RIFLE, SHOTGUN
    }
    public WeaponType currWeapon = WeaponType.RIFLE;

    void Start()
    {
        muzzleFlash = firePos.GetComponentInChildren<ParticleSystem>();
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 마우스 좌클릭 입력 시 발사 함수 호출
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireDelay;
        }
    }

    private void Fire()
    {
        // 발사 이펙트 생성
        muzzleFlash.Play();

        // 총알 생성
        Instantiate(bullet, firePos.position, firePos.rotation);

        // 장전 이펙트 생성
        cartridge.Play();

        FireSFX();
    }

    private void FireSFX()
    {
        var _sfx = playerSFX.fire[(int)currWeapon];
        _audio.PlayOneShot(_sfx, 1f);
    }

}