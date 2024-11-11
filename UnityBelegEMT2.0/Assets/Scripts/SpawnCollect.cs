using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollect : MonoBehaviour
{
    public GameObject prefab;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0f, 1f, 0f, Space.Self);
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 0, Random.Range(-10, 11));
            Instantiate(prefab, randomSpawnPosition, Quaternion.identity);
        }
    }
}
