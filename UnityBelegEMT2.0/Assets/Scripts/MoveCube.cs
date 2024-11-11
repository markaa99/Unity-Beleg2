using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private bool moveForward;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        
    }
    
    // Update is called once per frame
    void Update()
    {

        //Vector3 newPosition = transform.position;
        //newPosition.z += speed * Time.deltaTime;

        //transform.position = newPosition;
        if(transform.position.z <= 0)
        {
            moveForward = true;
        }
        else if(transform.position.z >= 10) 
        { 
            moveForward = false;
        }
        if(moveForward)
        {
            transform.position += new Vector3(0, 0, 1) * (Time.deltaTime * speed);
            //transform.rotation = Quaternion.Euler(new Vector3(0, 0, 1) * Time.deltaTime * speed);
        }
        else if(moveForward)
        {
            transform.position += new Vector3(0, 0, -1) * (Time.deltaTime * speed);
        }
     
    }
    void walk()
    {
        //OnKeyboardInput keyboardInput = true
        transform.position += new Vector3(0, 0, 1) * Time.deltaTime;
    }
   /* public void OnCollisionEnter(Collision other)
    {
        moveForward = !moveForward;
    }
*/
}
