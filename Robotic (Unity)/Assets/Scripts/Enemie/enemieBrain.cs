using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemieBrain : MonoBehaviour
{
    public bool standing;
    public bool lookingToSide; //true when right/ flase when left
    public string lookingFor;
    public int canSeeTo;

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
        Debug.DrawRay(new Vector2(this.weapon.transform.position.x + weapon.transform.localScale.x * 0.5f * (lookingToSide == true ? 1.1f : -1.1f), this.weapon.transform.position.y), new Vector2(canSeeTo * (lookingToSide == true ? 1 : -1), 0), Color.red);
        return Physics2D.Raycast(new Vector2(this.weapon.transform.position.x + weapon.transform.localScale.x * 0.5f * (lookingToSide == true ? 1.1f : -1.1f), this.weapon.transform.position.y), new Vector2(canSeeTo * (lookingToSide == true ? 1 : -1), 0));
    }
}