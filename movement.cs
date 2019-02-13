using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public float horizontalSpeed;
    public float jumpPower;
    public short maxJumps;
    public short unableToJumpFarmes;

    private Rigidbody2D _rg2D;
    private short _avableJumps;
    private short _jumpStopFrames;
    private float _originalMass;

    private void Start()
    {
        _rg2D = gameObject.GetComponent<Rigidbody2D>();
        _avableJumps = maxJumps;
        _originalMass = _rg2D.mass;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (_avableJumps < maxJumps)
        {
            _avableJumps = maxJumps;
        }
    }

    void FixedUpdate()
    {
        this.transform.position = new Vector3()
        {
            x = this.transform.position.x + Input.GetAxis("Horizontal") * horizontalSpeed,
            y = this.transform.position.y,
            z = 0
        };
        if (Input.GetAxis("Vertical") > 0 && _avableJumps > 0  && _jumpStopFrames == 0)
        {
            _avableJumps--;
            Debug.Log("Jump " + _avableJumps);
            _jumpStopFrames = unableToJumpFarmes;
            _rg2D.velocity = new Vector2(_rg2D.velocity.x, 0);
            _rg2D.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            _rg2D.mass = _originalMass / 2;
        } else if (_originalMass != _rg2D.mass)
        {
            _rg2D.mass = _originalMass;
        }

        if(_jumpStopFrames > 0)
        {
            _jumpStopFrames--;
        }
    }
}