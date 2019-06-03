using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public float horizontalSpeed;
    public float runningMulti;
    public string keyboardRunning;
    public string controllerRunning;
    public short timeToPeressAgain; //time the player has for pressing this putten Again to lay down;
    public List<string> Crouchkeys; //keys to press
    public float[] scaleHeightMultiplicator = new float[2]; //Gets Multiplicator with the scale 0 by crouching, 1 by laying down
    public float[] scaleWidthMultiplicator = new float[2]; //Gets Multiplicator with the scale 0 by crouching, 1 by laying down
    public float[] scaleSpeedMultiplicator = new float[2]; //Gets Multiplicator with the scale 0 by crouching, 1 by laying down
    public float jumpPower;
    public short maxJumps;
    public string[] jumpButtensKeyboard;


    //Original Scale
    private float _origHeight;
    private float _origWidht;

    private bool _standing;

    private bool touchingLeft;
    private bool touchingRight;
    private short _avableJumps;
    private short _timeRemain; //time the has remain for pressing a butten to lay down;
    private float _originalSpeed;

    private Rigidbody2D _rg2D;

    private void Start()
    {
        _rg2D = gameObject.GetComponent<Rigidbody2D>();
        _origHeight = this.transform.localScale.y;
        _origWidht = this.transform.localScale.x;
        _standing = true;
        _originalSpeed = this.horizontalSpeed;
        _rg2D = gameObject.GetComponent<Rigidbody2D>();
        _avableJumps = maxJumps;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("PlayerCollision");


        //Resetting Jumps
        if (DetectCollisionOnTop_(collision) == false || DetectingCollisionSide(collision) != "NA")
        {
            Debug.Log("Collided on bottem");
            JumpReset_(collision);
        }

        //Colliding with wall
        string collisionPoint = DetectingCollisionSide(collision);

        if (collisionPoint == "right")
        {
            Debug.Log("r");
            this.touchingLeft = true;
            this.touchingRight = false;
        }
        else if (collisionPoint == "left")
        {
            Debug.Log("l");
            this.touchingRight = true;
            this.touchingLeft = false;
        } else
        {
            this.touchingLeft = false;
            this.touchingRight = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        this.touchingLeft = false;
        this.touchingRight = false;
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            //running
            Debug.Log("Running");
            this.transform.position = new Vector3()
            {
                x = this.transform.position.x + Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime * runningMulti,
                y = this.transform.position.y,
                z = 0
            };
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
            //walking
            Debug.Log("Walking");
            this.transform.position = new Vector3()
            {
                x = this.transform.position.x + Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime,
                y = this.transform.position.y,
                z = 0
            };
        }


        //Crouching Script
        if (InputButtenGetPressed())
        {
            if (LayingDown_() == false)
            {
                Crouching_();
            }
            _standing = false;
        }
        else
        {
            //Counter minus 1
            if (_timeRemain > 0)
            {
                _timeRemain -= 1;
            }

            //Standing
            if (_standing == false)
            {
                this.transform.localScale = new Vector3(_origWidht, _origHeight);
                horizontalSpeed = _originalSpeed;
                _standing = true;
            }
        }

        //Jump Machanics
        for (int i = 0; i < jumpButtensKeyboard.Length; i++)
        {
            if ((Input.GetKeyDown(jumpButtensKeyboard[i])) && _avableJumps > 0)
            {
                if (touchingLeft == true)
                {
                    _avableJumps--;
                    Debug.Log("Jump left " + _avableJumps);
                    _rg2D.velocity = new Vector2(_rg2D.velocity.x, 0);
                    _rg2D.AddForce(new Vector2(jumpPower, jumpPower), ForceMode2D.Impulse);
                }
                else if (touchingRight == true)
                {
                    _avableJumps--;
                    Debug.Log("Jump right" + _avableJumps);
                    _rg2D.velocity = new Vector2(_rg2D.velocity.x, 0);
                    _rg2D.AddForce(new Vector2(jumpPower * -1, jumpPower), ForceMode2D.Impulse);
                }
                else
                {
                    _avableJumps--;
                    Debug.Log("Jump " + _avableJumps);
                    _rg2D.velocity = new Vector2(_rg2D.velocity.x, 0);
                    _rg2D.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
                }
            }
        }
    }

    private bool InputButtenGetPressed()
    {
        //Checks if an Inputbutten get pressed
        for (int i = 0; i < this.Crouchkeys.Count; i++)
        {
            if (Input.GetKey(this.Crouchkeys[i]))
            {
                return true;
            }
        }
        return false;
    }

    private void Crouching_()
    {
        _timeRemain = this.timeToPeressAgain;

        //Crouching
        this.transform.localScale = new Vector3(_origWidht * this.scaleWidthMultiplicator[0], _origHeight * this.scaleHeightMultiplicator[0]);
        this.horizontalSpeed = _originalSpeed * this.scaleSpeedMultiplicator[0];
    }

    private bool LayingDown_()
    {
        if (0 < _timeRemain && _timeRemain < this.timeToPeressAgain)
        {
            //laying down
            this.transform.localScale = new Vector3(_origWidht * scaleWidthMultiplicator[1], _origHeight * scaleHeightMultiplicator[1]);
            this.horizontalSpeed = _originalSpeed * this.scaleSpeedMultiplicator[1];
            return true;
        }
        return false;
    }

    private bool IsInList_(List<GameObject> gameObjects, GameObject shouldNotBeIn)
    {
        //looks if the game object is in the list
        //return true when in
        for (int i = 0; i < gameObjects.Count; i++)
        {
            if (gameObjects[i].name == shouldNotBeIn.name)
            {
                return true;
            }
        }
        return false;
    }

    private void JumpReset_(Collision2D collision)
    {
        if (_avableJumps < maxJumps)
        {
            _avableJumps = maxJumps;
        }
    }

    private string DetectingCollisionSide(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        Vector3 center = collider.bounds.center;
        for (int i = 0; i < collision.contactCount; i++)
        {
            Vector3 contactPoint = collision.GetContact(i).point;
            if (contactPoint.x >= center.x && this.transform.position.y < contactPoint.y && contactPoint.y > this.transform.position.y - this.transform.lossyScale.y)
            {
                return "right";
            }
            if (contactPoint.x <= center.x && this.transform.position.y < contactPoint.y && contactPoint.y > this.transform.position.y - this.transform.lossyScale.y)
            {
                return "left";
            }
        }
        return "NA";
    }

    private bool DetectCollisionOnTop_(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        Vector3 center = collider.bounds.center;
        for (int i = 0; i < collision.contactCount; i++)
        {
            Vector3 contactPoint = collision.GetContact(i).point;
            if (contactPoint.y <= center.y && this.transform.position.x + this.transform.lossyScale.x / 2 > contactPoint.x && contactPoint.x < this.transform.position.x - this.transform.lossyScale.x / 2)
            {
                return true;
            }
        }
        return false;
    }
}