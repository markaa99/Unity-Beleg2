using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
     transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);   
    }
}
