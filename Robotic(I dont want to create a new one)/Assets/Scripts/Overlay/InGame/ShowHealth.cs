using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHealth : MonoBehaviour
{
    public GameObject player;
    public Slider slider;

    private void FixedUpdate()
    {
        slider.value = player.GetComponent<playerStats>().health;
    }
}
