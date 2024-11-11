using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;


    // Update is called once per frame
    void Update()
    {
        bool isRunning = false;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        if (isRunning)
        {
            moveSpeed = 15f;
            
        }
        else moveSpeed = 5f;

        float moveDirection = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * moveDirection * moveSpeed * Time.deltaTime;
        transform.position += move;

        float strafeDirection = Input.GetAxis("Horizontal");
        Vector3 strafe = transform.right * strafeDirection * moveSpeed * Time.deltaTime;
        transform.position += strafe;

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime , 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }
}
