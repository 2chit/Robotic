using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public float jumpPower;
    public short maxJumps;
    public string jumpButtenKeyboard;
    public string jumpButtenController;


    public List<GameObject> ignoreForJumpCounterReset;

    private Rigidbody2D _rg2D;
    private short _avableJumps;
    private bool _canJump;


    private void Start()
    {
        //Getting Components and setting Variables
        _rg2D = gameObject.GetComponent<Rigidbody2D>();
        _avableJumps = maxJumps;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Resetting Jumps
        if (ignoreForJumpCounterReset.Count == 0)
        {
            JumpReset_(collision);
        }
        else
        {
            if (IsInList_(ignoreForJumpCounterReset, collision.gameObject) == false)
            {
                JumpReset_(collision);
            }
        }
        //Checking if player Is slyding down a wall
    }

    void FixedUpdate()
    {
        //Jump Machanics
        if ((Input.GetKey(jumpButtenKeyboard) || Input.GetButton(jumpButtenController)) && _avableJumps > 0 && _canJump)
        {
            _avableJumps--;
            _canJump = false;
            Debug.Log("Jump " + _avableJumps);
            _rg2D.velocity = new Vector2(_rg2D.velocity.x, 0);
            _rg2D.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
        if(Input.GetKey(jumpButtenKeyboard) == false && Input.GetButton(jumpButtenController) == false)
        {
            _canJump = true;
        }
    }

    private bool IsInList_(List<GameObject> gameObjects, GameObject shouldNotBeIn)
    {
        //schaut ob das GameObject in der List ist
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
        Debug.Log("Collision");
        if (_avableJumps < maxJumps)
        {
            _avableJumps = maxJumps;
        }
    }

    private void CheckIfWall_(Collision2D collision)
    {
        
    }
}