using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightboard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody colliderRigidbody = other.attachedRigidbody;
        Vector3 newPosition = colliderRigidbody.position;
        newPosition.z = transform.position.z;

        colliderRigidbody.velocity = Vector3.zero;
        colliderRigidbody.position = newPosition;
        colliderRigidbody.rotation = Quaternion.LookRotation(transform.forward, colliderRigidbody.transform.up);
        colliderRigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
    }
}
