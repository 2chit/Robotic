using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item : MonoBehaviour
{
    public GameObject itemInChest;
    private chest playerInventory;
    private Object[] inventory;

    private void Start()
    {
        playerInventory = GameObject.Find("Player").GetComponentInChildren<chest>();
        inventory = Resources.FindObjectsOfTypeAll(System.Type.GetType("ItemInInventory"));
    }

    private void OnMouseDown()
    {
        for(int i = 0; i < playerInventory.items.Length; i++)
        {
            if(playerInventory.items[i] != null)
            {
                playerInventory.items[i] = itemInChest;
                //inventory[i].
                Image a = new Image();
                a.GetComponent<>
                break;
            }
        }
        Destroy(gameObject);
    }

    public void Draw()
    {
        
    }
}