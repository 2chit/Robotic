using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{

    public void onClickExit()
    {
        //ACHTUNG! Das funktioniert wenn man das Spiel später exportiert. Im Editor geht es nicht.
        Debug.Log("EXIT");
        Application.Quit();
    }

    public void onClickSettings()
    {
        Debug.Log("Settings");
        SceneManager.LoadScene(1); //Die 2 steht für den Scene Index. Der wird in den BUILD SETTINGS festgelegt. (File -> Bild Settings)
    }

    public void onClickPlay()
    {
        Debug.Log("LoadScene");
        SceneManager.LoadScene(1); 
    }
}
