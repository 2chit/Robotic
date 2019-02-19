using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouch : MonoBehaviour
{
    public short timeToPeressAgain; //time the player has for pressing this putten Again to lay down;
    public List<string> keys; //keys to press
    public float[] scaleHeightMultiplicator = new float[2]; //Gets Multiplicated with the scale 0 by crouching, 1 by laying down
    public float[] scaleWidthMultiplicator = new float[2]; //Gets Multiplicated with the scale 0 by crouching, 1 by laying down

    private short _timeRemain; //time the has remain for pressing a butten to lay down;

    //Original Scale
    private float _origHeight;
    private float _origWidht;

    private bool _standing;

    private void Start()
    {
        _origHeight = this.transform.localScale.y;
        _origWidht = this.transform.localScale.x;
        _standing = true;
    }

    private void FixedUpdate()
    {
        if (InputButtenGetPressed())
        {
            if(LayingDown_() == false)
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
                _standing = true;
            }
        }
    }

    private bool InputButtenGetPressed()
    {
        //Checks if an Inputbutten get pressed
        for(int i = 0; i < this.keys.Count; i++)
        {
            if (Input.GetKey(this.keys[i]))
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
        this.transform.localScale = new Vector3(_origWidht * this.scaleWidthMultiplicator[0], _origHeight*this.scaleHeightMultiplicator[0]);
    }

    private bool LayingDown_()
    {
        if(0 < _timeRemain && _timeRemain < this.timeToPeressAgain)
        {
            //laying down
            this.transform.localScale = new Vector3(_origWidht * scaleWidthMultiplicator[1], _origHeight * scaleHeightMultiplicator[1]);
            return true;
        }
        return false;
    }
}
