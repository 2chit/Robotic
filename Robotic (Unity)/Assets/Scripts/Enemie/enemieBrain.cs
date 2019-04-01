using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemieBrain : MonoBehaviour
{
    public bool standing;
    public bool lookingToSide; //true when right/ flase when left
    public float canSeeTo;

    public GameObject Weapon;

    private void FixedUpdate()
    {
        
    }

    private RaycastHit2D _RayCast(Vector2 raycastTo)
    {
        return Physics2D.Raycast(new Vector2(this.transform.position.x * (lookingToSide == true ? 1 : -1), this.Weapon.transform.position.y), raycastTo, canSeeTo);
    }
}