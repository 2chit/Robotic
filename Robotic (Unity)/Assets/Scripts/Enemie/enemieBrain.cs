using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemieBrain : MonoBehaviour
{
    public bool standing;
    public bool lookingToSide; //true when right/ flase when left
    public string lookingFor;
    public float canSeeTo;

    public GameObject weapon;

    
    private void FixedUpdate()
    {
        RaycastHit2D hit = RayCast_();
        if (hit.collider.gameObject.name == lookingFor)
        {
            weapon.GetComponent<weaponScript>().Shoot();
        }
    }

    private RaycastHit2D RayCast_()
    {
        return Physics2D.Raycast(new Vector2(this.transform.position.x * (lookingToSide == true ? 1 : -1), this.weapon.transform.localScale.y * 1.1f + this.transform.localScale.y), new Vector2(this.transform.position.x * (lookingToSide == true ? 1 : -1) + (lookingToSide == true ? 1 : -1), this.weapon.transform.localScale.y * 1.1f + this.transform.localScale.y), canSeeTo);
    }
}