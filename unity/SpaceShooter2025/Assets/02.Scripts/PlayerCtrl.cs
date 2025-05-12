using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float h = 0.0f;
    private float v = 0.0f;
    private Transform tr;
    public float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        tr = transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        tr.Translate(h * moveSpeed * Time.deltaTime, 0, v * moveSpeed * Time.deltaTime);
        

        //tr.position += new Vector3(h, 0, v) * moveSpeed;

    }


}
