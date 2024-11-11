using System.Collections;
using System.Collections.Generic;
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
        collectText.text = playerInventory.NumberOfCollectibles.ToString();
    }
}
