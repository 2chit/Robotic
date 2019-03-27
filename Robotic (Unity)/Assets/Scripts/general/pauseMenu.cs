using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    //Das wird später das Pause Menü, wo man unteranderem zurück zum Startbildschirm kommt

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
