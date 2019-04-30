using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{

    public GameObject[] items = new GameObject[5];
    public bool player;

    private short lastSelected;
    public short selected;

    private void OnMouseOver()
    {
        if (!player)
        {
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("Kiste");
                //TODO: Inventare öffnen
            }
        }
    }
}