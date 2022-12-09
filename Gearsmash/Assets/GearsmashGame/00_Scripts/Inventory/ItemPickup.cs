using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public GameObject effect;
    public AudioSource tutorial;
    
    void Pickup()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
        if (tutorial != null)
        {
            tutorial.Play();
        }
        if (effect != null)
        {
            Destroy(effect.gameObject, 12f);
        }
    }
}
