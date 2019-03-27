using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class weaponScript : MonoBehaviour
{
    public ushort currentAmmunition;
    public ushort maxAmmunition;
    public Sprite bulletSprite;
    public short damagePerBullet;
    public bool shootSide; //true when right/ flase when left
    public ushort sleepTime; //Time between to shoots

    private ushort _currentSleepTime; //current time to when he could shoot again



    public ushort Releod(ushort ammunition) // Returenes Remaining armonition(which was not needed to reaload the gun)
    {
        if(ammunition < maxAmmunition - currentAmmunition)
        {
            currentAmmunition += ammunition;
            return 0;
        }
        ushort restAmmunition;
        restAmmunition = Convert.ToUInt16(ammunition - maxAmmunition + currentAmmunition);
        currentAmmunition = maxAmmunition;
        return restAmmunition;
    }

    public void Shoot()
    {
        if(0 < this.currentAmmunition && this._currentSleepTime == 0)
        {
            Debug.Log("shoot");
            this.currentAmmunition--;
            this._currentSleepTime = this.sleepTime;
            CreateBullet_();
        }
    }

    private void CreateBullet_()
    {
        //Creates a bullet infront of the Object

        GameObject bullet = new GameObject("bullet");
        bullet.AddComponent<SpriteRenderer>();
        bullet.GetComponent<SpriteRenderer>().sprite = this.bulletSprite;
        bullet.GetComponent<SpriteRenderer>().color = Color.black;
        bullet.AddComponent<Rigidbody2D>();
        bullet.GetComponent<Rigidbody2D>().gravityScale = 0;
        bullet.AddComponent<Bullet>();
        bullet.GetComponent<Bullet>().damage = this.damagePerBullet;
        if (this.shootSide)
        {
            bullet.transform.position = new Vector3(this.transform.position.x + this.transform.lossyScale.x / 2, this.transform.position.y, this.transform.position.z);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000, 0));
        }
        else
        {
            bullet.transform.position = new Vector3(this.transform.position.x - this.transform.lossyScale.x / 2, this.transform.position.y, this.transform.position.z);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000, 0));
        }
        bullet.AddComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        if(this._currentSleepTime > 0)
        {
            this._currentSleepTime--;
        }
    }
}