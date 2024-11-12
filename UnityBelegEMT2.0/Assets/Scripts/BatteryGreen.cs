using UnityEngine;

public class BatteryGreen : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.Collected("green");
            gameObject.SetActive(false);
        }
    }
}
