    using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerTransform;
    public Vector3 offset;
    public float rotationSpeed = 1f;

    void Update()
    {
        
        Quaternion playerRotation = playerTransform.rotation;

        Vector3 offsetRotated = playerRotation * offset;

        transform.position = playerTransform.position + offsetRotated;
        
        Quaternion targetRotation = Quaternion.Slerp(transform.rotation, playerRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = targetRotation;

    }
 
}
