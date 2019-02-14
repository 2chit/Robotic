using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public float horizontalSpeed;
    public float jumpPower;
    public short maxJumps;
    public short unableToJumpFarmes;

    public List<GameObject> ignoreForJumpcounterReset;

    public string spriten;

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

    private bool IsInList_(List<GameObject> gameObjects, GameObject shouldNotBeIn)
    {
        //schaut ob das GameObject in der List ist
        //return true when in

        for(int i = 0; i < gameObjects.Count; i++)
        {
            if(gameObjects[i].name == shouldNotBeIn.name)
            {
                return true;
            }
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ignoreForJumpcounterReset.Count == 0)
        {
            Debug.Log("Collision");
            if (_avableJumps < maxJumps)
            {
                _avableJumps = maxJumps;
            }
        }
        else
        {
            if (IsInList_(ignoreForJumpcounterReset, collision.gameObject) == false)
            {
                Debug.Log("Collision");
                if (_avableJumps < maxJumps)
                {
                    _avableJumps = maxJumps;
                }
            }
        }
    }

    void FixedUpdate()
    {


        
        if (Input.GetAxis("Horizontal") != 0 && Input.GetKey(spriten))
        {
            //running
            this.transform.position = new Vector3()
            {
                x = this.transform.position.x + Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime * 1.3f,
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





        //Jump Machanics
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