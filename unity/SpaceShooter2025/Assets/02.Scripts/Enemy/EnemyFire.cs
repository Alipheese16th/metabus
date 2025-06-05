using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public bool isFire = false;
    public AudioClip fireSfx;
    public AudioClip reloadSfx;

    private AudioSource _audio;
    private Animator _anim;
    private Transform playerTr;
    private Transform enemyTr;
    private readonly int hashFire = Animator.StringToHash("fire");
    private readonly int hashReload = Animator.StringToHash("reload");
    private float nextFireTime = 0f;
    private readonly float fireRate = 0.1f;
    private readonly float damping = 10f;
    private readonly float reloadTime = 1f;
    private readonly int maxBullet = 10;
    private int currBullet = 10;
    private bool isReload;
    private WaitForSeconds wsReload;
    public GameObject bullet;
    public Transform firePos;

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
        enemyTr = transform;
        _anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        wsReload = new WaitForSeconds(reloadTime);

    }

    // Update is called once per frame
    void Update()
    {
        if (!isReload && isFire)
        {
            Quaternion rot = Quaternion.LookRotation(playerTr.position - enemyTr.position);
            enemyTr.rotation = Quaternion.Slerp(enemyTr.rotation, rot, Time.deltaTime * damping);

            if (Time.time >= nextFireTime)
            {
                Fire();
                nextFireTime = Time.time + fireRate + Random.Range(0f, 0.3f);
            }
        }
    }

    void Fire()
    {
        _anim.SetTrigger(hashFire);
        _audio.PlayOneShot(fireSfx, 1.0f);

        GameObject _bullet = Instantiate(bullet, firePos.position, firePos.rotation);
        Destroy(_bullet, 3.0f);

        //if (--currBullet == 0) { isReload = true; }
        isReload = --currBullet == 0;
        if (isReload)
        {
            StartCoroutine(Reloading());
        }
    }

    IEnumerator Reloading()
    {
        _anim.SetTrigger(hashReload);
        yield return wsReload;

        _audio.PlayOneShot(reloadSfx, 1.0f);
        yield return wsReload;

        currBullet = maxBullet;
        isReload = false;
    }
}
