using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useWeapons : MonoBehaviour
{
    public string[] toFire; //Buttens to use Weapons
    public GameObject weapon;

    public bool lookToSide; //true when right/ flase when left

    private void FixedUpdate()
    {
        foreach(string butten in this.toFire)
        {
            if (Input.GetKey(butten))
            {
                this.weapon.GetComponent<weaponScript>().Shoot();
            }
        }

        if(this.lookToSide == false && Input.GetAxis("Horizontal") > 0)
        {
            this.lookToSide = true;
            this.weapon.GetComponent<SpriteRenderer>().flipX = false;
            this.weapon.transform.position = new Vector3(this.transform.position.x + this.transform.localScale.x / 2 + this.weapon.transform.localScale.x / 2, this.weapon.transform.position.y);
            this.weapon.GetComponent<weaponScript>().shootSide = lookToSide;
        }
        else if (this.lookToSide && Input.GetAxis("Horizontal") < 0)
        {
            this.lookToSide = false;
            this.weapon.GetComponent<SpriteRenderer>().flipX = true;
            this.weapon.transform.position = new Vector3(this.transform.position.x - this.transform.localScale.x / 2 - this.weapon.transform.localScale.x / 2, this.weapon.transform.position.y);
            this.weapon.GetComponent<weaponScript>().shootSide = lookToSide;
        }
    }
}