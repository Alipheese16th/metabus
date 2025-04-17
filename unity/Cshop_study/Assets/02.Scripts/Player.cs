using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotationSpeed = 75f;
    private float _vInput;
    private float _hInput;

    private Rigidbody _rb;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime); // Quaternion.Euler 오일러 각으로 변환
        _rb.MoveRotation(_rb.rotation * angleRot);

        _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);


    }

    // Update is called once per frame
    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * RotationSpeed;

        // this.transform.Translate(_vInput * Time.deltaTime * Vector3.forward);
        // this.transform.Rotate(_hInput * Time.deltaTime * Vector3.up);


    }
}
