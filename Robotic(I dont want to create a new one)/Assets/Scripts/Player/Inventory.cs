using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static GameObject[] inventory = new GameObject[6];
    public GameObject[] sprites = new GameObject[6];

    private void FixedUpdate()
    {
        for(int i = 0; i < inventory.Count(); i++)
        {
            sprites[i].GetComponent<Image>().sprite = inventory[i].GetComponent<Image>().sprite;
        }
    }
}
