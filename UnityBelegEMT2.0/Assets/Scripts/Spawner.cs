using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;

    public GameObject prefab2;

    public float spawnRate = 2f;
    private float nextSpawnTime = 1f;
    public int spawnCount = 0;
    private int spawnStart = 0;


    [SerializeField]
    private ArduinoController arduinoController;

    private bool spawn1or2 = false;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextSpawnTime && spawnStart <= spawnCount)
        {
            SpawnObject();
            spawnStart++;
            nextSpawnTime = Time.time + 1f / spawnRate;
        }

        if (arduinoController != null)
        {
            string returnData = arduinoController.GetData();

            if (returnData.Equals("red"))
            {
                spawn1or2 = true;
            }
            else
            {
                spawn1or2 = false;
            }
        }


    }
    void SpawnObject()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-50, 51), 1, Random.Range(-50, 51));


        if(spawn1or2 == false) Instantiate(prefab, randomSpawnPosition, Quaternion.identity);
        else Instantiate(prefab2, randomSpawnPosition, Quaternion.identity);

    }

   
}
