using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float moveDamping = 15f;
    public float rotDamping = 10f;
    public float distance = 3f;
    public float height = 2.5f;
    public float targetOffset = 2.0f;
    //public float smoothTime = 0.2f;
    //private Vector3 velocity = Vector3.zero;

    void Start()
    {
    }

    void LateUpdate()
    {
        var camPos = target.position - (target.forward * distance) + (target.up * height); // 카메라 위치값 구함
        transform.position = Vector3.Slerp(transform.position, camPos, Time.deltaTime * moveDamping); // 카메라 이동
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime * rotDamping); // 카메라 회전
        //transform.position = Vector3.SmoothDamp(
        //    transform.position,      // 현재 위치
        //    camPos,         // 목표 위치
        //    ref velocity,            // 현재 속도 (반드시 ref)
        //    smoothTime               // 감속 시간
        //);
        transform.LookAt(target.position + (target.up * targetOffset)); // 카메라 보는 방향 각도 조절

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(target.position + (target.up * targetOffset), 0.1f);
        Gizmos.DrawLine(transform.position, target.position + (target.up * targetOffset));
    }

}
