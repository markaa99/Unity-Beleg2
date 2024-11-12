using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI collectText;
    // Start is called before the first frame update
    void Start()
    {
        collectText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void UpdateCollectText(PlayerInventory playerInventory)
    {
        int redPoints = playerInventory.NumberOfRedCollectibles;
        int greenPoints = playerInventory.NumberOfGreenCollectibles;
        collectText.text = $"Red: {redPoints} | Green: {greenPoints}";
    }
}
