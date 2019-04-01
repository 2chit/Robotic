using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemieGenerals : MonoBehaviour
{
    public short health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "bullet")
        {
            this.health -= collision.gameObject.GetComponent<Bullet>().damage;
        } 
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
