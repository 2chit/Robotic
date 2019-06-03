using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item : MonoBehaviour
{
    public GameObject itemInChest;

    private void OnMouseDown()
    {
        for(int i = 0; i < Inventory.inventory.Length; i++)
        {
            if(Inventory.inventory[i] != null)
            {
                Inventory.inventory[i] = itemInChest;
                break;
            }
        }
        gameObject.active = false;
    }
}