using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject Battery;

    public float spawnRate = 2f;

    public bool isSpawning = true;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Battery", 0f, spawnRate);
        
    }

    void SpawnObject()
    {
        if(isSpawning)
        {
            Instantiate(Battery, transform.position, transform.rotation);

        }
    }

    public void OnParticleSystemStopped()
    {
        isSpawning = false;
        CancelInvoke("Battery");
    }
    // Update is called once per frame
    public void StartSpawning()
    {
        isSpawning=true;
        InvokeRepeating("Battery", 0f, spawnRate);
    }
    void Update()
    {
        
    }
}
