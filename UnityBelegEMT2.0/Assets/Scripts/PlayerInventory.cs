using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfRedCollectibles;
    public int NumberOfGreenCollectibles;
    public UnityEvent<PlayerInventory> OnCollect;
    public void Collected(string color)
    {
        Debug.Log("collected was called");
        if (color == "red")
        {
            // Debug.Log("collected: red");
            NumberOfRedCollectibles++;
        }
        else if (color == "green")
        {
            // Debug.Log("collected: green");
            NumberOfGreenCollectibles++;
        }
        OnCollect.Invoke(this);
    }
}
