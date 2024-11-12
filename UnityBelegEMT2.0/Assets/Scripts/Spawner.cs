using UnityEngine;
using System.Threading;

public class Spawner : MonoBehaviour
{
    public GameObject redPrefab;

    public GameObject greenPrefab;

    public float spawnRate = 2f;
    private float nextSpawnTime = 1f;
    public int spawnCount = 0;
    private int spawnStart = 0;
    private string spawnRedOrGreen;

    [SerializeField]
    private ArduinoController arduinoController;


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawnTime && spawnStart <= spawnCount)
        {
            SpawnObject();
            spawnStart++;
            nextSpawnTime = Time.time + 1f / spawnRate;
        }

        if (arduinoController != null)
        {
            string returnData = arduinoController.GetData();

            if (returnData == "red")
            {
                Debug.Log("red was called");
                spawnRedOrGreen = "red";
            }
            else
            {
                spawnRedOrGreen = "green";
            }
        }


    }
    void SpawnObject()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-50, 51), 1, Random.Range(-50, 51));


        if (spawnRedOrGreen == "red")
        {
            Instantiate(redPrefab, randomSpawnPosition, Quaternion.identity);
            Debug.Log("red was inst");
        }
        else Instantiate(greenPrefab, randomSpawnPosition, Quaternion.identity);

    }


}
