using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        
        if(playerInventory != null)
        {
            playerInventory.Collected();
            gameObject.SetActive(false);
        }
    }
}
