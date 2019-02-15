using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public float horizontalSpeed;
    public float runningMulti;
    public string keyboardRunning;
    public string controllerRunning;

    private Rigidbody2D _rg2D;

    private void Start()
    {
        _rg2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0 && (Input.GetKey(keyboardRunning) || Input.GetButton(controllerRunning) ))
        {
            //running
            this.transform.position = new Vector3()
            {
                x = this.transform.position.x + Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime * runningMulti,
                y = this.transform.position.y,
                z = 0
            };
        }
        else if(Input.GetAxis("Horizontal") != 0)
        {
            //walking
            this.transform.position = new Vector3()
            {
                x = this.transform.position.x + Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime,
                y = this.transform.position.y,
                z = 0
            };
        }
    }
}