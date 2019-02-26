using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour {

    public GameObject[] items = new GameObject[5];

    private void OnMouseOver()
    {
        if (Input.GetKeyDown("e"))
        {
            Debug.Log("Kiste");
            //TODO: Inventare öffnen
        }
    }
}