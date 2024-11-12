using UnityEngine;

public class BatteryRed : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.Collected("red");
            gameObject.SetActive(false);
        }
    }
}
