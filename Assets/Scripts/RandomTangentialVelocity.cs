using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomTangentialVelocity : MonoBehaviour
{
    public float minTangentialSpeed = 5f;
    public float maxTangentialSpeed = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        // Get the contact point from the collision
        ContactPoint contact = collision.contacts[0];

        // Calculate the direction from the contact point to the object's center
        Vector3 tangentDirection = transform.position - contact.point;
        tangentDirection.Normalize();

        // Calculate a random tangential speed between minTangentialSpeed and maxTangentialSpeed
        float tangentialSpeed = Random.Range(minTangentialSpeed, maxTangentialSpeed);

        // Calculate the tangential velocity vector
        Vector3 tangentialVelocity = Vector3.Cross(contact.normal, tangentDirection) * tangentialSpeed;

        // Apply the tangential velocity to the object's rigidbody (if it has one)
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity += tangentialVelocity;
        }
    }
}
