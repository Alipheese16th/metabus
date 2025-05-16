using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public float damage = 20f;
    public float speed = 1000f;


    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }
}
