using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{

    public GameObject sparkEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("BULLET"))
        {
            ShowEffect(collision);
            Destroy(collision.gameObject);
        }
    }

    private void ShowEffect(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(-Vector3.forward, contact.normal);
        Instantiate(sparkEffect, contact.point, rotation);
    }
}
